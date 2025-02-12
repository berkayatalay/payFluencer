using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class InfluencerSocial : Entity<Guid>
{
    public string Name { get; set; }
    public string Link { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid SocialId { get; set; }

    public virtual Influencer Influencer { get; set; }
    public virtual SocialPlatform SocialPlatform { get; set; }
}
