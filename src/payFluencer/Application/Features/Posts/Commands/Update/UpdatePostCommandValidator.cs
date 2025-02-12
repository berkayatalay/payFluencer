using FluentValidation;

namespace Application.Features.Posts.Commands.Update;

public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
{
    public UpdatePostCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Budget).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.SponsorId).NotEmpty();
    }
}