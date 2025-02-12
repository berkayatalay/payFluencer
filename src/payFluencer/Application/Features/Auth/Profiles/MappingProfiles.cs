using Application.Features.Auth.Commands.RevokeToken;
using AutoMapper;
using Domain.Entities;
using Domain.Dtos;

namespace Application.Features.Auth.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<NArchitecture.Core.Security.Entities.RefreshToken<Guid, Guid>, RefreshToken>().ReverseMap();
        CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
        CreateMap<User, UserLoginDto>().ReverseMap();
    }
}
