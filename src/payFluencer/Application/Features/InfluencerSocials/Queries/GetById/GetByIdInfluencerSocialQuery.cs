using Application.Features.InfluencerSocials.Constants;
using Application.Features.InfluencerSocials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.InfluencerSocials.Constants.InfluencerSocialsOperationClaims;

namespace Application.Features.InfluencerSocials.Queries.GetById;

public class GetByIdInfluencerSocialQuery : IRequest<GetByIdInfluencerSocialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdInfluencerSocialQueryHandler : IRequestHandler<GetByIdInfluencerSocialQuery, GetByIdInfluencerSocialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerSocialRepository _influencerSocialRepository;
        private readonly InfluencerSocialBusinessRules _influencerSocialBusinessRules;

        public GetByIdInfluencerSocialQueryHandler(IMapper mapper, IInfluencerSocialRepository influencerSocialRepository, InfluencerSocialBusinessRules influencerSocialBusinessRules)
        {
            _mapper = mapper;
            _influencerSocialRepository = influencerSocialRepository;
            _influencerSocialBusinessRules = influencerSocialBusinessRules;
        }

        public async Task<GetByIdInfluencerSocialResponse> Handle(GetByIdInfluencerSocialQuery request, CancellationToken cancellationToken)
        {
            InfluencerSocial? influencerSocial = await _influencerSocialRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerSocialBusinessRules.InfluencerSocialShouldExistWhenSelected(influencerSocial);

            GetByIdInfluencerSocialResponse response = _mapper.Map<GetByIdInfluencerSocialResponse>(influencerSocial);
            return response;
        }
    }
}