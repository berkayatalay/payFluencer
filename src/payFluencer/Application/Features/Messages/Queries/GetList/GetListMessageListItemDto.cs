using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Messages.Queries.GetList;

public class GetListMessageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecieverUserId { get; set; }
}