using FluentValidation;

namespace Application.Features.InfluencerSocials.Commands.Create;

public class CreateInfluencerSocialCommandValidator : AbstractValidator<CreateInfluencerSocialCommand>
{
    public CreateInfluencerSocialCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.InfluencerId).NotEmpty();
        RuleFor(c => c.SocialId).NotEmpty();
    }
}