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

namespace Application.Features.Gigs.Commands.Create;

public class CreateGigCommand : IRequest<CreatedGigResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required double Price { get; set; }
    public required string EarnProofLink { get; set; }
    public required string Status { get; set; }
    public required Guid SponsorId { get; set; }
    public required Guid InfluencerId { get; set; }
    public required Guid SponsorReviewId { get; set; }
    public required Guid InfluencerReviewId { get; set; }

    public string[] Roles => [Admin, Write, GigsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetGigs"];

    public class CreateGigCommandHandler : IRequestHandler<CreateGigCommand, CreatedGigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGigRepository _gigRepository;
        private readonly GigBusinessRules _gigBusinessRules;

        public CreateGigCommandHandler(IMapper mapper, IGigRepository gigRepository,
                                         GigBusinessRules gigBusinessRules)
        {
            _mapper = mapper;
            _gigRepository = gigRepository;
            _gigBusinessRules = gigBusinessRules;
        }

        public async Task<CreatedGigResponse> Handle(CreateGigCommand request, CancellationToken cancellationToken)
        {
            Gig gig = _mapper.Map<Gig>(request);

            await _gigRepository.AddAsync(gig);

            CreatedGigResponse response = _mapper.Map<CreatedGigResponse>(gig);
            return response;
        }
    }
}