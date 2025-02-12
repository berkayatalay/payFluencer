using NArchitecture.Core.Application.Responses;

namespace Application.Features.SponsorReviews.Commands.Create;

public class CreatedSponsorReviewResponse : IResponse
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid SponsorId { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid GigId { get; set; }
}