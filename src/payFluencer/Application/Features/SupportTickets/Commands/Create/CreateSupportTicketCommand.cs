using Application.Features.SupportTickets.Constants;
using Application.Features.SupportTickets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SupportTickets.Constants.SupportTicketsOperationClaims;

namespace Application.Features.SupportTickets.Commands.Create;

public class CreateSupportTicketCommand : IRequest<CreatedSupportTicketResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Category { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Status { get; set; }

    public string[] Roles => [Admin, Write, SupportTicketsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSupportTickets"];

    public class CreateSupportTicketCommandHandler : IRequestHandler<CreateSupportTicketCommand, CreatedSupportTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly SupportTicketBusinessRules _supportTicketBusinessRules;

        public CreateSupportTicketCommandHandler(IMapper mapper, ISupportTicketRepository supportTicketRepository,
                                         SupportTicketBusinessRules supportTicketBusinessRules)
        {
            _mapper = mapper;
            _supportTicketRepository = supportTicketRepository;
            _supportTicketBusinessRules = supportTicketBusinessRules;
        }

        public async Task<CreatedSupportTicketResponse> Handle(CreateSupportTicketCommand request, CancellationToken cancellationToken)
        {
            SupportTicket supportTicket = _mapper.Map<SupportTicket>(request);

            await _supportTicketRepository.AddAsync(supportTicket);

            CreatedSupportTicketResponse response = _mapper.Map<CreatedSupportTicketResponse>(supportTicket);
            return response;
        }
    }
}