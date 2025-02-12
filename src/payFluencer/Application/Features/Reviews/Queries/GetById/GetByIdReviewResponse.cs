using NArchitecture.Core.Application.Responses;

namespace Application.Features.Reviews.Queries.GetById;

public class GetByIdReviewResponse : IResponse
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid GigId { get; set; }
}