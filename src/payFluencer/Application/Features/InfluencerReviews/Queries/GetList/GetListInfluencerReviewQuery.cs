using Application.Features.InfluencerReviews.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.InfluencerReviews.Constants.InfluencerReviewsOperationClaims;

namespace Application.Features.InfluencerReviews.Queries.GetList;

public class GetListInfluencerReviewQuery : IRequest<GetListResponse<GetListInfluencerReviewListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListInfluencerReviews({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetInfluencerReviews";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListInfluencerReviewQueryHandler : IRequestHandler<GetListInfluencerReviewQuery, GetListResponse<GetListInfluencerReviewListItemDto>>
    {
        private readonly IInfluencerReviewRepository _influencerReviewRepository;
        private readonly IMapper _mapper;

        public GetListInfluencerReviewQueryHandler(IInfluencerReviewRepository influencerReviewRepository, IMapper mapper)
        {
            _influencerReviewRepository = influencerReviewRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInfluencerReviewListItemDto>> Handle(GetListInfluencerReviewQuery request, CancellationToken cancellationToken)
        {
            IPaginate<InfluencerReview> influencerReviews = await _influencerReviewRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInfluencerReviewListItemDto> response = _mapper.Map<GetListResponse<GetListInfluencerReviewListItemDto>>(influencerReviews);
            return response;
        }
    }
}