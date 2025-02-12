using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GigRepository : EfRepositoryBase<Gig, Guid, BaseDbContext>, IGigRepository
{
    public GigRepository(BaseDbContext context) : base(context)
    {
    }
}