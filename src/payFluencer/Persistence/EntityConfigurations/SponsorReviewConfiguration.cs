using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SponsorReviewConfiguration : IEntityTypeConfiguration<SponsorReview>
{
    public void Configure(EntityTypeBuilder<SponsorReview> builder)
    {
        builder.ToTable("SponsorReviews").HasKey(sr => sr.Id);

        builder.Property(sr => sr.Id).HasColumnName("Id").IsRequired();
        builder.Property(sr => sr.Rating).HasColumnName("Rating").IsRequired();
        builder.Property(sr => sr.Comment).HasColumnName("Comment").IsRequired();
        builder.Property(sr => sr.SponsorId).HasColumnName("SponsorId").IsRequired();
        builder.Property(sr => sr.InfluencerId).HasColumnName("InfluencerId").IsRequired();
        builder.Property(sr => sr.GigId).HasColumnName("GigId").IsRequired();
        builder.Property(sr => sr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sr => sr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sr => sr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sr => !sr.DeletedDate.HasValue);
    }
}