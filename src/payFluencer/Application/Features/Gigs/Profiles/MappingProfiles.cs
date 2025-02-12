using Application.Features.Gigs.Commands.Create;
using Application.Features.Gigs.Commands.Delete;
using Application.Features.Gigs.Commands.Update;
using Application.Features.Gigs.Queries.GetById;
using Application.Features.Gigs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Gigs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateGigCommand, Gig>();
        CreateMap<Gig, CreatedGigResponse>();

        CreateMap<UpdateGigCommand, Gig>();
        CreateMap<Gig, UpdatedGigResponse>();

        CreateMap<DeleteGigCommand, Gig>();
        CreateMap<Gig, DeletedGigResponse>();

        CreateMap<Gig, GetByIdGigResponse>();

        CreateMap<Gig, GetListGigListItemDto>();
        CreateMap<IPaginate<Gig>, GetListResponse<GetListGigListItemDto>>();
    }
}