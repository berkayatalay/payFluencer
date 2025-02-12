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

namespace Application.Features.Disputes.Commands.Create;

public class CreateDisputeCommand : IRequest<CreatedDisputeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, DisputesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDisputes"];

    public class CreateDisputeCommandHandler : IRequestHandler<CreateDisputeCommand, CreatedDisputeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisputeRepository _disputeRepository;
        private readonly DisputeBusinessRules _disputeBusinessRules;

        public CreateDisputeCommandHandler(IMapper mapper, IDisputeRepository disputeRepository,
                                         DisputeBusinessRules disputeBusinessRules)
        {
            _mapper = mapper;
            _disputeRepository = disputeRepository;
            _disputeBusinessRules = disputeBusinessRules;
        }

        public async Task<CreatedDisputeResponse> Handle(CreateDisputeCommand request, CancellationToken cancellationToken)
        {
            Dispute dispute = _mapper.Map<Dispute>(request);

            await _disputeRepository.AddAsync(dispute);

            CreatedDisputeResponse response = _mapper.Map<CreatedDisputeResponse>(dispute);
            return response;
        }
    }
}