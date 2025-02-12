using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Reviews.Queries.GetList;

public class GetListReviewListItemDto : IDto
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid GigId { get; set; }
}