using Application.Features.SupportTickets.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.SupportTickets.Constants.SupportTicketsOperationClaims;

namespace Application.Features.SupportTickets.Queries.GetList;

public class GetListSupportTicketQuery : IRequest<GetListResponse<GetListSupportTicketListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSupportTickets({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSupportTickets";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSupportTicketQueryHandler : IRequestHandler<GetListSupportTicketQuery, GetListResponse<GetListSupportTicketListItemDto>>
    {
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly IMapper _mapper;

        public GetListSupportTicketQueryHandler(ISupportTicketRepository supportTicketRepository, IMapper mapper)
        {
            _supportTicketRepository = supportTicketRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSupportTicketListItemDto>> Handle(GetListSupportTicketQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SupportTicket> supportTickets = await _supportTicketRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSupportTicketListItemDto> response = _mapper.Map<GetListResponse<GetListSupportTicketListItemDto>>(supportTickets);
            return response;
        }
    }
}