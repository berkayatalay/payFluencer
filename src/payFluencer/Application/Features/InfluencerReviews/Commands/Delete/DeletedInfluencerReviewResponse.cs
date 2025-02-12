using NArchitecture.Core.Application.Responses;

namespace Application.Features.InfluencerReviews.Commands.Delete;

public class DeletedInfluencerReviewResponse : IResponse
{
    public Guid Id { get; set; }
}