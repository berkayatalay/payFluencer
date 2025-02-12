using Application.Features.Disputes.Commands.Create;
using Application.Features.Disputes.Commands.Delete;
using Application.Features.Disputes.Commands.Update;
using Application.Features.Disputes.Queries.GetById;
using Application.Features.Disputes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Disputes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDisputeCommand, Dispute>();
        CreateMap<Dispute, CreatedDisputeResponse>();

        CreateMap<UpdateDisputeCommand, Dispute>();
        CreateMap<Dispute, UpdatedDisputeResponse>();

        CreateMap<DeleteDisputeCommand, Dispute>();
        CreateMap<Dispute, DeletedDisputeResponse>();

        CreateMap<Dispute, GetByIdDisputeResponse>();

        CreateMap<Dispute, GetListDisputeListItemDto>();
        CreateMap<IPaginate<Dispute>, GetListResponse<GetListDisputeListItemDto>>();
    }
}