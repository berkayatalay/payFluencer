using Application.Features.Gigs.Constants;
using Application.Features.Gigs.Constants;
using Application.Features.Gigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Gigs.Constants.GigsOperationClaims;

namespace Application.Features.Gigs.Commands.Delete;

public class DeleteGigCommand : IRequest<DeletedGigResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, GigsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetGigs"];

    public class DeleteGigCommandHandler : IRequestHandler<DeleteGigCommand, DeletedGigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGigRepository _gigRepository;
        private readonly GigBusinessRules _gigBusinessRules;

        public DeleteGigCommandHandler(IMapper mapper, IGigRepository gigRepository,
                                         GigBusinessRules gigBusinessRules)
        {
            _mapper = mapper;
            _gigRepository = gigRepository;
            _gigBusinessRules = gigBusinessRules;
        }

        public async Task<DeletedGigResponse> Handle(DeleteGigCommand request, CancellationToken cancellationToken)
        {
            Gig? gig = await _gigRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _gigBusinessRules.GigShouldExistWhenSelected(gig);

            await _gigRepository.DeleteAsync(gig!);

            DeletedGigResponse response = _mapper.Map<DeletedGigResponse>(gig);
            return response;
        }
    }
}