using Application.Features.Gigs.Constants;
using Application.Features.Gigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Gigs.Constants.GigsOperationClaims;

namespace Application.Features.Gigs.Queries.GetById;

public class GetByIdGigQuery : IRequest<GetByIdGigResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdGigQueryHandler : IRequestHandler<GetByIdGigQuery, GetByIdGigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGigRepository _gigRepository;
        private readonly GigBusinessRules _gigBusinessRules;

        public GetByIdGigQueryHandler(IMapper mapper, IGigRepository gigRepository, GigBusinessRules gigBusinessRules)
        {
            _mapper = mapper;
            _gigRepository = gigRepository;
            _gigBusinessRules = gigBusinessRules;
        }

        public async Task<GetByIdGigResponse> Handle(GetByIdGigQuery request, CancellationToken cancellationToken)
        {
            Gig? gig = await _gigRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _gigBusinessRules.GigShouldExistWhenSelected(gig);

            GetByIdGigResponse response = _mapper.Map<GetByIdGigResponse>(gig);
            return response;
        }
    }
}