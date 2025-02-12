using FluentValidation;

namespace Application.Features.SponsorReviews.Commands.Delete;

public class DeleteSponsorReviewCommandValidator : AbstractValidator<DeleteSponsorReviewCommand>
{
    public DeleteSponsorReviewCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}