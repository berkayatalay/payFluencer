using Application.Features.PostGigs.Constants;
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

namespace Application.Features.PostGigs.Commands.Delete;

public class DeletePostGigCommand : IRequest<DeletedPostGigResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PostGigsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPostGigs"];

    public class DeletePostGigCommandHandler : IRequestHandler<DeletePostGigCommand, DeletedPostGigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostGigRepository _postGigRepository;
        private readonly PostGigBusinessRules _postGigBusinessRules;

        public DeletePostGigCommandHandler(IMapper mapper, IPostGigRepository postGigRepository,
                                         PostGigBusinessRules postGigBusinessRules)
        {
            _mapper = mapper;
            _postGigRepository = postGigRepository;
            _postGigBusinessRules = postGigBusinessRules;
        }

        public async Task<DeletedPostGigResponse> Handle(DeletePostGigCommand request, CancellationToken cancellationToken)
        {
            PostGig? postGig = await _postGigRepository.GetAsync(predicate: pg => pg.Id == request.Id, cancellationToken: cancellationToken);
            await _postGigBusinessRules.PostGigShouldExistWhenSelected(postGig);

            await _postGigRepository.DeleteAsync(postGig!);

            DeletedPostGigResponse response = _mapper.Map<DeletedPostGigResponse>(postGig);
            return response;
        }
    }
}