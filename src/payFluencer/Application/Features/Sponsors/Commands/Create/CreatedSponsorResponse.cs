using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sponsors.Commands.Create;

public class CreatedSponsorResponse : IResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public string ProfilePicture { get; set; }
    public string About { get; set; }
    public double Rating { get; set; }
    public Guid UserId { get; set; }
}