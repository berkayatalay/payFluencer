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

namespace Application.Features.Sponsors.Commands.Create;

public class CreateSponsorCommand : IRequest<CreatedSponsorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string CompanyName { get; set; }
    public required string ProfilePicture { get; set; }
    public required string About { get; set; }
    public required double Rating { get; set; }
    public required Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, SponsorsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSponsors"];

    public class CreateSponsorCommandHandler : IRequestHandler<CreateSponsorCommand, CreatedSponsorResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly SponsorBusinessRules _sponsorBusinessRules;

        public CreateSponsorCommandHandler(IMapper mapper, ISponsorRepository sponsorRepository,
                                         SponsorBusinessRules sponsorBusinessRules)
        {
            _mapper = mapper;
            _sponsorRepository = sponsorRepository;
            _sponsorBusinessRules = sponsorBusinessRules;
        }

        public async Task<CreatedSponsorResponse> Handle(CreateSponsorCommand request, CancellationToken cancellationToken)
        {
            Sponsor sponsor = _mapper.Map<Sponsor>(request);

            await _sponsorRepository.AddAsync(sponsor);

            CreatedSponsorResponse response = _mapper.Map<CreatedSponsorResponse>(sponsor);
            return response;
        }
    }
}