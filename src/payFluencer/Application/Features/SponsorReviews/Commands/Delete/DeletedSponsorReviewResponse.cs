using NArchitecture.Core.Application.Responses;

namespace Application.Features.SponsorReviews.Commands.Delete;

public class DeletedSponsorReviewResponse : IResponse
{
    public Guid Id { get; set; }
}