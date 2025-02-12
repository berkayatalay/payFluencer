using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SponsorReviewRepository : EfRepositoryBase<SponsorReview, Guid, BaseDbContext>, ISponsorReviewRepository
{
    public SponsorReviewRepository(BaseDbContext context) : base(context)
    {
    }
}