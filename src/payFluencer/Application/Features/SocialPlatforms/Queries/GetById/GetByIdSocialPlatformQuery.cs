using Application.Features.SocialPlatforms.Constants;
using Application.Features.SocialPlatforms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SocialPlatforms.Constants.SocialPlatformsOperationClaims;

namespace Application.Features.SocialPlatforms.Queries.GetById;

public class GetByIdSocialPlatformQuery : IRequest<GetByIdSocialPlatformResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSocialPlatformQueryHandler : IRequestHandler<GetByIdSocialPlatformQuery, GetByIdSocialPlatformResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialPlatformRepository _socialPlatformRepository;
        private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

        public GetByIdSocialPlatformQueryHandler(IMapper mapper, ISocialPlatformRepository socialPlatformRepository, SocialPlatformBusinessRules socialPlatformBusinessRules)
        {
            _mapper = mapper;
            _socialPlatformRepository = socialPlatformRepository;
            _socialPlatformBusinessRules = socialPlatformBusinessRules;
        }

        public async Task<GetByIdSocialPlatformResponse> Handle(GetByIdSocialPlatformQuery request, CancellationToken cancellationToken)
        {
            SocialPlatform? socialPlatform = await _socialPlatformRepository.GetAsync(predicate: sp => sp.Id == request.Id, cancellationToken: cancellationToken);
            await _socialPlatformBusinessRules.SocialPlatformShouldExistWhenSelected(socialPlatform);

            GetByIdSocialPlatformResponse response = _mapper.Map<GetByIdSocialPlatformResponse>(socialPlatform);
            return response;
        }
    }
}