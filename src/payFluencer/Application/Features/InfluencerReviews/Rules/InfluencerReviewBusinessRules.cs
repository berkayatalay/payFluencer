using Application.Features.InfluencerReviews.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.InfluencerReviews.Rules;

public class InfluencerReviewBusinessRules : BaseBusinessRules
{
    private readonly IInfluencerReviewRepository _influencerReviewRepository;
    private readonly ILocalizationService _localizationService;

    public InfluencerReviewBusinessRules(IInfluencerReviewRepository influencerReviewRepository, ILocalizationService localizationService)
    {
        _influencerReviewRepository = influencerReviewRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, InfluencerReviewsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task InfluencerReviewShouldExistWhenSelected(InfluencerReview? influencerReview)
    {
        if (influencerReview == null)
            await throwBusinessException(InfluencerReviewsBusinessMessages.InfluencerReviewNotExists);
    }

    public async Task InfluencerReviewIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        InfluencerReview? influencerReview = await _influencerReviewRepository.GetAsync(
            predicate: ir => ir.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InfluencerReviewShouldExistWhenSelected(influencerReview);
    }
}