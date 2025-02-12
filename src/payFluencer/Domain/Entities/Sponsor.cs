using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Sponsor : Entity<Guid>
{
    public string UserName { get; set; }
    public string CompanyName { get; set; }
    public string ProfilePicture { get; set; }
    public string About { get; set; }
    public double Rating { get; set; }
    public Guid UserId { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<Gig> Gigs { get; set; }
    public virtual ICollection<SponsorReview> SponsorReviews { get; set; }

}
