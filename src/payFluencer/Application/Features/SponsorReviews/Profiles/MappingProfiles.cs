using Application.Features.SponsorReviews.Commands.Create;
using Application.Features.SponsorReviews.Commands.Delete;
using Application.Features.SponsorReviews.Commands.Update;
using Application.Features.SponsorReviews.Queries.GetById;
using Application.Features.SponsorReviews.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SponsorReviews.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSponsorReviewCommand, SponsorReview>();
        CreateMap<SponsorReview, CreatedSponsorReviewResponse>();

        CreateMap<UpdateSponsorReviewCommand, SponsorReview>();
        CreateMap<SponsorReview, UpdatedSponsorReviewResponse>();

        CreateMap<DeleteSponsorReviewCommand, SponsorReview>();
        CreateMap<SponsorReview, DeletedSponsorReviewResponse>();

        CreateMap<SponsorReview, GetByIdSponsorReviewResponse>();

        CreateMap<SponsorReview, GetListSponsorReviewListItemDto>();
        CreateMap<IPaginate<SponsorReview>, GetListResponse<GetListSponsorReviewListItemDto>>();
    }
}