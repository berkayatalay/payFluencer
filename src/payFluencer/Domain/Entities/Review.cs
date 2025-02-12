using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Review : Entity<Guid>
{
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid GigId { get; set; }
}
