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

namespace Application.Features.SponsorReviews.Commands.Update;

public class UpdateSponsorReviewCommand : IRequest<UpdatedSponsorReviewResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required double Rating { get; set; }
    public required string Comment { get; set; }
    public required Guid SponsorId { get; set; }
    public required Guid InfluencerId { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, SponsorReviewsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSponsorReviews"];

    public class UpdateSponsorReviewCommandHandler : IRequestHandler<UpdateSponsorReviewCommand, UpdatedSponsorReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorReviewRepository _sponsorReviewRepository;
        private readonly SponsorReviewBusinessRules _sponsorReviewBusinessRules;

        public UpdateSponsorReviewCommandHandler(IMapper mapper, ISponsorReviewRepository sponsorReviewRepository,
                                         SponsorReviewBusinessRules sponsorReviewBusinessRules)
        {
            _mapper = mapper;
            _sponsorReviewRepository = sponsorReviewRepository;
            _sponsorReviewBusinessRules = sponsorReviewBusinessRules;
        }

        public async Task<UpdatedSponsorReviewResponse> Handle(UpdateSponsorReviewCommand request, CancellationToken cancellationToken)
        {
            SponsorReview? sponsorReview = await _sponsorReviewRepository.GetAsync(predicate: sr => sr.Id == request.Id, cancellationToken: cancellationToken);
            await _sponsorReviewBusinessRules.SponsorReviewShouldExistWhenSelected(sponsorReview);
            sponsorReview = _mapper.Map(request, sponsorReview);

            await _sponsorReviewRepository.UpdateAsync(sponsorReview!);

            UpdatedSponsorReviewResponse response = _mapper.Map<UpdatedSponsorReviewResponse>(sponsorReview);
            return response;
        }
    }
}