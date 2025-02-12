using NArchitecture.Core.Application.Responses;

namespace Application.Features.PostGigs.Queries.GetById;

public class GetByIdPostGigResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public Guid GigId { get; set; }
}