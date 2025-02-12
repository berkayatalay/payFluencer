using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class SocialPlatform : Entity<int>
{
    public string Name { get; set; }
    public string Link { get; set; }
    public string LogoPicture { get; set; }

    public virtual ICollection<InfluencerSocial> InfluencerSocials { get; set; }
}