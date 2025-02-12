using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SponsorReviews.Queries.GetList;

public class GetListSponsorReviewListItemDto : IDto
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid SponsorId { get; set; }
    public Guid InfluencerId { get; set; }
    public Guid GigId { get; set; }
}