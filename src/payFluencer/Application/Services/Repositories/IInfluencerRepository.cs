using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInfluencerRepository : IAsyncRepository<Influencer, Guid>, IRepository<Influencer, Guid>
{
}