using Application.Features.PostGigs.Constants;
using Application.Features.PostGigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PostGigs.Constants.PostGigsOperationClaims;

namespace Application.Features.PostGigs.Queries.GetById;

public class GetByIdPostGigQuery : IRequest<GetByIdPostGigResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPostGigQueryHandler : IRequestHandler<GetByIdPostGigQuery, GetByIdPostGigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostGigRepository _postGigRepository;
        private readonly PostGigBusinessRules _postGigBusinessRules;

        public GetByIdPostGigQueryHandler(IMapper mapper, IPostGigRepository postGigRepository, PostGigBusinessRules postGigBusinessRules)
        {
            _mapper = mapper;
            _postGigRepository = postGigRepository;
            _postGigBusinessRules = postGigBusinessRules;
        }

        public async Task<GetByIdPostGigResponse> Handle(GetByIdPostGigQuery request, CancellationToken cancellationToken)
        {
            PostGig? postGig = await _postGigRepository.GetAsync(predicate: pg => pg.Id == request.Id, cancellationToken: cancellationToken);
            await _postGigBusinessRules.PostGigShouldExistWhenSelected(postGig);

            GetByIdPostGigResponse response = _mapper.Map<GetByIdPostGigResponse>(postGig);
            return response;
        }
    }
}