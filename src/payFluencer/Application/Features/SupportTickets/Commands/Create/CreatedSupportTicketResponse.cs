using NArchitecture.Core.Application.Responses;

namespace Application.Features.SupportTickets.Commands.Create;

public class CreatedSupportTicketResponse : IResponse
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
}