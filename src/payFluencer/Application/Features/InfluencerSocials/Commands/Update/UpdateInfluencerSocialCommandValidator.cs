using FluentValidation;

namespace Application.Features.InfluencerSocials.Commands.Update;

public class UpdateInfluencerSocialCommandValidator : AbstractValidator<UpdateInfluencerSocialCommand>
{
    public UpdateInfluencerSocialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Link).NotEmpty();
        RuleFor(c => c.InfluencerId).NotEmpty();
        RuleFor(c => c.SocialId).NotEmpty();
    }
}