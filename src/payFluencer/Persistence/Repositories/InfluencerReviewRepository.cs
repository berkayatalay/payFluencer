using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InfluencerReviewRepository : EfRepositoryBase<InfluencerReview, Guid, BaseDbContext>, IInfluencerReviewRepository
{
    public InfluencerReviewRepository(BaseDbContext context) : base(context)
    {
    }
}