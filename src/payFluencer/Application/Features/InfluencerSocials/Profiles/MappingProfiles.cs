using Application.Features.InfluencerSocials.Commands.Create;
using Application.Features.InfluencerSocials.Commands.Delete;
using Application.Features.InfluencerSocials.Commands.Update;
using Application.Features.InfluencerSocials.Queries.GetById;
using Application.Features.InfluencerSocials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.InfluencerSocials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateInfluencerSocialCommand, InfluencerSocial>();
        CreateMap<InfluencerSocial, CreatedInfluencerSocialResponse>();

        CreateMap<UpdateInfluencerSocialCommand, InfluencerSocial>();
        CreateMap<InfluencerSocial, UpdatedInfluencerSocialResponse>();

        CreateMap<DeleteInfluencerSocialCommand, InfluencerSocial>();
        CreateMap<InfluencerSocial, DeletedInfluencerSocialResponse>();

        CreateMap<InfluencerSocial, GetByIdInfluencerSocialResponse>();

        CreateMap<InfluencerSocial, GetListInfluencerSocialListItemDto>();
        CreateMap<IPaginate<InfluencerSocial>, GetListResponse<GetListInfluencerSocialListItemDto>>();
    }
}