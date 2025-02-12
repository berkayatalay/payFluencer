using Application.Features.Disputes.Constants;
using Application.Features.Disputes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Disputes.Constants.DisputesOperationClaims;

namespace Application.Features.Disputes.Queries.GetById;

public class GetByIdDisputeQuery : IRequest<GetByIdDisputeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdDisputeQueryHandler : IRequestHandler<GetByIdDisputeQuery, GetByIdDisputeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisputeRepository _disputeRepository;
        private readonly DisputeBusinessRules _disputeBusinessRules;

        public GetByIdDisputeQueryHandler(IMapper mapper, IDisputeRepository disputeRepository, DisputeBusinessRules disputeBusinessRules)
        {
            _mapper = mapper;
            _disputeRepository = disputeRepository;
            _disputeBusinessRules = disputeBusinessRules;
        }

        public async Task<GetByIdDisputeResponse> Handle(GetByIdDisputeQuery request, CancellationToken cancellationToken)
        {
            Dispute? dispute = await _disputeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _disputeBusinessRules.DisputeShouldExistWhenSelected(dispute);

            GetByIdDisputeResponse response = _mapper.Map<GetByIdDisputeResponse>(dispute);
            return response;
        }
    }
}