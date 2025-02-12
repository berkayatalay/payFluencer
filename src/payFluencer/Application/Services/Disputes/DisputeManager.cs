using Application.Features.Disputes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Disputes;

public class DisputeManager : IDisputeService
{
    private readonly IDisputeRepository _disputeRepository;
    private readonly DisputeBusinessRules _disputeBusinessRules;

    public DisputeManager(IDisputeRepository disputeRepository, DisputeBusinessRules disputeBusinessRules)
    {
        _disputeRepository = disputeRepository;
        _disputeBusinessRules = disputeBusinessRules;
    }

    public async Task<Dispute?> GetAsync(
        Expression<Func<Dispute, bool>> predicate,
        Func<IQueryable<Dispute>, IIncludableQueryable<Dispute, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Dispute? dispute = await _disputeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return dispute;
    }

    public async Task<IPaginate<Dispute>?> GetListAsync(
        Expression<Func<Dispute, bool>>? predicate = null,
        Func<IQueryable<Dispute>, IOrderedQueryable<Dispute>>? orderBy = null,
        Func<IQueryable<Dispute>, IIncludableQueryable<Dispute, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Dispute> disputeList = await _disputeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return disputeList;
    }

    public async Task<Dispute> AddAsync(Dispute dispute)
    {
        Dispute addedDispute = await _disputeRepository.AddAsync(dispute);

        return addedDispute;
    }

    public async Task<Dispute> UpdateAsync(Dispute dispute)
    {
        Dispute updatedDispute = await _disputeRepository.UpdateAsync(dispute);

        return updatedDispute;
    }

    public async Task<Dispute> DeleteAsync(Dispute dispute, bool permanent = false)
    {
        Dispute deletedDispute = await _disputeRepository.DeleteAsync(dispute);

        return deletedDispute;
    }
}
