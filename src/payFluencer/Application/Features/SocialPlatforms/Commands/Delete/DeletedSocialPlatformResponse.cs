using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialPlatforms.Commands.Delete;

public class DeletedSocialPlatformResponse : IResponse
{
    public int Id { get; set; }
}