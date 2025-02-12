using FluentValidation;

namespace Application.Features.InfluencerReviews.Commands.Update;

public class UpdateInfluencerReviewCommandValidator : AbstractValidator<UpdateInfluencerReviewCommand>
{
    public UpdateInfluencerReviewCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.InfluencerId).NotEmpty();
        RuleFor(c => c.SponsorId).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}