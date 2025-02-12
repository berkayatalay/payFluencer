using Application.Features.Gigs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Gigs;

public class GigManager : IGigService
{
    private readonly IGigRepository _gigRepository;
    private readonly GigBusinessRules _gigBusinessRules;

    public GigManager(IGigRepository gigRepository, GigBusinessRules gigBusinessRules)
    {
        _gigRepository = gigRepository;
        _gigBusinessRules = gigBusinessRules;
    }

    public async Task<Gig?> GetAsync(
        Expression<Func<Gig, bool>> predicate,
        Func<IQueryable<Gig>, IIncludableQueryable<Gig, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Gig? gig = await _gigRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return gig;
    }

    public async Task<IPaginate<Gig>?> GetListAsync(
        Expression<Func<Gig, bool>>? predicate = null,
        Func<IQueryable<Gig>, IOrderedQueryable<Gig>>? orderBy = null,
        Func<IQueryable<Gig>, IIncludableQueryable<Gig, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Gig> gigList = await _gigRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return gigList;
    }

    public async Task<Gig> AddAsync(Gig gig)
    {
        Gig addedGig = await _gigRepository.AddAsync(gig);

        return addedGig;
    }

    public async Task<Gig> UpdateAsync(Gig gig)
    {
        Gig updatedGig = await _gigRepository.UpdateAsync(gig);

        return updatedGig;
    }

    public async Task<Gig> DeleteAsync(Gig gig, bool permanent = false)
    {
        Gig deletedGig = await _gigRepository.DeleteAsync(gig);

        return deletedGig;
    }
}
