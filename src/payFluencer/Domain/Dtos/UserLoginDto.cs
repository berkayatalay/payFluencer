using NArchitecture.Core.Application.Dtos;

namespace Domain.Dtos;

public class UserLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }
    public UserLoginDto()
    {
        Email = string.Empty;
        Password = string.Empty;
    }
    public UserLoginDto(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
