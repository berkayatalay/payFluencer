using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SupportTicketRepository : EfRepositoryBase<SupportTicket, Guid, BaseDbContext>, ISupportTicketRepository
{
    public SupportTicketRepository(BaseDbContext context) : base(context)
    {
    }
}