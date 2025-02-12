using Application.Features.InfluencerSocials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.InfluencerSocials.Constants.InfluencerSocialsOperationClaims;

namespace Application.Features.InfluencerSocials.Queries.GetList;

public class GetListInfluencerSocialQuery : IRequest<GetListResponse<GetListInfluencerSocialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListInfluencerSocials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetInfluencerSocials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListInfluencerSocialQueryHandler : IRequestHandler<GetListInfluencerSocialQuery, GetListResponse<GetListInfluencerSocialListItemDto>>
    {
        private readonly IInfluencerSocialRepository _influencerSocialRepository;
        private readonly IMapper _mapper;

        public GetListInfluencerSocialQueryHandler(IInfluencerSocialRepository influencerSocialRepository, IMapper mapper)
        {
            _influencerSocialRepository = influencerSocialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInfluencerSocialListItemDto>> Handle(GetListInfluencerSocialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<InfluencerSocial> influencerSocials = await _influencerSocialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInfluencerSocialListItemDto> response = _mapper.Map<GetListResponse<GetListInfluencerSocialListItemDto>>(influencerSocials);
            return response;
        }
    }
}