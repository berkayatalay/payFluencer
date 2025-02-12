using FluentValidation;

namespace Application.Features.SocialPlatforms.Commands.Delete;

public class DeleteSocialPlatformCommandValidator : AbstractValidator<DeleteSocialPlatformCommand>
{
    public DeleteSocialPlatformCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}