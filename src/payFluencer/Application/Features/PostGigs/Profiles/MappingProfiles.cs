using Application.Features.PostGigs.Commands.Create;
using Application.Features.PostGigs.Commands.Delete;
using Application.Features.PostGigs.Commands.Update;
using Application.Features.PostGigs.Queries.GetById;
using Application.Features.PostGigs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PostGigs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostGigCommand, PostGig>();
        CreateMap<PostGig, CreatedPostGigResponse>();

        CreateMap<UpdatePostGigCommand, PostGig>();
        CreateMap<PostGig, UpdatedPostGigResponse>();

        CreateMap<DeletePostGigCommand, PostGig>();
        CreateMap<PostGig, DeletedPostGigResponse>();

        CreateMap<PostGig, GetByIdPostGigResponse>();

        CreateMap<PostGig, GetListPostGigListItemDto>();
        CreateMap<IPaginate<PostGig>, GetListResponse<GetListPostGigListItemDto>>();
    }
}