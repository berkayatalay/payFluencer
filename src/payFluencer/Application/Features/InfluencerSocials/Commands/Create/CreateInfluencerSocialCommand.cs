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

namespace Application.Features.InfluencerSocials.Commands.Create;

public class CreateInfluencerSocialCommand : IRequest<CreatedInfluencerSocialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string Link { get; set; }
    public required Guid InfluencerId { get; set; }
    public required Guid SocialId { get; set; }

    public string[] Roles => [Admin, Write, InfluencerSocialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencerSocials"];

    public class CreateInfluencerSocialCommandHandler : IRequestHandler<CreateInfluencerSocialCommand, CreatedInfluencerSocialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerSocialRepository _influencerSocialRepository;
        private readonly InfluencerSocialBusinessRules _influencerSocialBusinessRules;

        public CreateInfluencerSocialCommandHandler(IMapper mapper, IInfluencerSocialRepository influencerSocialRepository,
                                         InfluencerSocialBusinessRules influencerSocialBusinessRules)
        {
            _mapper = mapper;
            _influencerSocialRepository = influencerSocialRepository;
            _influencerSocialBusinessRules = influencerSocialBusinessRules;
        }

        public async Task<CreatedInfluencerSocialResponse> Handle(CreateInfluencerSocialCommand request, CancellationToken cancellationToken)
        {
            InfluencerSocial influencerSocial = _mapper.Map<InfluencerSocial>(request);

            await _influencerSocialRepository.AddAsync(influencerSocial);

            CreatedInfluencerSocialResponse response = _mapper.Map<CreatedInfluencerSocialResponse>(influencerSocial);
            return response;
        }
    }
}