using Application.Features.SocialPlatforms.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SocialPlatforms;

public class SocialPlatformManager : ISocialPlatformService
{
    private readonly ISocialPlatformRepository _socialPlatformRepository;
    private readonly SocialPlatformBusinessRules _socialPlatformBusinessRules;

    public SocialPlatformManager(ISocialPlatformRepository socialPlatformRepository, SocialPlatformBusinessRules socialPlatformBusinessRules)
    {
        _socialPlatformRepository = socialPlatformRepository;
        _socialPlatformBusinessRules = socialPlatformBusinessRules;
    }

    public async Task<SocialPlatform?> GetAsync(
        Expression<Func<SocialPlatform, bool>> predicate,
        Func<IQueryable<SocialPlatform>, IIncludableQueryable<SocialPlatform, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SocialPlatform? socialPlatform = await _socialPlatformRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return socialPlatform;
    }

    public async Task<IPaginate<SocialPlatform>?> GetListAsync(
        Expression<Func<SocialPlatform, bool>>? predicate = null,
        Func<IQueryable<SocialPlatform>, IOrderedQueryable<SocialPlatform>>? orderBy = null,
        Func<IQueryable<SocialPlatform>, IIncludableQueryable<SocialPlatform, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SocialPlatform> socialPlatformList = await _socialPlatformRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return socialPlatformList;
    }

    public async Task<SocialPlatform> AddAsync(SocialPlatform socialPlatform)
    {
        SocialPlatform addedSocialPlatform = await _socialPlatformRepository.AddAsync(socialPlatform);

        return addedSocialPlatform;
    }

    public async Task<SocialPlatform> UpdateAsync(SocialPlatform socialPlatform)
    {
        SocialPlatform updatedSocialPlatform = await _socialPlatformRepository.UpdateAsync(socialPlatform);

        return updatedSocialPlatform;
    }

    public async Task<SocialPlatform> DeleteAsync(SocialPlatform socialPlatform, bool permanent = false)
    {
        SocialPlatform deletedSocialPlatform = await _socialPlatformRepository.DeleteAsync(socialPlatform);

        return deletedSocialPlatform;
    }
}
