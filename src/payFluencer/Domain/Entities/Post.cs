using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Post : Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Budget { get; set; }
    public string Status { get; set; } // Open or NOT?
    public Guid SponsorId { get; set; }

    public virtual Sponsor Sponsor { get; set; }
    public virtual ICollection<PostGig> PostGigs { get; set; }

}