using FluentValidation;

namespace Application.Features.Gigs.Commands.Update;

public class UpdateGigCommandValidator : AbstractValidator<UpdateGigCommand>
{
    public UpdateGigCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.EarnProofLink).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.SponsorId).NotEmpty();
        RuleFor(c => c.InfluencerId).NotEmpty();
        RuleFor(c => c.SponsorReviewId).NotEmpty();
        RuleFor(c => c.InfluencerReviewId).NotEmpty();
    }
}