using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InfluencerRepository : EfRepositoryBase<Influencer, Guid, BaseDbContext>, IInfluencerRepository
{
    public InfluencerRepository(BaseDbContext context) : base(context)
    {
    }
}