using FluentValidation;

namespace Application.Features.Influencers.Commands.Create;

public class CreateInfluencerCommandValidator : AbstractValidator<CreateInfluencerCommand>
{
    public CreateInfluencerCommandValidator()
    {
        RuleFor(c => c.UserName).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Surname).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.ProfilePicture).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}