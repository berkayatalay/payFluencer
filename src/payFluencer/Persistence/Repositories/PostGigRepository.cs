using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostGigRepository : EfRepositoryBase<PostGig, Guid, BaseDbContext>, IPostGigRepository
{
    public PostGigRepository(BaseDbContext context) : base(context)
    {
    }
}