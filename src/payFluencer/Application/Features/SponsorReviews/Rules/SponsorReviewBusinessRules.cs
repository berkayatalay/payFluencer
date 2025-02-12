using Application.Features.SponsorReviews.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SponsorReviews.Rules;

public class SponsorReviewBusinessRules : BaseBusinessRules
{
    private readonly ISponsorReviewRepository _sponsorReviewRepository;
    private readonly ILocalizationService _localizationService;

    public SponsorReviewBusinessRules(ISponsorReviewRepository sponsorReviewRepository, ILocalizationService localizationService)
    {
        _sponsorReviewRepository = sponsorReviewRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SponsorReviewsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SponsorReviewShouldExistWhenSelected(SponsorReview? sponsorReview)
    {
        if (sponsorReview == null)
            await throwBusinessException(SponsorReviewsBusinessMessages.SponsorReviewNotExists);
    }

    public async Task SponsorReviewIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SponsorReview? sponsorReview = await _sponsorReviewRepository.GetAsync(
            predicate: sr => sr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SponsorReviewShouldExistWhenSelected(sponsorReview);
    }
}