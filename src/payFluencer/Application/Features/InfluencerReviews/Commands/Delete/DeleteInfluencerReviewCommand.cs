using Application.Features.InfluencerReviews.Constants;
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

namespace Application.Features.InfluencerReviews.Commands.Delete;

public class DeleteInfluencerReviewCommand : IRequest<DeletedInfluencerReviewResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, InfluencerReviewsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencerReviews"];

    public class DeleteInfluencerReviewCommandHandler : IRequestHandler<DeleteInfluencerReviewCommand, DeletedInfluencerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerReviewRepository _influencerReviewRepository;
        private readonly InfluencerReviewBusinessRules _influencerReviewBusinessRules;

        public DeleteInfluencerReviewCommandHandler(IMapper mapper, IInfluencerReviewRepository influencerReviewRepository,
                                         InfluencerReviewBusinessRules influencerReviewBusinessRules)
        {
            _mapper = mapper;
            _influencerReviewRepository = influencerReviewRepository;
            _influencerReviewBusinessRules = influencerReviewBusinessRules;
        }

        public async Task<DeletedInfluencerReviewResponse> Handle(DeleteInfluencerReviewCommand request, CancellationToken cancellationToken)
        {
            InfluencerReview? influencerReview = await _influencerReviewRepository.GetAsync(predicate: ir => ir.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerReviewBusinessRules.InfluencerReviewShouldExistWhenSelected(influencerReview);

            await _influencerReviewRepository.DeleteAsync(influencerReview!);

            DeletedInfluencerReviewResponse response = _mapper.Map<DeletedInfluencerReviewResponse>(influencerReview);
            return response;
        }
    }
}