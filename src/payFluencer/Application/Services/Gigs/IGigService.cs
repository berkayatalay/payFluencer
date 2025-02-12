using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Gigs;

public interface IGigService
{
    Task<Gig?> GetAsync(
        Expression<Func<Gig, bool>> predicate,
        Func<IQueryable<Gig>, IIncludableQueryable<Gig, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Gig>?> GetListAsync(
        Expression<Func<Gig, bool>>? predicate = null,
        Func<IQueryable<Gig>, IOrderedQueryable<Gig>>? orderBy = null,
        Func<IQueryable<Gig>, IIncludableQueryable<Gig, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Gig> AddAsync(Gig gig);
    Task<Gig> UpdateAsync(Gig gig);
    Task<Gig> DeleteAsync(Gig gig, bool permanent = false);
}
