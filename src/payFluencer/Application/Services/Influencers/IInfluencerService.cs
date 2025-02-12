using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Influencers;

public interface IInfluencerService
{
    Task<Influencer?> GetAsync(
        Expression<Func<Influencer, bool>> predicate,
        Func<IQueryable<Influencer>, IIncludableQueryable<Influencer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Influencer>?> GetListAsync(
        Expression<Func<Influencer, bool>>? predicate = null,
        Func<IQueryable<Influencer>, IOrderedQueryable<Influencer>>? orderBy = null,
        Func<IQueryable<Influencer>, IIncludableQueryable<Influencer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Influencer> AddAsync(Influencer influencer);
    Task<Influencer> UpdateAsync(Influencer influencer);
    Task<Influencer> DeleteAsync(Influencer influencer, bool permanent = false);
}
