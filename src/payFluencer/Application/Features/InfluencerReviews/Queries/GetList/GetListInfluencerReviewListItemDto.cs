using NArchitecture.Core.Application.Dtos;

namespace Application.Features.InfluencerReviews.Queries.GetList;

public class GetListInfluencerReviewListItemDto : IDto
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid SponsorId { get; set; }
    public Guid GigId { get; set; }
}