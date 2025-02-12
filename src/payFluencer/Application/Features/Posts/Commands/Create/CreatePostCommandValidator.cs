using FluentValidation;

namespace Application.Features.Posts.Commands.Create;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Budget).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.SponsorId).NotEmpty();
    }
}