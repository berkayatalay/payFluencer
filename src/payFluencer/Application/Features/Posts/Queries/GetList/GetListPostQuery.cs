using Application.Features.Posts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Posts.Constants.PostsOperationClaims;

namespace Application.Features.Posts.Queries.GetList;

public class GetListPostQuery : IRequest<GetListResponse<GetListPostListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPosts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPosts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPostQueryHandler : IRequestHandler<GetListPostQuery, GetListResponse<GetListPostListItemDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPostListItemDto>> Handle(GetListPostQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Post> posts = await _postRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPostListItemDto> response = _mapper.Map<GetListResponse<GetListPostListItemDto>>(posts);
            return response;
        }
    }
}