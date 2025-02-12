using FluentValidation;

namespace Application.Features.Reviews.Commands.Create;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}