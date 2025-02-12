using FluentValidation;

namespace Application.Features.SocialPlatforms.Commands.Create;

public class CreateSocialPlatformCommandValidator : AbstractValidator<CreateSocialPlatformCommand>
{
    public CreateSocialPlatformCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.LogoPicture).NotEmpty();
    }
}