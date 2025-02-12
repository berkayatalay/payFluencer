using Application.Features.SponsorReviews.Constants;
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

namespace Application.Features.SponsorReviews.Commands.Delete;

public class DeleteSponsorReviewCommand : IRequest<DeletedSponsorReviewResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, SponsorReviewsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSponsorReviews"];

    public class DeleteSponsorReviewCommandHandler : IRequestHandler<DeleteSponsorReviewCommand, DeletedSponsorReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorReviewRepository _sponsorReviewRepository;
        private readonly SponsorReviewBusinessRules _sponsorReviewBusinessRules;

        public DeleteSponsorReviewCommandHandler(IMapper mapper, ISponsorReviewRepository sponsorReviewRepository,
                                         SponsorReviewBusinessRules sponsorReviewBusinessRules)
        {
            _mapper = mapper;
            _sponsorReviewRepository = sponsorReviewRepository;
            _sponsorReviewBusinessRules = sponsorReviewBusinessRules;
        }

        public async Task<DeletedSponsorReviewResponse> Handle(DeleteSponsorReviewCommand request, CancellationToken cancellationToken)
        {
            SponsorReview? sponsorReview = await _sponsorReviewRepository.GetAsync(predicate: sr => sr.Id == request.Id, cancellationToken: cancellationToken);
            await _sponsorReviewBusinessRules.SponsorReviewShouldExistWhenSelected(sponsorReview);

            await _sponsorReviewRepository.DeleteAsync(sponsorReview!);

            DeletedSponsorReviewResponse response = _mapper.Map<DeletedSponsorReviewResponse>(sponsorReview);
            return response;
        }
    }
}