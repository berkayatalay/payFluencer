using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Dispute : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public Guid GigId { get; set; }

    public virtual Gig Gig{ get; set; }
}
