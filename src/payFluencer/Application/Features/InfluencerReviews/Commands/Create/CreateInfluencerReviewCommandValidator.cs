using FluentValidation;

namespace Application.Features.InfluencerReviews.Commands.Create;

public class CreateInfluencerReviewCommandValidator : AbstractValidator<CreateInfluencerReviewCommand>
{
    public CreateInfluencerReviewCommandValidator()
    {
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.InfluencerId).NotEmpty();
        RuleFor(c => c.SponsorId).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}