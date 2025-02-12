using Application.Features.InfluencerSocials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.InfluencerSocials.Rules;

public class InfluencerSocialBusinessRules : BaseBusinessRules
{
    private readonly IInfluencerSocialRepository _influencerSocialRepository;
    private readonly ILocalizationService _localizationService;

    public InfluencerSocialBusinessRules(IInfluencerSocialRepository influencerSocialRepository, ILocalizationService localizationService)
    {
        _influencerSocialRepository = influencerSocialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InfluencerSocialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InfluencerSocialShouldExistWhenSelected(InfluencerSocial? influencerSocial)
    {
        if (influencerSocial == null)
            await throwBusinessException(InfluencerSocialsBusinessMessages.InfluencerSocialNotExists);
    }

    public async Task InfluencerSocialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        InfluencerSocial? influencerSocial = await _influencerSocialRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InfluencerSocialShouldExistWhenSelected(influencerSocial);
    }
}