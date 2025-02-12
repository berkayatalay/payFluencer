using Application.Features.PostGigs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PostGigs.Constants.PostGigsOperationClaims;

namespace Application.Features.PostGigs.Queries.GetList;

public class GetListPostGigQuery : IRequest<GetListResponse<GetListPostGigListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPostGigs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPostGigs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPostGigQueryHandler : IRequestHandler<GetListPostGigQuery, GetListResponse<GetListPostGigListItemDto>>
    {
        private readonly IPostGigRepository _postGigRepository;
        private readonly IMapper _mapper;

        public GetListPostGigQueryHandler(IPostGigRepository postGigRepository, IMapper mapper)
        {
            _postGigRepository = postGigRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPostGigListItemDto>> Handle(GetListPostGigQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PostGig> postGigs = await _postGigRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPostGigListItemDto> response = _mapper.Map<GetListResponse<GetListPostGigListItemDto>>(postGigs);
            return response;
        }
    }
}