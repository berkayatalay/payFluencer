using Application.Features.Influencers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Influencers.Rules;

public class InfluencerBusinessRules : BaseBusinessRules
{
    private readonly IInfluencerRepository _influencerRepository;
    private readonly ILocalizationService _localizationService;

    public InfluencerBusinessRules(IInfluencerRepository influencerRepository, ILocalizationService localizationService)
    {
        _influencerRepository = influencerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InfluencersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InfluencerShouldExistWhenSelected(Influencer? influencer)
    {
        if (influencer == null)
            await throwBusinessException(InfluencersBusinessMessages.InfluencerNotExists);
    }

    public async Task InfluencerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Influencer? influencer = await _influencerRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InfluencerShouldExistWhenSelected(influencer);
    }
}