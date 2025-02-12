using FluentValidation;

namespace Application.Features.SocialPlatforms.Commands.Update;

public class UpdateSocialPlatformCommandValidator : AbstractValidator<UpdateSocialPlatformCommand>
{
    public UpdateSocialPlatformCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.LogoPicture).NotEmpty();
    }
}