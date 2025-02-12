using NArchitecture.Core.Application.Responses;

namespace Application.Features.Gigs.Commands.Update;

public class UpdatedGigResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string EarnProofLink { get; set; }
    public string Status { get; set; }
    public Guid SponsorId { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid SponsorReviewId { get; set; }
    public Guid InfluencerReviewId { get; set; }
}