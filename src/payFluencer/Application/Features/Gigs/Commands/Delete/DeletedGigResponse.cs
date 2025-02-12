using NArchitecture.Core.Application.Responses;

namespace Application.Features.Gigs.Commands.Delete;

public class DeletedGigResponse : IResponse
{
    public Guid Id { get; set; }
}