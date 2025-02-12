using Application.Features.InfluencerReviews.Constants;
using Application.Features.InfluencerReviews.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.InfluencerReviews.Constants.InfluencerReviewsOperationClaims;

namespace Application.Features.InfluencerReviews.Queries.GetById;

public class GetByIdInfluencerReviewQuery : IRequest<GetByIdInfluencerReviewResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdInfluencerReviewQueryHandler : IRequestHandler<GetByIdInfluencerReviewQuery, GetByIdInfluencerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerReviewRepository _influencerReviewRepository;
        private readonly InfluencerReviewBusinessRules _influencerReviewBusinessRules;

        public GetByIdInfluencerReviewQueryHandler(IMapper mapper, IInfluencerReviewRepository influencerReviewRepository, InfluencerReviewBusinessRules influencerReviewBusinessRules)
        {
            _mapper = mapper;
            _influencerReviewRepository = influencerReviewRepository;
            _influencerReviewBusinessRules = influencerReviewBusinessRules;
        }

        public async Task<GetByIdInfluencerReviewResponse> Handle(GetByIdInfluencerReviewQuery request, CancellationToken cancellationToken)
        {
            InfluencerReview? influencerReview = await _influencerReviewRepository.GetAsync(predicate: ir => ir.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerReviewBusinessRules.InfluencerReviewShouldExistWhenSelected(influencerReview);

            GetByIdInfluencerReviewResponse response = _mapper.Map<GetByIdInfluencerReviewResponse>(influencerReview);
            return response;
        }
    }
}