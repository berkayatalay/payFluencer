using Application.Features.InfluencerReviews.Commands.Create;
using Application.Features.InfluencerReviews.Commands.Delete;
using Application.Features.InfluencerReviews.Commands.Update;
using Application.Features.InfluencerReviews.Queries.GetById;
using Application.Features.InfluencerReviews.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.InfluencerReviews.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateInfluencerReviewCommand, InfluencerReview>();
        CreateMap<InfluencerReview, CreatedInfluencerReviewResponse>();

        CreateMap<UpdateInfluencerReviewCommand, InfluencerReview>();
        CreateMap<InfluencerReview, UpdatedInfluencerReviewResponse>();

        CreateMap<DeleteInfluencerReviewCommand, InfluencerReview>();
        CreateMap<InfluencerReview, DeletedInfluencerReviewResponse>();

        CreateMap<InfluencerReview, GetByIdInfluencerReviewResponse>();

        CreateMap<InfluencerReview, GetListInfluencerReviewListItemDto>();
        CreateMap<IPaginate<InfluencerReview>, GetListResponse<GetListInfluencerReviewListItemDto>>();
    }
}