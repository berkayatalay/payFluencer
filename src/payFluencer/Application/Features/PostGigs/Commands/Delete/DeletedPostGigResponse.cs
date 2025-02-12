using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostGigs.Commands.Delete;

public class DeletedPostGigResponse : IResponse
{
    public Guid Id { get; set; }
}