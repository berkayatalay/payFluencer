using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Influencer : IEntity<Guid>
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
