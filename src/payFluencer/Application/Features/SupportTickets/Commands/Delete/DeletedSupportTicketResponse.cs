using NArchitecture.Core.Application.Responses;

namespace Application.Features.SupportTickets.Commands.Delete;

public class DeletedSupportTicketResponse : IResponse
{
    public Guid Id { get; set; }
}