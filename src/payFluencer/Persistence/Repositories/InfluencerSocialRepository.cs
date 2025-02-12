using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InfluencerSocialRepository : EfRepositoryBase<InfluencerSocial, Guid, BaseDbContext>, IInfluencerSocialRepository
{
    public InfluencerSocialRepository(BaseDbContext context) : base(context)
    {
    }
}