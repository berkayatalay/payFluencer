using Application.Features.Posts.Constants;
using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Posts.Constants.PostsOperationClaims;

namespace Application.Features.Posts.Commands.Create;

public class CreatePostCommand : IRequest<CreatedPostResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required double Budget { get; set; }
    public required string Status { get; set; }
    public required Guid SponsorId { get; set; }

    public string[] Roles => [Admin, Write, PostsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPosts"];

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatedPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly PostBusinessRules _postBusinessRules;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository,
                                         PostBusinessRules postBusinessRules)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<CreatedPostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);

            await _postRepository.AddAsync(post);

            CreatedPostResponse response = _mapper.Map<CreatedPostResponse>(post);
            return response;
        }
    }
}