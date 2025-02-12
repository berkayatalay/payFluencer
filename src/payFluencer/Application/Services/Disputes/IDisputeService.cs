using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Disputes;

public interface IDisputeService
{
    Task<Dispute?> GetAsync(
        Expression<Func<Dispute, bool>> predicate,
        Func<IQueryable<Dispute>, IIncludableQueryable<Dispute, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Dispute>?> GetListAsync(
        Expression<Func<Dispute, bool>>? predicate = null,
        Func<IQueryable<Dispute>, IOrderedQueryable<Dispute>>? orderBy = null,
        Func<IQueryable<Dispute>, IIncludableQueryable<Dispute, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Dispute> AddAsync(Dispute dispute);
    Task<Dispute> UpdateAsync(Dispute dispute);
    Task<Dispute> DeleteAsync(Dispute dispute, bool permanent = false);
}
