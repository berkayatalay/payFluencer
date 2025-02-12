using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class InfluencerReview : Entity<Guid>
{
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid SponsorId { get; set; } // MadeBy
    public Guid GigId { get; set; }

    public virtual Influencer Influencer { get; set; }
    public virtual Gig Gig { get; set; }

}
