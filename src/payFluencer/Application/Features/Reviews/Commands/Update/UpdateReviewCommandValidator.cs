using FluentValidation;

namespace Application.Features.Reviews.Commands.Update;

public class UpdateReviewCommandValidator : AbstractValidator<UpdateReviewCommand>
{
    public UpdateReviewCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}