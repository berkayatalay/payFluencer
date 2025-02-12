using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Queries.GetById;

public class GetByIdMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecieverUserId { get; set; }
}