using Application.Features.Disputes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Disputes.Rules;

public class DisputeBusinessRules : BaseBusinessRules
{
    private readonly IDisputeRepository _disputeRepository;
    private readonly ILocalizationService _localizationService;

    public DisputeBusinessRules(IDisputeRepository disputeRepository, ILocalizationService localizationService)
    {
        _disputeRepository = disputeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DisputesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DisputeShouldExistWhenSelected(Dispute? dispute)
    {
        if (dispute == null)
            await throwBusinessException(DisputesBusinessMessages.DisputeNotExists);
    }

    public async Task DisputeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Dispute? dispute = await _disputeRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DisputeShouldExistWhenSelected(dispute);
    }
}