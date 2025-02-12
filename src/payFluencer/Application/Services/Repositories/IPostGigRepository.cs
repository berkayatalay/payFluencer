using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPostGigRepository : IAsyncRepository<PostGig, Guid>, IRepository<PostGig, Guid>
{
}