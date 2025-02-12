using Application.Features.Gigs.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Gigs.Constants.GigsOperationClaims;

namespace Application.Features.Gigs.Queries.GetList;

public class GetListGigQuery : IRequest<GetListResponse<GetListGigListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListGigs({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetGigs";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListGigQueryHandler : IRequestHandler<GetListGigQuery, GetListResponse<GetListGigListItemDto>>
    {
        private readonly IGigRepository _gigRepository;
        private readonly IMapper _mapper;

        public GetListGigQueryHandler(IGigRepository gigRepository, IMapper mapper)
        {
            _gigRepository = gigRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGigListItemDto>> Handle(GetListGigQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Gig> gigs = await _gigRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGigListItemDto> response = _mapper.Map<GetListResponse<GetListGigListItemDto>>(gigs);
            return response;
        }
    }
}