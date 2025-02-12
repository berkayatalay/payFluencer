using Application.Features.SupportTickets.Commands.Create;
using Application.Features.SupportTickets.Commands.Delete;
using Application.Features.SupportTickets.Commands.Update;
using Application.Features.SupportTickets.Queries.GetById;
using Application.Features.SupportTickets.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SupportTickets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSupportTicketCommand, SupportTicket>();
        CreateMap<SupportTicket, CreatedSupportTicketResponse>();

        CreateMap<UpdateSupportTicketCommand, SupportTicket>();
        CreateMap<SupportTicket, UpdatedSupportTicketResponse>();

        CreateMap<DeleteSupportTicketCommand, SupportTicket>();
        CreateMap<SupportTicket, DeletedSupportTicketResponse>();

        CreateMap<SupportTicket, GetByIdSupportTicketResponse>();

        CreateMap<SupportTicket, GetListSupportTicketListItemDto>();
        CreateMap<IPaginate<SupportTicket>, GetListResponse<GetListSupportTicketListItemDto>>();
    }
}