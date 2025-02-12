using NArchitecture.Core.Application.Responses;

namespace Application.Features.InfluencerSocials.Commands.Delete;

public class DeletedInfluencerSocialResponse : IResponse
{
    public Guid Id { get; set; }
}