using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SupportTickets.Queries.GetList;

public class GetListSupportTicketListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
}