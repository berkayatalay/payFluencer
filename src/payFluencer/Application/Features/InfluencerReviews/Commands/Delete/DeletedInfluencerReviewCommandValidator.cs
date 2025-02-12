using FluentValidation;

namespace Application.Features.InfluencerReviews.Commands.Delete;

public class DeleteInfluencerReviewCommandValidator : AbstractValidator<DeleteInfluencerReviewCommand>
{
    public DeleteInfluencerReviewCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}