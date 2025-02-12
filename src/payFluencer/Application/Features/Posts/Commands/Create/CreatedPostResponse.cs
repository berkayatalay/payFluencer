using NArchitecture.Core.Application.Responses;

namespace Application.Features.Posts.Commands.Create;

public class CreatedPostResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Budget { get; set; }
    public string Status { get; set; }
    public Guid SponsorId { get; set; }
}