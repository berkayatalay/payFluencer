using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISupportTicketRepository : IAsyncRepository<SupportTicket, Guid>, IRepository<SupportTicket, Guid>
{
}