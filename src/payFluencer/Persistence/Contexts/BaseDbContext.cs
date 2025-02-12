using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Dispute> Disputes { get; set; }
    public DbSet<Gig> Gigs { get; set; }
    public DbSet<Influencer> Influencers { get; set; }
    public DbSet<InfluencerReview> InfluencerReviews { get; set; }
    public DbSet<InfluencerSocial> InfluencerSocials { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostGig> PostGigs { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<SocialPlatform> SocialPlatforms { get; set; }
    public DbSet<Sponsor> Sponsors { get; set; }
    public DbSet<SponsorReview> SponsorReviews { get; set; }
    public DbSet<SupportTicket> SupportTickets { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
