using NArchitecture.Core.Application.Responses;

namespace Application.Features.Posts.Commands.Delete;

public class DeletedPostResponse : IResponse
{
    public Guid Id { get; set; }
}