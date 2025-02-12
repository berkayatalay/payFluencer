using FluentValidation;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.UserLoginDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.UserLoginDto.Password).NotEmpty().MinimumLength(4);
    }
}
