using Application.Features.Posts.Constants;
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

namespace Application.Features.Posts.Commands.Delete;

public class DeletePostCommand : IRequest<DeletedPostResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, PostsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPosts"];

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletedPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly PostBusinessRules _postBusinessRules;

        public DeletePostCommandHandler(IMapper mapper, IPostRepository postRepository,
                                         PostBusinessRules postBusinessRules)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<DeletedPostResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Post? post = await _postRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _postBusinessRules.PostShouldExistWhenSelected(post);

            await _postRepository.DeleteAsync(post!);

            DeletedPostResponse response = _mapper.Map<DeletedPostResponse>(post);
            return response;
        }
    }
}