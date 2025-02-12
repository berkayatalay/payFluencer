using FluentValidation;

namespace Application.Features.SupportTickets.Commands.Create;

public class CreateSupportTicketCommandValidator : AbstractValidator<CreateSupportTicketCommand>
{
    public CreateSupportTicketCommandValidator()
    {
        RuleFor(c => c.Category).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}