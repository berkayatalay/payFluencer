using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GigConfiguration : IEntityTypeConfiguration<Gig>
{
    public void Configure(EntityTypeBuilder<Gig> builder)
    {
        builder.ToTable("Gigs").HasKey(g => g.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Title).HasColumnName("Title").IsRequired();
        builder.Property(g => g.Description).HasColumnName("Description").IsRequired();
        builder.Property(g => g.Price).HasColumnName("Price").IsRequired();
        builder.Property(g => g.EarnProofLink).HasColumnName("EarnProofLink").IsRequired();
        builder.Property(g => g.Status).HasColumnName("Status").IsRequired();
        builder.Property(g => g.SponsorId).HasColumnName("SponsorId").IsRequired();
        builder.Property(g => g.InfluencerId).HasColumnName("InfluencerId").IsRequired();
        builder.Property(g => g.SponsorReviewId).HasColumnName("SponsorReviewId").IsRequired();
        builder.Property(g => g.InfluencerReviewId).HasColumnName("InfluencerReviewId").IsRequired();
        builder.Property(g => g.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(g => g.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(g => g.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(g => !g.DeletedDate.HasValue);
    }
}