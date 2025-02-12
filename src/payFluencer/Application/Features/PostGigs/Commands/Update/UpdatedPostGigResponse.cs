using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostGigs.Commands.Update;

public class UpdatedPostGigResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid GigId { get; set; }
}