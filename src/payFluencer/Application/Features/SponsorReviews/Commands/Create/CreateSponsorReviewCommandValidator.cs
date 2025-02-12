using FluentValidation;

namespace Application.Features.SponsorReviews.Commands.Create;

public class CreateSponsorReviewCommandValidator : AbstractValidator<CreateSponsorReviewCommand>
{
    public CreateSponsorReviewCommandValidator()
    {
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
        RuleFor(c => c.SponsorId).NotEmpty();
        RuleFor(c => c.InfluencerId).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}