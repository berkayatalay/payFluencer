using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialPlatforms.Queries.GetById;

public class GetByIdSocialPlatformResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public string LogoPicture { get; set; }
}