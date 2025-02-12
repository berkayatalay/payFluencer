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

namespace Application.Features.SocialPlatforms.Commands.Create;

public class CreateSocialPlatformCommand : IRequest<CreatedSocialPlatformResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string Link { get; set; }
    public required string LogoPicture { get; set; }

    public string[] Roles => [Admin, Write, SocialPlatformsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSocialPlatforms"];

    public class CreateSocialPlatformCommandHandler : IRequestHandler<CreateSocialPlatformCommand, CreatedSocialPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialPlatformRepository _socialPlatformRepository;
        private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

        public CreateSocialPlatformCommandHandler(IMapper mapper, ISocialPlatformRepository socialPlatformRepository,
                                         SocialPlatformBusinessRules socialPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialPlatformRepository = socialPlatformRepository;
            _socialPlatformBusinessRules = socialPlatformBusinessRules;
        }

        public async Task<CreatedSocialPlatformResponse> Handle(CreateSocialPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialPlatform socialPlatform = _mapper.Map<SocialPlatform>(request);

            await _socialPlatformRepository.AddAsync(socialPlatform);

            CreatedSocialPlatformResponse response = _mapper.Map<CreatedSocialPlatformResponse>(socialPlatform);
            return response;
        }
    }
}