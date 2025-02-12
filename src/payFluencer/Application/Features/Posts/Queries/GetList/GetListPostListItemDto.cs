using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Posts.Queries.GetList;

public class GetListPostListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Budget { get; set; }
    public string Status { get; set; }
    public Guid SponsorId { get; set; }
}