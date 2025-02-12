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

namespace Application.Features.Posts.Commands.Update;

public class UpdatePostCommand : IRequest<UpdatedPostResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required double Budget { get; set; }
    public required string Status { get; set; }
    public required Guid SponsorId { get; set; }

    public string[] Roles => [Admin, Write, PostsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPosts"];

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatedPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly PostBusinessRules _postBusinessRules;

        public UpdatePostCommandHandler(IMapper mapper, IPostRepository postRepository,
                                         PostBusinessRules postBusinessRules)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<UpdatedPostResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Post? post = await _postRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _postBusinessRules.PostShouldExistWhenSelected(post);
            post = _mapper.Map(request, post);

            await _postRepository.UpdateAsync(post!);

            UpdatedPostResponse response = _mapper.Map<UpdatedPostResponse>(post);
            return response;
        }
    }
}