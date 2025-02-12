using NArchitecture.Core.Application.Responses;

namespace Application.Features.Disputes.Commands.Create;

public class CreatedDisputeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public Guid GigId { get; set; }
}