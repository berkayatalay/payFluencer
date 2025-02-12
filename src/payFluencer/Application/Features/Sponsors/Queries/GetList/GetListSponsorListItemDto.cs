using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Sponsors.Queries.GetList;

public class GetListSponsorListItemDto : IDto
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