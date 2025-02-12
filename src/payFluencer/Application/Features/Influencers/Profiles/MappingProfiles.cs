using Application.Features.Influencers.Commands.Create;
using Application.Features.Influencers.Commands.Delete;
using Application.Features.Influencers.Commands.Update;
using Application.Features.Influencers.Queries.GetById;
using Application.Features.Influencers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Influencers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateInfluencerCommand, Influencer>();
        CreateMap<Influencer, CreatedInfluencerResponse>();

        CreateMap<UpdateInfluencerCommand, Influencer>();
        CreateMap<Influencer, UpdatedInfluencerResponse>();

        CreateMap<DeleteInfluencerCommand, Influencer>();
        CreateMap<Influencer, DeletedInfluencerResponse>();

        CreateMap<Influencer, GetByIdInfluencerResponse>();

        CreateMap<Influencer, GetListInfluencerListItemDto>();
        CreateMap<IPaginate<Influencer>, GetListResponse<GetListInfluencerListItemDto>>();
    }
}