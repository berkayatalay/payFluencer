using Application.Features.Disputes.Constants;
using Application.Features.Disputes.Constants;
using Application.Features.Disputes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Disputes.Constants.DisputesOperationClaims;

namespace Application.Features.Disputes.Commands.Delete;

public class DeleteDisputeCommand : IRequest<DeletedDisputeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, DisputesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDisputes"];

    public class DeleteDisputeCommandHandler : IRequestHandler<DeleteDisputeCommand, DeletedDisputeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisputeRepository _disputeRepository;
        private readonly DisputeBusinessRules _disputeBusinessRules;

        public DeleteDisputeCommandHandler(IMapper mapper, IDisputeRepository disputeRepository,
                                         DisputeBusinessRules disputeBusinessRules)
        {
            _mapper = mapper;
            _disputeRepository = disputeRepository;
            _disputeBusinessRules = disputeBusinessRules;
        }

        public async Task<DeletedDisputeResponse> Handle(DeleteDisputeCommand request, CancellationToken cancellationToken)
        {
            Dispute? dispute = await _disputeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _disputeBusinessRules.DisputeShouldExistWhenSelected(dispute);

            await _disputeRepository.DeleteAsync(dispute!);

            DeletedDisputeResponse response = _mapper.Map<DeletedDisputeResponse>(dispute);
            return response;
        }
    }
}