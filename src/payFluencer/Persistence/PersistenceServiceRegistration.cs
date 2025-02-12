using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
     
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BaseDb");

        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(connectionString));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IDisputeRepository, DisputeRepository>();
        services.AddScoped<IGigRepository, GigRepository>();
        services.AddScoped<IInfluencerRepository, InfluencerRepository>();
        services.AddScoped<IInfluencerReviewRepository, InfluencerReviewRepository>();
        services.AddScoped<IInfluencerReviewRepository, InfluencerReviewRepository>();
        services.AddScoped<IInfluencerSocialRepository, InfluencerSocialRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IPostGigRepository, PostGigRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<ISocialPlatformRepository, SocialPlatformRepository>();
        services.AddScoped<ISponsorRepository, SponsorRepository>();
        services.AddScoped<ISponsorReviewRepository, SponsorReviewRepository>();
        services.AddScoped<ISupportTicketRepository, SupportTicketRepository>();
        services.AddScoped<ISupportTicketRepository, SupportTicketRepository>();
        return services;
    }
}
