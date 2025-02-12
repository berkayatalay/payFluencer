using Application.Features.Gigs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Gigs.Rules;

public class GigBusinessRules : BaseBusinessRules
{
    private readonly IGigRepository _gigRepository;
    private readonly ILocalizationService _localizationService;

    public GigBusinessRules(IGigRepository gigRepository, ILocalizationService localizationService)
    {
        _gigRepository = gigRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GigsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GigShouldExistWhenSelected(Gig? gig)
    {
        if (gig == null)
            await throwBusinessException(GigsBusinessMessages.GigNotExists);
    }

    public async Task GigIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Gig? gig = await _gigRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GigShouldExistWhenSelected(gig);
    }
}