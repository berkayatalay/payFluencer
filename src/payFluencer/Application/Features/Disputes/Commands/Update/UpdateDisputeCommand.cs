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

namespace Application.Features.Disputes.Commands.Update;

public class UpdateDisputeCommand : IRequest<UpdatedDisputeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, DisputesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDisputes"];

    public class UpdateDisputeCommandHandler : IRequestHandler<UpdateDisputeCommand, UpdatedDisputeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisputeRepository _disputeRepository;
        private readonly DisputeBusinessRules _disputeBusinessRules;

        public UpdateDisputeCommandHandler(IMapper mapper, IDisputeRepository disputeRepository,
                                         DisputeBusinessRules disputeBusinessRules)
        {
            _mapper = mapper;
            _disputeRepository = disputeRepository;
            _disputeBusinessRules = disputeBusinessRules;
        }

        public async Task<UpdatedDisputeResponse> Handle(UpdateDisputeCommand request, CancellationToken cancellationToken)
        {
            Dispute? dispute = await _disputeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _disputeBusinessRules.DisputeShouldExistWhenSelected(dispute);
            dispute = _mapper.Map(request, dispute);

            await _disputeRepository.UpdateAsync(dispute!);

            UpdatedDisputeResponse response = _mapper.Map<UpdatedDisputeResponse>(dispute);
            return response;
        }
    }
}