using FluentValidation;

namespace Application.Features.Messages.Commands.Update;

public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
{
    public UpdateMessageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.SenderUserId).NotEmpty();
        RuleFor(c => c.RecieverUserId).NotEmpty();
    }
}