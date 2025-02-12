using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostGigs;

public interface IPostGigService
{
    Task<PostGig?> GetAsync(
        Expression<Func<PostGig, bool>> predicate,
        Func<IQueryable<PostGig>, IIncludableQueryable<PostGig, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PostGig>?> GetListAsync(
        Expression<Func<PostGig, bool>>? predicate = null,
        Func<IQueryable<PostGig>, IOrderedQueryable<PostGig>>? orderBy = null,
        Func<IQueryable<PostGig>, IIncludableQueryable<PostGig, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PostGig> AddAsync(PostGig postGig);
    Task<PostGig> UpdateAsync(PostGig postGig);
    Task<PostGig> DeleteAsync(PostGig postGig, bool permanent = false);
}
