using Application.Features.Influencers.Constants;
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

namespace Application.Features.Influencers.Commands.Delete;

public class DeleteInfluencerCommand : IRequest<DeletedInfluencerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, InfluencersOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInfluencers"];

    public class DeleteInfluencerCommandHandler : IRequestHandler<DeleteInfluencerCommand, DeletedInfluencerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInfluencerRepository _influencerRepository;
        private readonly InfluencerBusinessRules _influencerBusinessRules;

        public DeleteInfluencerCommandHandler(IMapper mapper, IInfluencerRepository influencerRepository,
                                         InfluencerBusinessRules influencerBusinessRules)
        {
            _mapper = mapper;
            _influencerRepository = influencerRepository;
            _influencerBusinessRules = influencerBusinessRules;
        }

        public async Task<DeletedInfluencerResponse> Handle(DeleteInfluencerCommand request, CancellationToken cancellationToken)
        {
            Influencer? influencer = await _influencerRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _influencerBusinessRules.InfluencerShouldExistWhenSelected(influencer);

            await _influencerRepository.DeleteAsync(influencer!);

            DeletedInfluencerResponse response = _mapper.Map<DeletedInfluencerResponse>(influencer);
            return response;
        }
    }
}