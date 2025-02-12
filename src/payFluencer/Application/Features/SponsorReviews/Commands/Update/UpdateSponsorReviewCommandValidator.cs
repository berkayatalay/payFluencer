using FluentValidation;

namespace Application.Features.SponsorReviews.Commands.Update;

public class UpdateSponsorReviewCommandValidator : AbstractValidator<UpdateSponsorReviewCommand>
{
    public UpdateSponsorReviewCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.SponsorId).NotEmpty();
        RuleFor(c => c.InfluencerId).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}