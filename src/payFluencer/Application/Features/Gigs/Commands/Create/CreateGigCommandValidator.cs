using FluentValidation;

namespace Application.Features.Gigs.Commands.Create;

public class CreateGigCommandValidator : AbstractValidator<CreateGigCommand>
{
    public CreateGigCommandValidator()
    {
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