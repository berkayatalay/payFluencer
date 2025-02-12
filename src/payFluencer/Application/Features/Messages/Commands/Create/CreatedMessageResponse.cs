using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Commands.Create;

public class CreatedMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecieverUserId { get; set; }
}