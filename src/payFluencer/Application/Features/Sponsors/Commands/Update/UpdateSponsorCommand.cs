using Application.Features.Sponsors.Constants;
using Application.Features.Sponsors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sponsors.Constants.SponsorsOperationClaims;

namespace Application.Features.Sponsors.Commands.Update;

public class UpdateSponsorCommand : IRequest<UpdatedSponsorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string CompanyName { get; set; }
    public required string ProfilePicture { get; set; }
    public required string About { get; set; }
    public required double Rating { get; set; }
    public required Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, SponsorsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSponsors"];

    public class UpdateSponsorCommandHandler : IRequestHandler<UpdateSponsorCommand, UpdatedSponsorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly SponsorBusinessRules _sponsorBusinessRules;

        public UpdateSponsorCommandHandler(IMapper mapper, ISponsorRepository sponsorRepository,
                                         SponsorBusinessRules sponsorBusinessRules)
        {
            _mapper = mapper;
            _sponsorRepository = sponsorRepository;
            _sponsorBusinessRules = sponsorBusinessRules;
        }

        public async Task<UpdatedSponsorResponse> Handle(UpdateSponsorCommand request, CancellationToken cancellationToken)
        {
            Sponsor? sponsor = await _sponsorRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sponsorBusinessRules.SponsorShouldExistWhenSelected(sponsor);
            sponsor = _mapper.Map(request, sponsor);

            await _sponsorRepository.UpdateAsync(sponsor!);

            UpdatedSponsorResponse response = _mapper.Map<UpdatedSponsorResponse>(sponsor);
            return response;
        }
    }
}