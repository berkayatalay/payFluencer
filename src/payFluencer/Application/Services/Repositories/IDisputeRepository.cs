using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDisputeRepository : IAsyncRepository<Dispute, Guid>, IRepository<Dispute, Guid>
{
}