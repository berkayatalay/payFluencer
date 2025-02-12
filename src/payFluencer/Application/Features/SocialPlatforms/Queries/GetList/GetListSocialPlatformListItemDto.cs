using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SocialPlatforms.Queries.GetList;

public class GetListSocialPlatformListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public string LogoPicture { get; set; }
}