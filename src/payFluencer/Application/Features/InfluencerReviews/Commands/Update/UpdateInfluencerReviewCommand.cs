using Application.Features.InfluencerReviews.Constants;
using Application.Features.InfluencerReviews.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.InfluencerReviews.Constants.InfluencerReviewsOperationClaims;

namespace Application.Features.InfluencerReviews.Commands.Update;

public class UpdateInfluencerReviewCommand : IRequest<UpdatedInfluencerReviewResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required double Rating { get; set; }
    public required string Comment { get; set; }
    public required Guid InfluencerId { get; set; }
    public required Guid SponsorId { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, InfluencerReviewsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencerReviews"];

    public class UpdateInfluencerReviewCommandHandler : IRequestHandler<UpdateInfluencerReviewCommand, UpdatedInfluencerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerReviewRepository _influencerReviewRepository;
        private readonly InfluencerReviewBusinessRules _influencerReviewBusinessRules;

        public UpdateInfluencerReviewCommandHandler(IMapper mapper, IInfluencerReviewRepository influencerReviewRepository,
                                         InfluencerReviewBusinessRules influencerReviewBusinessRules)
        {
            _mapper = mapper;
            _influencerReviewRepository = influencerReviewRepository;
            _influencerReviewBusinessRules = influencerReviewBusinessRules;
        }

        public async Task<UpdatedInfluencerReviewResponse> Handle(UpdateInfluencerReviewCommand request, CancellationToken cancellationToken)
        {
            InfluencerReview? influencerReview = await _influencerReviewRepository.GetAsync(predicate: ir => ir.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerReviewBusinessRules.InfluencerReviewShouldExistWhenSelected(influencerReview);
            influencerReview = _mapper.Map(request, influencerReview);

            await _influencerReviewRepository.UpdateAsync(influencerReview!);

            UpdatedInfluencerReviewResponse response = _mapper.Map<UpdatedInfluencerReviewResponse>(influencerReview);
            return response;
        }
    }
}