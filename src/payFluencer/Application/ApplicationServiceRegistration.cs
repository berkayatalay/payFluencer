using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using Application.Services.Disputes;
using Application.Services.Gigs;
using Application.Services.Influencers;
using Application.Services.InfluencerReviews;
using Application.Services.InfluencerSocials;
using Application.Services.Messages;
using Application.Services.Posts;
using Application.Services.PostGigs;
using Application.Services.Reviews;
using Application.Services.SocialPlatforms;
using Application.Services.Sponsors;
using Application.Services.SponsorReviews;
using Application.Services.SupportTickets;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int, Guid>(tokenOptions);

        services.AddScoped<IDisputeService, DisputeManager>();
        services.AddScoped<IGigService, GigManager>();
        services.AddScoped<IInfluencerService, InfluencerManager>();
        services.AddScoped<IInfluencerReviewService, InfluencerReviewManager>();
        services.AddScoped<IInfluencerReviewService, InfluencerReviewManager>();
        services.AddScoped<IInfluencerSocialService, InfluencerSocialManager>();
        services.AddScoped<IMessageService, MessageManager>();
        services.AddScoped<IPostService, PostManager>();
        services.AddScoped<IPostGigService, PostGigManager>();
        services.AddScoped<IReviewService, ReviewManager>();
        services.AddScoped<ISocialPlatformService, SocialPlatformManager>();
        services.AddScoped<ISponsorService, SponsorManager>();
        services.AddScoped<ISponsorReviewService, SponsorReviewManager>();
        services.AddScoped<ISupportTicketService, SupportTicketManager>();
        services.AddScoped<ISupportTicketService, SupportTicketManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
