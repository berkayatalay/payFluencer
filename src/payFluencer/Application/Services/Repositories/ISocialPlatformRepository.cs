using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISocialPlatformRepository : IAsyncRepository<SocialPlatform, int>, IRepository<SocialPlatform, int>
{
}