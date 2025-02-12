using FluentValidation;

namespace Application.Features.InfluencerSocials.Commands.Delete;

public class DeleteInfluencerSocialCommandValidator : AbstractValidator<DeleteInfluencerSocialCommand>
{
    public DeleteInfluencerSocialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}