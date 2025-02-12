using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGigRepository : IAsyncRepository<Gig, Guid>, IRepository<Gig, Guid>
{
}