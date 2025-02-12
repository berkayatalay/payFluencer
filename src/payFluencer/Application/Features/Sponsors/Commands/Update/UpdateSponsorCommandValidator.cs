using FluentValidation;

namespace Application.Features.Sponsors.Commands.Update;

public class UpdateSponsorCommandValidator : AbstractValidator<UpdateSponsorCommand>
{
    public UpdateSponsorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserName).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.ProfilePicture).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}