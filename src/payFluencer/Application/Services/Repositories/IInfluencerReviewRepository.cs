using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInfluencerReviewRepository : IAsyncRepository<InfluencerReview, Guid>, IRepository<InfluencerReview, Guid>
{
}