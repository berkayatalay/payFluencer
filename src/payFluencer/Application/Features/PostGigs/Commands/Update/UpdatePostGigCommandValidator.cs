using FluentValidation;

namespace Application.Features.PostGigs.Commands.Update;

public class UpdatePostGigCommandValidator : AbstractValidator<UpdatePostGigCommand>
{
    public UpdatePostGigCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PostId).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}