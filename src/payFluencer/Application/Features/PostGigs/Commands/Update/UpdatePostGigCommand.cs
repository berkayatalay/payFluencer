using Application.Features.PostGigs.Constants;
using Application.Features.PostGigs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PostGigs.Constants.PostGigsOperationClaims;

namespace Application.Features.PostGigs.Commands.Update;

public class UpdatePostGigCommand : IRequest<UpdatedPostGigResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid PostId { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, PostGigsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPostGigs"];

    public class UpdatePostGigCommandHandler : IRequestHandler<UpdatePostGigCommand, UpdatedPostGigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostGigRepository _postGigRepository;
        private readonly PostGigBusinessRules _postGigBusinessRules;

        public UpdatePostGigCommandHandler(IMapper mapper, IPostGigRepository postGigRepository,
                                         PostGigBusinessRules postGigBusinessRules)
        {
            _mapper = mapper;
            _postGigRepository = postGigRepository;
            _postGigBusinessRules = postGigBusinessRules;
        }

        public async Task<UpdatedPostGigResponse> Handle(UpdatePostGigCommand request, CancellationToken cancellationToken)
        {
            PostGig? postGig = await _postGigRepository.GetAsync(predicate: pg => pg.Id == request.Id, cancellationToken: cancellationToken);
            await _postGigBusinessRules.PostGigShouldExistWhenSelected(postGig);
            postGig = _mapper.Map(request, postGig);

            await _postGigRepository.UpdateAsync(postGig!);

            UpdatedPostGigResponse response = _mapper.Map<UpdatedPostGigResponse>(postGig);
            return response;
        }
    }
}