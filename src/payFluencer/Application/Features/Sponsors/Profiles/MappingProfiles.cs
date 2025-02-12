using Application.Features.Sponsors.Commands.Create;
using Application.Features.Sponsors.Commands.Delete;
using Application.Features.Sponsors.Commands.Update;
using Application.Features.Sponsors.Queries.GetById;
using Application.Features.Sponsors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Sponsors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSponsorCommand, Sponsor>();
        CreateMap<Sponsor, CreatedSponsorResponse>();

        CreateMap<UpdateSponsorCommand, Sponsor>();
        CreateMap<Sponsor, UpdatedSponsorResponse>();

        CreateMap<DeleteSponsorCommand, Sponsor>();
        CreateMap<Sponsor, DeletedSponsorResponse>();

        CreateMap<Sponsor, GetByIdSponsorResponse>();

        CreateMap<Sponsor, GetListSponsorListItemDto>();
        CreateMap<IPaginate<Sponsor>, GetListResponse<GetListSponsorListItemDto>>();
    }
}