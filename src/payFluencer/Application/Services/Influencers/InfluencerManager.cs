using Application.Features.Influencers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Influencers;

public class InfluencerManager : IInfluencerService
{
    private readonly IInfluencerRepository _influencerRepository;
    private readonly InfluencerBusinessRules _influencerBusinessRules;

    public InfluencerManager(IInfluencerRepository influencerRepository, InfluencerBusinessRules influencerBusinessRules)
    {
        _influencerRepository = influencerRepository;
        _influencerBusinessRules = influencerBusinessRules;
    }

    public async Task<Influencer?> GetAsync(
        Expression<Func<Influencer, bool>> predicate,
        Func<IQueryable<Influencer>, IIncludableQueryable<Influencer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Influencer? influencer = await _influencerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return influencer;
    }

    public async Task<IPaginate<Influencer>?> GetListAsync(
        Expression<Func<Influencer, bool>>? predicate = null,
        Func<IQueryable<Influencer>, IOrderedQueryable<Influencer>>? orderBy = null,
        Func<IQueryable<Influencer>, IIncludableQueryable<Influencer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Influencer> influencerList = await _influencerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return influencerList;
    }

    public async Task<Influencer> AddAsync(Influencer influencer)
    {
        Influencer addedInfluencer = await _influencerRepository.AddAsync(influencer);

        return addedInfluencer;
    }

    public async Task<Influencer> UpdateAsync(Influencer influencer)
    {
        Influencer updatedInfluencer = await _influencerRepository.UpdateAsync(influencer);

        return updatedInfluencer;
    }

    public async Task<Influencer> DeleteAsync(Influencer influencer, bool permanent = false)
    {
        Influencer deletedInfluencer = await _influencerRepository.DeleteAsync(influencer);

        return deletedInfluencer;
    }
}
