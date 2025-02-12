using NArchitecture.Core.Application.Responses;

namespace Application.Features.Disputes.Queries.GetById;

public class GetByIdDisputeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public Guid GigId { get; set; }
}