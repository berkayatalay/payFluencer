using Application.Features.Reviews.Commands.Create;
using Application.Features.Reviews.Commands.Delete;
using Application.Features.Reviews.Commands.Update;
using Application.Features.Reviews.Queries.GetById;
using Application.Features.Reviews.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Reviews.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateReviewCommand, Review>();
        CreateMap<Review, CreatedReviewResponse>();

        CreateMap<UpdateReviewCommand, Review>();
        CreateMap<Review, UpdatedReviewResponse>();

        CreateMap<DeleteReviewCommand, Review>();
        CreateMap<Review, DeletedReviewResponse>();

        CreateMap<Review, GetByIdReviewResponse>();

        CreateMap<Review, GetListReviewListItemDto>();
        CreateMap<IPaginate<Review>, GetListResponse<GetListReviewListItemDto>>();
    }
}