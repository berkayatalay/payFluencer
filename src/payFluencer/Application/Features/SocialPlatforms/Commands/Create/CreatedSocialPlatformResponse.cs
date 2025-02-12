using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialPlatforms.Commands.Create;

public class CreatedSocialPlatformResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public string LogoPicture { get; set; }
}