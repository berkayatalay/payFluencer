using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Gig : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string EarnProofLink { get; set; } //
    public string Status { get; set; }
    public Guid SponsorId { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid SponsorReviewId { get; set; }
    public Guid InfluencerReviewId { get; set; }

    public virtual Influencer Influencer { get; set; }
    public virtual Sponsor Sponsor { get; set; }
    public virtual Post Post { get; set; }
    public virtual ICollection<Dispute> Disputes{ get; set; }

}
