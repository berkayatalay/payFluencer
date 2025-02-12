using FluentValidation;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommandValidator : AbstractValidator<CreateMessageCommand>
{
    public CreateMessageCommandValidator()
    {
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.SenderUserId).NotEmpty();
        RuleFor(c => c.RecieverUserId).NotEmpty();
    }
}