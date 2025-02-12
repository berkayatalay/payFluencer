using NArchitecture.Core.Application.Responses;

namespace Application.Features.Reviews.Commands.Update;

public class UpdatedReviewResponse : IResponse
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }
    public Guid GigId { get; set; }
}