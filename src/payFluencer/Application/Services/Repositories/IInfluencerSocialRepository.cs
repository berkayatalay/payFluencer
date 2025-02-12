using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInfluencerSocialRepository : IAsyncRepository<InfluencerSocial, Guid>, IRepository<InfluencerSocial, Guid>
{
}