using NArchitecture.Core.Application.Responses;

namespace Application.Features.Messages.Commands.Update;

public class UpdatedMessageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecieverUserId { get; set; }
}