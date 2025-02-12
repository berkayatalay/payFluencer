using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SocialPlatformRepository : EfRepositoryBase<SocialPlatform, int, BaseDbContext>, ISocialPlatformRepository
{
    public SocialPlatformRepository(BaseDbContext context) : base(context)
    {
    }
}