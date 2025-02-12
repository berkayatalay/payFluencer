using Application.Features.SponsorReviews.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SponsorReviews;

public class SponsorReviewManager : ISponsorReviewService
{
    private readonly ISponsorReviewRepository _sponsorReviewRepository;
    private readonly SponsorReviewBusinessRules _sponsorReviewBusinessRules;

    public SponsorReviewManager(ISponsorReviewRepository sponsorReviewRepository, SponsorReviewBusinessRules sponsorReviewBusinessRules)
    {
        _sponsorReviewRepository = sponsorReviewRepository;
        _sponsorReviewBusinessRules = sponsorReviewBusinessRules;
    }

    public async Task<SponsorReview?> GetAsync(
        Expression<Func<SponsorReview, bool>> predicate,
        Func<IQueryable<SponsorReview>, IIncludableQueryable<SponsorReview, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SponsorReview? sponsorReview = await _sponsorReviewRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sponsorReview;
    }

    public async Task<IPaginate<SponsorReview>?> GetListAsync(
        Expression<Func<SponsorReview, bool>>? predicate = null,
        Func<IQueryable<SponsorReview>, IOrderedQueryable<SponsorReview>>? orderBy = null,
        Func<IQueryable<SponsorReview>, IIncludableQueryable<SponsorReview, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SponsorReview> sponsorReviewList = await _sponsorReviewRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sponsorReviewList;
    }

    public async Task<SponsorReview> AddAsync(SponsorReview sponsorReview)
    {
        SponsorReview addedSponsorReview = await _sponsorReviewRepository.AddAsync(sponsorReview);

        return addedSponsorReview;
    }

    public async Task<SponsorReview> UpdateAsync(SponsorReview sponsorReview)
    {
        SponsorReview updatedSponsorReview = await _sponsorReviewRepository.UpdateAsync(sponsorReview);

        return updatedSponsorReview;
    }

    public async Task<SponsorReview> DeleteAsync(SponsorReview sponsorReview, bool permanent = false)
    {
        SponsorReview deletedSponsorReview = await _sponsorReviewRepository.DeleteAsync(sponsorReview);

        return deletedSponsorReview;
    }
}
