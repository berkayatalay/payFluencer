using Application.Features.SocialPlatforms.Constants;
using Application.Features.SocialPlatforms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SocialPlatforms.Constants.SocialPlatformsOperationClaims;

namespace Application.Features.SocialPlatforms.Commands.Update;

public class UpdateSocialPlatformCommand : IRequest<UpdatedSocialPlatformResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Link { get; set; }
    public required string LogoPicture { get; set; }

    public string[] Roles => [Admin, Write, SocialPlatformsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSocialPlatforms"];

    public class UpdateSocialPlatformCommandHandler : IRequestHandler<UpdateSocialPlatformCommand, UpdatedSocialPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialPlatformRepository _socialPlatformRepository;
        private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

        public UpdateSocialPlatformCommandHandler(IMapper mapper, ISocialPlatformRepository socialPlatformRepository,
                                         SocialPlatformBusinessRules socialPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialPlatformRepository = socialPlatformRepository;
            _socialPlatformBusinessRules = socialPlatformBusinessRules;
        }

        public async Task<UpdatedSocialPlatformResponse> Handle(UpdateSocialPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialPlatform? socialPlatform = await _socialPlatformRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _socialPlatformBusinessRules.SocialPlatformShouldExistWhenSelected(socialPlatform);
            socialPlatform = _mapper.Map(request, socialPlatform);

            await _socialPlatformRepository.UpdateAsync(socialPlatform!);

            UpdatedSocialPlatformResponse response = _mapper.Map<UpdatedSocialPlatformResponse>(socialPlatform);
            return response;
        }
    }
}