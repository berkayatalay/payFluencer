using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PostRepository : EfRepositoryBase<Post, Guid, BaseDbContext>, IPostRepository
{
    public PostRepository(BaseDbContext context) : base(context)
    {
    }
}