using Application.Features.Influencers.Constants;
using Application.Features.Influencers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Influencers.Constants.InfluencersOperationClaims;

namespace Application.Features.Influencers.Queries.GetById;

public class GetByIdInfluencerQuery : IRequest<GetByIdInfluencerResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdInfluencerQueryHandler : IRequestHandler<GetByIdInfluencerQuery, GetByIdInfluencerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerRepository _influencerRepository;
        private readonly InfluencerBusinessRules _influencerBusinessRules;

        public GetByIdInfluencerQueryHandler(IMapper mapper, IInfluencerRepository influencerRepository, InfluencerBusinessRules influencerBusinessRules)
        {
            _mapper = mapper;
            _influencerRepository = influencerRepository;
            _influencerBusinessRules = influencerBusinessRules;
        }

        public async Task<GetByIdInfluencerResponse> Handle(GetByIdInfluencerQuery request, CancellationToken cancellationToken)
        {
            Influencer? influencer = await _influencerRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerBusinessRules.InfluencerShouldExistWhenSelected(influencer);

            GetByIdInfluencerResponse response = _mapper.Map<GetByIdInfluencerResponse>(influencer);
            return response;
        }
    }
}