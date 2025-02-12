using FluentValidation;

namespace Application.Features.PostGigs.Commands.Create;

public class CreatePostGigCommandValidator : AbstractValidator<CreatePostGigCommand>
{
    public CreatePostGigCommandValidator()
    {
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}