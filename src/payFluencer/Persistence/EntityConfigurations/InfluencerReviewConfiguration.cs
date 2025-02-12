using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InfluencerReviewConfiguration : IEntityTypeConfiguration<InfluencerReview>
{
    public void Configure(EntityTypeBuilder<InfluencerReview> builder)
    {
        builder.ToTable("InfluencerReviews").HasKey(ir => ir.Id);

        builder.Property(ir => ir.Id).HasColumnName("Id").IsRequired();
        builder.Property(ir => ir.Rating).HasColumnName("Rating").IsRequired();
        builder.Property(ir => ir.Comment).HasColumnName("Comment").IsRequired();
        builder.Property(ir => ir.InfluencerId).HasColumnName("InfluencerId").IsRequired();
        builder.Property(ir => ir.SponsorId).HasColumnName("SponsorId").IsRequired();
        builder.Property(ir => ir.GigId).HasColumnName("GigId").IsRequired();
        builder.Property(ir => ir.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ir => ir.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ir => ir.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ir => !ir.DeletedDate.HasValue);
    }
}