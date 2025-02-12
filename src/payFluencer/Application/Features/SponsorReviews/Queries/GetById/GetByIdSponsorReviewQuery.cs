using Application.Features.SponsorReviews.Constants;
using Application.Features.SponsorReviews.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.SponsorReviews.Constants.SponsorReviewsOperationClaims;

namespace Application.Features.SponsorReviews.Queries.GetById;

public class GetByIdSponsorReviewQuery : IRequest<GetByIdSponsorReviewResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSponsorReviewQueryHandler : IRequestHandler<GetByIdSponsorReviewQuery, GetByIdSponsorReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorReviewRepository _sponsorReviewRepository;
        private readonly SponsorReviewBusinessRules _sponsorReviewBusinessRules;

        public GetByIdSponsorReviewQueryHandler(IMapper mapper, ISponsorReviewRepository sponsorReviewRepository, SponsorReviewBusinessRules sponsorReviewBusinessRules)
        {
            _mapper = mapper;
            _sponsorReviewRepository = sponsorReviewRepository;
            _sponsorReviewBusinessRules = sponsorReviewBusinessRules;
        }

        public async Task<GetByIdSponsorReviewResponse> Handle(GetByIdSponsorReviewQuery request, CancellationToken cancellationToken)
        {
            SponsorReview? sponsorReview = await _sponsorReviewRepository.GetAsync(predicate: sr => sr.Id == request.Id, cancellationToken: cancellationToken);
            await _sponsorReviewBusinessRules.SponsorReviewShouldExistWhenSelected(sponsorReview);

            GetByIdSponsorReviewResponse response = _mapper.Map<GetByIdSponsorReviewResponse>(sponsorReview);
            return response;
        }
    }
}