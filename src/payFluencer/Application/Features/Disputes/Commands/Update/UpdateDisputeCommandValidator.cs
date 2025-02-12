using FluentValidation;

namespace Application.Features.Disputes.Commands.Update;

public class UpdateDisputeCommandValidator : AbstractValidator<UpdateDisputeCommand>
{
    public UpdateDisputeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.GigId).NotEmpty();
    }
}