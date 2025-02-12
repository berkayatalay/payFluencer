using Application.Features.SocialPlatforms.Constants;
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

namespace Application.Features.SocialPlatforms.Commands.Delete;

public class DeleteSocialPlatformCommand : IRequest<DeletedSocialPlatformResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, SocialPlatformsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSocialPlatforms"];

    public class DeleteSocialPlatformCommandHandler : IRequestHandler<DeleteSocialPlatformCommand, DeletedSocialPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialPlatformRepository _socialPlatformRepository;
        private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

        public DeleteSocialPlatformCommandHandler(IMapper mapper, ISocialPlatformRepository socialPlatformRepository,
                                         SocialPlatformBusinessRules socialPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialPlatformRepository = socialPlatformRepository;
            _socialPlatformBusinessRules = socialPlatformBusinessRules;
        }

        public async Task<DeletedSocialPlatformResponse> Handle(DeleteSocialPlatformCommand request, CancellationToken cancellationToken)
        {
            SocialPlatform? socialPlatform = await _socialPlatformRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _socialPlatformBusinessRules.SocialPlatformShouldExistWhenSelected(socialPlatform);

            await _socialPlatformRepository.DeleteAsync(socialPlatform!);

            DeletedSocialPlatformResponse response = _mapper.Map<DeletedSocialPlatformResponse>(socialPlatform);
            return response;
        }
    }
}