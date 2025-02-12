using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InfluencerSocials;

public interface IInfluencerSocialService
{
    Task<InfluencerSocial?> GetAsync(
        Expression<Func<InfluencerSocial, bool>> predicate,
        Func<IQueryable<InfluencerSocial>, IIncludableQueryable<InfluencerSocial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<InfluencerSocial>?> GetListAsync(
        Expression<Func<InfluencerSocial, bool>>? predicate = null,
        Func<IQueryable<InfluencerSocial>, IOrderedQueryable<InfluencerSocial>>? orderBy = null,
        Func<IQueryable<InfluencerSocial>, IIncludableQueryable<InfluencerSocial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<InfluencerSocial> AddAsync(InfluencerSocial influencerSocial);
    Task<InfluencerSocial> UpdateAsync(InfluencerSocial influencerSocial);
    Task<InfluencerSocial> DeleteAsync(InfluencerSocial influencerSocial, bool permanent = false);
}
