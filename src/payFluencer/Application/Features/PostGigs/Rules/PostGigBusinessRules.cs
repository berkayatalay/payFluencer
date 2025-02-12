using Application.Features.PostGigs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PostGigs.Rules;

public class PostGigBusinessRules : BaseBusinessRules
{
    private readonly IPostGigRepository _postGigRepository;
    private readonly ILocalizationService _localizationService;

    public PostGigBusinessRules(IPostGigRepository postGigRepository, ILocalizationService localizationService)
    {
        _postGigRepository = postGigRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PostGigsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PostGigShouldExistWhenSelected(PostGig? postGig)
    {
        if (postGig == null)
            await throwBusinessException(PostGigsBusinessMessages.PostGigNotExists);
    }

    public async Task PostGigIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PostGig? postGig = await _postGigRepository.GetAsync(
            predicate: pg => pg.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PostGigShouldExistWhenSelected(postGig);
    }
}