using FluentValidation;

namespace Application.Features.Influencers.Commands.Update;

public class UpdateInfluencerCommandValidator : AbstractValidator<UpdateInfluencerCommand>
{
    public UpdateInfluencerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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