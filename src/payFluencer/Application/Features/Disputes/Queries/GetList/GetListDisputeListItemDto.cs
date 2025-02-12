using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Disputes.Queries.GetList;

public class GetListDisputeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public Guid GigId { get; set; }
}