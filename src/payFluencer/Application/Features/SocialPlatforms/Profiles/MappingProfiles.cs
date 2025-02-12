using Application.Features.SocialPlatforms.Commands.Create;
using Application.Features.SocialPlatforms.Commands.Delete;
using Application.Features.SocialPlatforms.Commands.Update;
using Application.Features.SocialPlatforms.Queries.GetById;
using Application.Features.SocialPlatforms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SocialPlatforms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSocialPlatformCommand, SocialPlatform>();
        CreateMap<SocialPlatform, CreatedSocialPlatformResponse>();

        CreateMap<UpdateSocialPlatformCommand, SocialPlatform>();
        CreateMap<SocialPlatform, UpdatedSocialPlatformResponse>();

        CreateMap<DeleteSocialPlatformCommand, SocialPlatform>();
        CreateMap<SocialPlatform, DeletedSocialPlatformResponse>();

        CreateMap<SocialPlatform, GetByIdSocialPlatformResponse>();

        CreateMap<SocialPlatform, GetListSocialPlatformListItemDto>();
        CreateMap<IPaginate<SocialPlatform>, GetListResponse<GetListSocialPlatformListItemDto>>();
    }
}