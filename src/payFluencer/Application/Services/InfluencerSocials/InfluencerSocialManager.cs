using Application.Features.InfluencerSocials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.InfluencerSocials;

public class InfluencerSocialManager : IInfluencerSocialService
{
    private readonly IInfluencerSocialRepository _influencerSocialRepository;
    private readonly InfluencerSocialBusinessRules _influencerSocialBusinessRules;

    public InfluencerSocialManager(IInfluencerSocialRepository influencerSocialRepository, InfluencerSocialBusinessRules influencerSocialBusinessRules)
    {
        _influencerSocialRepository = influencerSocialRepository;
        _influencerSocialBusinessRules = influencerSocialBusinessRules;
    }

    public async Task<InfluencerSocial?> GetAsync(
        Expression<Func<InfluencerSocial, bool>> predicate,
        Func<IQueryable<InfluencerSocial>, IIncludableQueryable<InfluencerSocial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        InfluencerSocial? influencerSocial = await _influencerSocialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return influencerSocial;
    }

    public async Task<IPaginate<InfluencerSocial>?> GetListAsync(
        Expression<Func<InfluencerSocial, bool>>? predicate = null,
        Func<IQueryable<InfluencerSocial>, IOrderedQueryable<InfluencerSocial>>? orderBy = null,
        Func<IQueryable<InfluencerSocial>, IIncludableQueryable<InfluencerSocial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<InfluencerSocial> influencerSocialList = await _influencerSocialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return influencerSocialList;
    }

    public async Task<InfluencerSocial> AddAsync(InfluencerSocial influencerSocial)
    {
        InfluencerSocial addedInfluencerSocial = await _influencerSocialRepository.AddAsync(influencerSocial);

        return addedInfluencerSocial;
    }

    public async Task<InfluencerSocial> UpdateAsync(InfluencerSocial influencerSocial)
    {
        InfluencerSocial updatedInfluencerSocial = await _influencerSocialRepository.UpdateAsync(influencerSocial);

        return updatedInfluencerSocial;
    }

    public async Task<InfluencerSocial> DeleteAsync(InfluencerSocial influencerSocial, bool permanent = false)
    {
        InfluencerSocial deletedInfluencerSocial = await _influencerSocialRepository.DeleteAsync(influencerSocial);

        return deletedInfluencerSocial;
    }
}
