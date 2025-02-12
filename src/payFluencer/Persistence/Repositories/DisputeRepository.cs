using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DisputeRepository : EfRepositoryBase<Dispute, Guid, BaseDbContext>, IDisputeRepository
{
    public DisputeRepository(BaseDbContext context) : base(context)
    {
    }
}