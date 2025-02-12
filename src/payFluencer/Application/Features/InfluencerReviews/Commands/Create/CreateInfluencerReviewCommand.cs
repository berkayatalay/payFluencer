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

namespace Application.Features.InfluencerReviews.Commands.Create;

public class CreateInfluencerReviewCommand : IRequest<CreatedInfluencerReviewResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required double Rating { get; set; }
    public required string Comment { get; set; }
    public required Guid InfluencerId { get; set; }
    public required Guid SponsorId { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, InfluencerReviewsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencerReviews"];

    public class CreateInfluencerReviewCommandHandler : IRequestHandler<CreateInfluencerReviewCommand, CreatedInfluencerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerReviewRepository _influencerReviewRepository;
        private readonly InfluencerReviewBusinessRules _influencerReviewBusinessRules;

        public CreateInfluencerReviewCommandHandler(IMapper mapper, IInfluencerReviewRepository influencerReviewRepository,
                                         InfluencerReviewBusinessRules influencerReviewBusinessRules)
        {
            _mapper = mapper;
            _influencerReviewRepository = influencerReviewRepository;
            _influencerReviewBusinessRules = influencerReviewBusinessRules;
        }

        public async Task<CreatedInfluencerReviewResponse> Handle(CreateInfluencerReviewCommand request, CancellationToken cancellationToken)
        {
            InfluencerReview influencerReview = _mapper.Map<InfluencerReview>(request);

            await _influencerReviewRepository.AddAsync(influencerReview);

            CreatedInfluencerReviewResponse response = _mapper.Map<CreatedInfluencerReviewResponse>(influencerReview);
            return response;
        }
    }
}