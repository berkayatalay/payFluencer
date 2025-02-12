using Application.Features.Messages.Constants;
using Application.Features.Messages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Messages.Constants.MessagesOperationClaims;

namespace Application.Features.Messages.Commands.Create;

public class CreateMessageCommand : IRequest<CreatedMessageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Content { get; set; }
    public required Guid SenderUserId { get; set; }
    public required Guid RecieverUserId { get; set; }

    public string[] Roles => [Admin, Write, MessagesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetMessages"];

    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, CreatedMessageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly MessageBusinessRules _messageBusinessRules;

        public CreateMessageCommandHandler(IMapper mapper, IMessageRepository messageRepository,
                                         MessageBusinessRules messageBusinessRules)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _messageBusinessRules = messageBusinessRules;
        }

        public async Task<CreatedMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            Message message = _mapper.Map<Message>(request);

            await _messageRepository.AddAsync(message);

            CreatedMessageResponse response = _mapper.Map<CreatedMessageResponse>(message);
            return response;
        }
    }
}