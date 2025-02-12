using FluentValidation;

namespace Application.Features.Influencers.Commands.Delete;

public class DeleteInfluencerCommandValidator : AbstractValidator<DeleteInfluencerCommand>
{
    public DeleteInfluencerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}