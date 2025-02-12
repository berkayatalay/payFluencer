using FluentValidation;

namespace Application.Features.Gigs.Commands.Delete;

public class DeleteGigCommandValidator : AbstractValidator<DeleteGigCommand>
{
    public DeleteGigCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}