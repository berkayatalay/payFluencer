using NArchitecture.Core.Application.Dtos;

namespace Application.Features.InfluencerSocials.Queries.GetList;

public class GetListInfluencerSocialListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid SocialId { get; set; }
}