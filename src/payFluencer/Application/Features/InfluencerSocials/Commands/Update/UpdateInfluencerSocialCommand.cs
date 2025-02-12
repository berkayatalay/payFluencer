using Application.Features.InfluencerSocials.Constants;
using Application.Features.InfluencerSocials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.InfluencerSocials.Constants.InfluencerSocialsOperationClaims;

namespace Application.Features.InfluencerSocials.Commands.Update;

public class UpdateInfluencerSocialCommand : IRequest<UpdatedInfluencerSocialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Link { get; set; }
    public required Guid InfluencerId { get; set; }
    public required Guid SocialId { get; set; }

    public string[] Roles => [Admin, Write, InfluencerSocialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencerSocials"];

    public class UpdateInfluencerSocialCommandHandler : IRequestHandler<UpdateInfluencerSocialCommand, UpdatedInfluencerSocialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerSocialRepository _influencerSocialRepository;
        private readonly InfluencerSocialBusinessRules _influencerSocialBusinessRules;

        public UpdateInfluencerSocialCommandHandler(IMapper mapper, IInfluencerSocialRepository influencerSocialRepository,
                                         InfluencerSocialBusinessRules influencerSocialBusinessRules)
        {
            _mapper = mapper;
            _influencerSocialRepository = influencerSocialRepository;
            _influencerSocialBusinessRules = influencerSocialBusinessRules;
        }

        public async Task<UpdatedInfluencerSocialResponse> Handle(UpdateInfluencerSocialCommand request, CancellationToken cancellationToken)
        {
            InfluencerSocial? influencerSocial = await _influencerSocialRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerSocialBusinessRules.InfluencerSocialShouldExistWhenSelected(influencerSocial);
            influencerSocial = _mapper.Map(request, influencerSocial);

            await _influencerSocialRepository.UpdateAsync(influencerSocial!);

            UpdatedInfluencerSocialResponse response = _mapper.Map<UpdatedInfluencerSocialResponse>(influencerSocial);
            return response;
        }
    }
}