using FluentValidation;

namespace Application.Features.PostGigs.Commands.Delete;

public class DeletePostGigCommandValidator : AbstractValidator<DeletePostGigCommand>
{
    public DeletePostGigCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}