using NArchitecture.Core.Application.Responses;

namespace Application.Features.Disputes.Commands.Delete;

public class DeletedDisputeResponse : IResponse
{
    public Guid Id { get; set; }
}