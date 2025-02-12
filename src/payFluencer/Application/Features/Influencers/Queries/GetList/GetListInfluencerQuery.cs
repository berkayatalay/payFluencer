using Application.Features.Influencers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Influencers.Constants.InfluencersOperationClaims;

namespace Application.Features.Influencers.Queries.GetList;

public class GetListInfluencerQuery : IRequest<GetListResponse<GetListInfluencerListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListInfluencers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetInfluencers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListInfluencerQueryHandler : IRequestHandler<GetListInfluencerQuery, GetListResponse<GetListInfluencerListItemDto>>
    {
        private readonly IInfluencerRepository _influencerRepository;
        private readonly IMapper _mapper;

        public GetListInfluencerQueryHandler(IInfluencerRepository influencerRepository, IMapper mapper)
        {
            _influencerRepository = influencerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInfluencerListItemDto>> Handle(GetListInfluencerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Influencer> influencers = await _influencerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInfluencerListItemDto> response = _mapper.Map<GetListResponse<GetListInfluencerListItemDto>>(influencers);
            return response;
        }
    }
}