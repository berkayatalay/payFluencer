using FluentValidation;

namespace Application.Features.Disputes.Commands.Create;

public class CreateDisputeCommandValidator : AbstractValidator<CreateDisputeCommand>
{
    public CreateDisputeCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}