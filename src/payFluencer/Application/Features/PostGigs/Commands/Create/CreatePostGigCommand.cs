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

namespace Application.Features.PostGigs.Commands.Create;

public class CreatePostGigCommand : IRequest<CreatedPostGigResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid PostId { get; set; }
    public required Guid GigId { get; set; }

    public string[] Roles => [Admin, Write, PostGigsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPostGigs"];

    public class CreatePostGigCommandHandler : IRequestHandler<CreatePostGigCommand, CreatedPostGigResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostGigRepository _postGigRepository;
        private readonly PostGigBusinessRules _postGigBusinessRules;

        public CreatePostGigCommandHandler(IMapper mapper, IPostGigRepository postGigRepository,
                                         PostGigBusinessRules postGigBusinessRules)
        {
            _mapper = mapper;
            _postGigRepository = postGigRepository;
            _postGigBusinessRules = postGigBusinessRules;
        }

        public async Task<CreatedPostGigResponse> Handle(CreatePostGigCommand request, CancellationToken cancellationToken)
        {
            PostGig postGig = _mapper.Map<PostGig>(request);

            await _postGigRepository.AddAsync(postGig);

            CreatedPostGigResponse response = _mapper.Map<CreatedPostGigResponse>(postGig);
            return response;
        }
    }
}