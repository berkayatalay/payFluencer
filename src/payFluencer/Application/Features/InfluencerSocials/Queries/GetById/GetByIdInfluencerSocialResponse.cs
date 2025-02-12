using NArchitecture.Core.Application.Responses;

namespace Application.Features.InfluencerSocials.Queries.GetById;

public class GetByIdInfluencerSocialResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid SocialId { get; set; }
}