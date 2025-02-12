using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SponsorReviews;

public interface ISponsorReviewService
{
    Task<SponsorReview?> GetAsync(
        Expression<Func<SponsorReview, bool>> predicate,
        Func<IQueryable<SponsorReview>, IIncludableQueryable<SponsorReview, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SponsorReview>?> GetListAsync(
        Expression<Func<SponsorReview, bool>>? predicate = null,
        Func<IQueryable<SponsorReview>, IOrderedQueryable<SponsorReview>>? orderBy = null,
        Func<IQueryable<SponsorReview>, IIncludableQueryable<SponsorReview, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SponsorReview> AddAsync(SponsorReview sponsorReview);
    Task<SponsorReview> UpdateAsync(SponsorReview sponsorReview);
    Task<SponsorReview> DeleteAsync(SponsorReview sponsorReview, bool permanent = false);
}
