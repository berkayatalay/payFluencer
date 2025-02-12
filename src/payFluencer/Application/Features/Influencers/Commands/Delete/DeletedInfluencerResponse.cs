using NArchitecture.Core.Application.Responses;

namespace Application.Features.Influencers.Commands.Delete;

public class DeletedInfluencerResponse : IResponse
{
    public Guid Id { get; set; }
}