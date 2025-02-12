using FluentValidation;

namespace Application.Features.Disputes.Commands.Delete;

public class DeleteDisputeCommandValidator : AbstractValidator<DeleteDisputeCommand>
{
    public DeleteDisputeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}