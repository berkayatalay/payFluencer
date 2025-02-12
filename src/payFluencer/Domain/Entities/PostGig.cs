using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class PostGig : Entity<Guid>
{
    public Guid PostId { get; set; }
    public Guid GigId { get; set; }

    public virtual Post Post { get; set; }
    public virtual Gig Gig { get; set; }
}
