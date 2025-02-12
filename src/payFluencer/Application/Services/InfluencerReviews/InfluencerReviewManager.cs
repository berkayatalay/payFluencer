using Application.Features.InfluencerReviews.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InfluencerReviews;

public class InfluencerReviewManager : IInfluencerReviewService
{
    private readonly IInfluencerReviewRepository _influencerReviewRepository;
    private readonly InfluencerReviewBusinessRules _influencerReviewBusinessRules;

    public InfluencerReviewManager(IInfluencerReviewRepository influencerReviewRepository, InfluencerReviewBusinessRules influencerReviewBusinessRules)
    {
        _influencerReviewRepository = influencerReviewRepository;
        _influencerReviewBusinessRules = influencerReviewBusinessRules;
    }

    public async Task<InfluencerReview?> GetAsync(
        Expression<Func<InfluencerReview, bool>> predicate,
        Func<IQueryable<InfluencerReview>, IIncludableQueryable<InfluencerReview, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        InfluencerReview? influencerReview = await _influencerReviewRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return influencerReview;
    }

    public async Task<IPaginate<InfluencerReview>?> GetListAsync(
        Expression<Func<InfluencerReview, bool>>? predicate = null,
        Func<IQueryable<InfluencerReview>, IOrderedQueryable<InfluencerReview>>? orderBy = null,
        Func<IQueryable<InfluencerReview>, IIncludableQueryable<InfluencerReview, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<InfluencerReview> influencerReviewList = await _influencerReviewRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return influencerReviewList;
    }

    public async Task<InfluencerReview> AddAsync(InfluencerReview influencerReview)
    {
        InfluencerReview addedInfluencerReview = await _influencerReviewRepository.AddAsync(influencerReview);

        return addedInfluencerReview;
    }

    public async Task<InfluencerReview> UpdateAsync(InfluencerReview influencerReview)
    {
        InfluencerReview updatedInfluencerReview = await _influencerReviewRepository.UpdateAsync(influencerReview);

        return updatedInfluencerReview;
    }

    public async Task<InfluencerReview> DeleteAsync(InfluencerReview influencerReview, bool permanent = false)
    {
        InfluencerReview deletedInfluencerReview = await _influencerReviewRepository.DeleteAsync(influencerReview);

        return deletedInfluencerReview;
    }
}
