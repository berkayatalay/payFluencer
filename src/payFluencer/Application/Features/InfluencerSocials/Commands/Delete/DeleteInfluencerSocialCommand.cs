using Application.Features.InfluencerSocials.Constants;
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

namespace Application.Features.InfluencerSocials.Commands.Delete;

public class DeleteInfluencerSocialCommand : IRequest<DeletedInfluencerSocialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, InfluencerSocialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencerSocials"];

    public class DeleteInfluencerSocialCommandHandler : IRequestHandler<DeleteInfluencerSocialCommand, DeletedInfluencerSocialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerSocialRepository _influencerSocialRepository;
        private readonly InfluencerSocialBusinessRules _influencerSocialBusinessRules;

        public DeleteInfluencerSocialCommandHandler(IMapper mapper, IInfluencerSocialRepository influencerSocialRepository,
                                         InfluencerSocialBusinessRules influencerSocialBusinessRules)
        {
            _mapper = mapper;
            _influencerSocialRepository = influencerSocialRepository;
            _influencerSocialBusinessRules = influencerSocialBusinessRules;
        }

        public async Task<DeletedInfluencerSocialResponse> Handle(DeleteInfluencerSocialCommand request, CancellationToken cancellationToken)
        {
            InfluencerSocial? influencerSocial = await _influencerSocialRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerSocialBusinessRules.InfluencerSocialShouldExistWhenSelected(influencerSocial);

            await _influencerSocialRepository.DeleteAsync(influencerSocial!);

            DeletedInfluencerSocialResponse response = _mapper.Map<DeletedInfluencerSocialResponse>(influencerSocial);
            return response;
        }
    }
}