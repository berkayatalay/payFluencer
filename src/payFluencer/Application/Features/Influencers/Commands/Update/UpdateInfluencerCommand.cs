using Application.Features.Influencers.Constants;
using Application.Features.Influencers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Influencers.Constants.InfluencersOperationClaims;

namespace Application.Features.Influencers.Commands.Update;

public class UpdateInfluencerCommand : IRequest<UpdatedInfluencerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string ProfilePicture { get; set; }
    public required string About { get; set; }
    public required double Rating { get; set; }
    public required Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, InfluencersOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencers"];

    public class UpdateInfluencerCommandHandler : IRequestHandler<UpdateInfluencerCommand, UpdatedInfluencerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerRepository _influencerRepository;
        private readonly InfluencerBusinessRules _influencerBusinessRules;

        public UpdateInfluencerCommandHandler(IMapper mapper, IInfluencerRepository influencerRepository,
                                         InfluencerBusinessRules influencerBusinessRules)
        {
            _mapper = mapper;
            _influencerRepository = influencerRepository;
            _influencerBusinessRules = influencerBusinessRules;
        }

        public async Task<UpdatedInfluencerResponse> Handle(UpdateInfluencerCommand request, CancellationToken cancellationToken)
        {
            Influencer? influencer = await _influencerRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerBusinessRules.InfluencerShouldExistWhenSelected(influencer);
            influencer = _mapper.Map(request, influencer);

            await _influencerRepository.UpdateAsync(influencer!);

            UpdatedInfluencerResponse response = _mapper.Map<UpdatedInfluencerResponse>(influencer);
            return response;
        }
    }
}