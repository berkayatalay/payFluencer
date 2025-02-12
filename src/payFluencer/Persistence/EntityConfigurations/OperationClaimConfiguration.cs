using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Disputes.Constants;
using Application.Features.Gigs.Constants;
using Application.Features.Influencers.Constants;
using Application.Features.InfluencerReviews.Constants;
using Application.Features.InfluencerSocials.Constants;
using Application.Features.Messages.Constants;
using Application.Features.Posts.Constants;
using Application.Features.PostGigs.Constants;
using Application.Features.Reviews.Constants;
using Application.Features.SocialPlatforms.Constants;
using Application.Features.Sponsors.Constants;
using Application.Features.SponsorReviews.Constants;
using Application.Features.SupportTickets.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Disputes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DisputesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DisputesOperationClaims.Read },
                new() { Id = ++lastId, Name = DisputesOperationClaims.Write },
                new() { Id = ++lastId, Name = DisputesOperationClaims.Create },
                new() { Id = ++lastId, Name = DisputesOperationClaims.Update },
                new() { Id = ++lastId, Name = DisputesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Gigs CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = GigsOperationClaims.Admin },
                new() { Id = ++lastId, Name = GigsOperationClaims.Read },
                new() { Id = ++lastId, Name = GigsOperationClaims.Write },
                new() { Id = ++lastId, Name = GigsOperationClaims.Create },
                new() { Id = ++lastId, Name = GigsOperationClaims.Update },
                new() { Id = ++lastId, Name = GigsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Influencers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InfluencersOperationClaims.Admin },
                new() { Id = ++lastId, Name = InfluencersOperationClaims.Read },
                new() { Id = ++lastId, Name = InfluencersOperationClaims.Write },
                new() { Id = ++lastId, Name = InfluencersOperationClaims.Create },
                new() { Id = ++lastId, Name = InfluencersOperationClaims.Update },
                new() { Id = ++lastId, Name = InfluencersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region InfluencerReviews CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Admin },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Read },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Write },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Create },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Update },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region InfluencerReviews CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Admin },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Read },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Write },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Create },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Update },
                new() { Id = ++lastId, Name = InfluencerReviewsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region InfluencerSocials CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = InfluencerSocialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = InfluencerSocialsOperationClaims.Read },
                new() { Id = ++lastId, Name = InfluencerSocialsOperationClaims.Write },
                new() { Id = ++lastId, Name = InfluencerSocialsOperationClaims.Create },
                new() { Id = ++lastId, Name = InfluencerSocialsOperationClaims.Update },
                new() { Id = ++lastId, Name = InfluencerSocialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Messages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MessagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Read },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Write },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Create },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Update },
                new() { Id = ++lastId, Name = MessagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Posts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PostsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PostsOperationClaims.Read },
                new() { Id = ++lastId, Name = PostsOperationClaims.Write },
                new() { Id = ++lastId, Name = PostsOperationClaims.Create },
                new() { Id = ++lastId, Name = PostsOperationClaims.Update },
                new() { Id = ++lastId, Name = PostsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region PostGigs CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PostGigsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PostGigsOperationClaims.Read },
                new() { Id = ++lastId, Name = PostGigsOperationClaims.Write },
                new() { Id = ++lastId, Name = PostGigsOperationClaims.Create },
                new() { Id = ++lastId, Name = PostGigsOperationClaims.Update },
                new() { Id = ++lastId, Name = PostGigsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Reviews CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ReviewsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ReviewsOperationClaims.Read },
                new() { Id = ++lastId, Name = ReviewsOperationClaims.Write },
                new() { Id = ++lastId, Name = ReviewsOperationClaims.Create },
                new() { Id = ++lastId, Name = ReviewsOperationClaims.Update },
                new() { Id = ++lastId, Name = ReviewsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SocialPlatforms CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SocialPlatformsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SocialPlatformsOperationClaims.Read },
                new() { Id = ++lastId, Name = SocialPlatformsOperationClaims.Write },
                new() { Id = ++lastId, Name = SocialPlatformsOperationClaims.Create },
                new() { Id = ++lastId, Name = SocialPlatformsOperationClaims.Update },
                new() { Id = ++lastId, Name = SocialPlatformsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Sponsors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Read },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Write },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Create },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Update },
                new() { Id = ++lastId, Name = SponsorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SponsorReviews CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SponsorReviewsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SponsorReviewsOperationClaims.Read },
                new() { Id = ++lastId, Name = SponsorReviewsOperationClaims.Write },
                new() { Id = ++lastId, Name = SponsorReviewsOperationClaims.Create },
                new() { Id = ++lastId, Name = SponsorReviewsOperationClaims.Update },
                new() { Id = ++lastId, Name = SponsorReviewsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SupportTickets CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Read },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Write },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Create },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Update },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SupportTickets CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Read },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Write },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Create },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Update },
                new() { Id = ++lastId, Name = SupportTicketsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
