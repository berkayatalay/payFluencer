using Application.Features.SponsorReviews.Constants;
using Application.Features.SponsorReviews.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SponsorReviews.Constants.SponsorReviewsOperationClaims;

namespace Application.Features.SponsorReviews.Commands.Create;

public class CreateSponsorReviewCommand : IRequest<CreatedSponsorReviewResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required double Rating { get; set; }
    public required string Comment { get; set; }
    public required Guid SponsorId { get; set; }
    public required Guid InfluencerId { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, SponsorReviewsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSponsorReviews"];

    public class CreateSponsorReviewCommandHandler : IRequestHandler<CreateSponsorReviewCommand, CreatedSponsorReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorReviewRepository _sponsorReviewRepository;
        private readonly SponsorReviewBusinessRules _sponsorReviewBusinessRules;

        public CreateSponsorReviewCommandHandler(IMapper mapper, ISponsorReviewRepository sponsorReviewRepository,
                                         SponsorReviewBusinessRules sponsorReviewBusinessRules)
        {
            _mapper = mapper;
            _sponsorReviewRepository = sponsorReviewRepository;
            _sponsorReviewBusinessRules = sponsorReviewBusinessRules;
        }

        public async Task<CreatedSponsorReviewResponse> Handle(CreateSponsorReviewCommand request, CancellationToken cancellationToken)
        {
            SponsorReview sponsorReview = _mapper.Map<SponsorReview>(request);

            await _sponsorReviewRepository.AddAsync(sponsorReview);

            CreatedSponsorReviewResponse response = _mapper.Map<CreatedSponsorReviewResponse>(sponsorReview);
            return response;
        }
    }
}