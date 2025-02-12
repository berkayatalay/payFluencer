using Application.Features.SponsorReviews.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.SponsorReviews.Constants.SponsorReviewsOperationClaims;

namespace Application.Features.SponsorReviews.Queries.GetList;

public class GetListSponsorReviewQuery : IRequest<GetListResponse<GetListSponsorReviewListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSponsorReviews({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSponsorReviews";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSponsorReviewQueryHandler : IRequestHandler<GetListSponsorReviewQuery, GetListResponse<GetListSponsorReviewListItemDto>>
    {
        private readonly ISponsorReviewRepository _sponsorReviewRepository;
        private readonly IMapper _mapper;

        public GetListSponsorReviewQueryHandler(ISponsorReviewRepository sponsorReviewRepository, IMapper mapper)
        {
            _sponsorReviewRepository = sponsorReviewRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSponsorReviewListItemDto>> Handle(GetListSponsorReviewQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SponsorReview> sponsorReviews = await _sponsorReviewRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSponsorReviewListItemDto> response = _mapper.Map<GetListResponse<GetListSponsorReviewListItemDto>>(sponsorReviews);
            return response;
        }
    }
}