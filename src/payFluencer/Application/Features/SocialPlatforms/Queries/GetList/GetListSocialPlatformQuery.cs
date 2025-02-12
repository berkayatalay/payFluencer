using Application.Features.SocialPlatforms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.SocialPlatforms.Constants.SocialPlatformsOperationClaims;

namespace Application.Features.SocialPlatforms.Queries.GetList;

public class GetListSocialPlatformQuery : IRequest<GetListResponse<GetListSocialPlatformListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSocialPlatforms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSocialPlatforms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSocialPlatformQueryHandler : IRequestHandler<GetListSocialPlatformQuery, GetListResponse<GetListSocialPlatformListItemDto>>
    {
        private readonly ISocialPlatformRepository _socialPlatformRepository;
        private readonly IMapper _mapper;

        public GetListSocialPlatformQueryHandler(ISocialPlatformRepository socialPlatformRepository, IMapper mapper)
        {
            _socialPlatformRepository = socialPlatformRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSocialPlatformListItemDto>> Handle(GetListSocialPlatformQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SocialPlatform> socialPlatforms = await _socialPlatformRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSocialPlatformListItemDto> response = _mapper.Map<GetListResponse<GetListSocialPlatformListItemDto>>(socialPlatforms);
            return response;
        }
    }
}