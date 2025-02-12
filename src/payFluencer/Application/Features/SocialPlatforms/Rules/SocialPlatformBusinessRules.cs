using Application.Features.SocialPlatforms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SocialPlatforms.Rules;

public class SocialPlatformBusinessRules : BaseBusinessRules
{
    private readonly ISocialPlatformRepository _socialPlatformRepository;
    private readonly ILocalizationService _localizationService;

    public SocialPlatformBusinessRules(ISocialPlatformRepository socialPlatformRepository, ILocalizationService localizationService)
    {
        _socialPlatformRepository = socialPlatformRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SocialPlatformsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SocialPlatformShouldExistWhenSelected(SocialPlatform? socialPlatform)
    {
        if (socialPlatform == null)
            await throwBusinessException(SocialPlatformsBusinessMessages.SocialPlatformNotExists);
    }

    public async Task SocialPlatformIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SocialPlatform? socialPlatform = await _socialPlatformRepository.GetAsync(
            predicate: sp => sp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SocialPlatformShouldExistWhenSelected(socialPlatform);
    }
}