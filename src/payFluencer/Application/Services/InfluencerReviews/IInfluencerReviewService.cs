using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InfluencerReviews;

public interface IInfluencerReviewService
{
    Task<InfluencerReview?> GetAsync(
        Expression<Func<InfluencerReview, bool>> predicate,
        Func<IQueryable<InfluencerReview>, IIncludableQueryable<InfluencerReview, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<InfluencerReview>?> GetListAsync(
        Expression<Func<InfluencerReview, bool>>? predicate = null,
        Func<IQueryable<InfluencerReview>, IOrderedQueryable<InfluencerReview>>? orderBy = null,
        Func<IQueryable<InfluencerReview>, IIncludableQueryable<InfluencerReview, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<InfluencerReview> AddAsync(InfluencerReview influencerReview);
    Task<InfluencerReview> UpdateAsync(InfluencerReview influencerReview);
    Task<InfluencerReview> DeleteAsync(InfluencerReview influencerReview, bool permanent = false);
}
