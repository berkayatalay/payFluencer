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

namespace Application.Features.SupportTickets.Commands.Update;

public class UpdateSupportTicketCommand : IRequest<UpdatedSupportTicketResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Category { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required string Status { get; set; }

    public string[] Roles => [Admin, Write, SupportTicketsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSupportTickets"];

    public class UpdateSupportTicketCommandHandler : IRequestHandler<UpdateSupportTicketCommand, UpdatedSupportTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly SupportTicketBusinessRules _supportTicketBusinessRules;

        public UpdateSupportTicketCommandHandler(IMapper mapper, ISupportTicketRepository supportTicketRepository,
                                         SupportTicketBusinessRules supportTicketBusinessRules)
        {
            _mapper = mapper;
            _supportTicketRepository = supportTicketRepository;
            _supportTicketBusinessRules = supportTicketBusinessRules;
        }

        public async Task<UpdatedSupportTicketResponse> Handle(UpdateSupportTicketCommand request, CancellationToken cancellationToken)
        {
            SupportTicket? supportTicket = await _supportTicketRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _supportTicketBusinessRules.SupportTicketShouldExistWhenSelected(supportTicket);
            supportTicket = _mapper.Map(request, supportTicket);

            await _supportTicketRepository.UpdateAsync(supportTicket!);

            UpdatedSupportTicketResponse response = _mapper.Map<UpdatedSupportTicketResponse>(supportTicket);
            return response;
        }
    }
}