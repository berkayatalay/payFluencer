using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialPlatforms;

public interface ISocialPlatformService
{
    Task<SocialPlatform?> GetAsync(
        Expression<Func<SocialPlatform, bool>> predicate,
        Func<IQueryable<SocialPlatform>, IIncludableQueryable<SocialPlatform, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SocialPlatform>?> GetListAsync(
        Expression<Func<SocialPlatform, bool>>? predicate = null,
        Func<IQueryable<SocialPlatform>, IOrderedQueryable<SocialPlatform>>? orderBy = null,
        Func<IQueryable<SocialPlatform>, IIncludableQueryable<SocialPlatform, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SocialPlatform> AddAsync(SocialPlatform socialPlatform);
    Task<SocialPlatform> UpdateAsync(SocialPlatform socialPlatform);
    Task<SocialPlatform> DeleteAsync(SocialPlatform socialPlatform, bool permanent = false);
}
