using Application.Features.Disputes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Disputes.Constants.DisputesOperationClaims;

namespace Application.Features.Disputes.Queries.GetList;

public class GetListDisputeQuery : IRequest<GetListResponse<GetListDisputeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListDisputes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetDisputes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDisputeQueryHandler : IRequestHandler<GetListDisputeQuery, GetListResponse<GetListDisputeListItemDto>>
    {
        private readonly IDisputeRepository _disputeRepository;
        private readonly IMapper _mapper;

        public GetListDisputeQueryHandler(IDisputeRepository disputeRepository, IMapper mapper)
        {
            _disputeRepository = disputeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDisputeListItemDto>> Handle(GetListDisputeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Dispute> disputes = await _disputeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDisputeListItemDto> response = _mapper.Map<GetListResponse<GetListDisputeListItemDto>>(disputes);
            return response;
        }
    }
}