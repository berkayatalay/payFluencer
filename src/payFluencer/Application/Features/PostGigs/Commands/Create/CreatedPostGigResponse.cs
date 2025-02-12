using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostGigs.Commands.Create;

public class CreatedPostGigResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid GigId { get; set; }
}