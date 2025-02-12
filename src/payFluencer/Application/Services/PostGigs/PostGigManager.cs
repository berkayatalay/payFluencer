using Application.Features.PostGigs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PostGigs;

public class PostGigManager : IPostGigService
{
    private readonly IPostGigRepository _postGigRepository;
    private readonly PostGigBusinessRules _postGigBusinessRules;

    public PostGigManager(IPostGigRepository postGigRepository, PostGigBusinessRules postGigBusinessRules)
    {
        _postGigRepository = postGigRepository;
        _postGigBusinessRules = postGigBusinessRules;
    }

    public async Task<PostGig?> GetAsync(
        Expression<Func<PostGig, bool>> predicate,
        Func<IQueryable<PostGig>, IIncludableQueryable<PostGig, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PostGig? postGig = await _postGigRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return postGig;
    }

    public async Task<IPaginate<PostGig>?> GetListAsync(
        Expression<Func<PostGig, bool>>? predicate = null,
        Func<IQueryable<PostGig>, IOrderedQueryable<PostGig>>? orderBy = null,
        Func<IQueryable<PostGig>, IIncludableQueryable<PostGig, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PostGig> postGigList = await _postGigRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return postGigList;
    }

    public async Task<PostGig> AddAsync(PostGig postGig)
    {
        PostGig addedPostGig = await _postGigRepository.AddAsync(postGig);

        return addedPostGig;
    }

    public async Task<PostGig> UpdateAsync(PostGig postGig)
    {
        PostGig updatedPostGig = await _postGigRepository.UpdateAsync(postGig);

        return updatedPostGig;
    }

    public async Task<PostGig> DeleteAsync(PostGig postGig, bool permanent = false)
    {
        PostGig deletedPostGig = await _postGigRepository.DeleteAsync(postGig);

        return deletedPostGig;
    }
}
