using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PostGigs.Queries.GetList;

public class GetListPostGigListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid GigId { get; set; }
}