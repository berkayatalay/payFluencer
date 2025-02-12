using FluentValidation;

namespace Application.Features.SupportTickets.Commands.Update;

public class UpdateSupportTicketCommandValidator : AbstractValidator<UpdateSupportTicketCommand>
{
    public UpdateSupportTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Category).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}