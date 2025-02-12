using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.Rating).HasColumnName("Rating").IsRequired();
        builder.Property(r => r.Comment).HasColumnName("Comment").IsRequired();
        builder.Property(r => r.GigId).HasColumnName("GigId").IsRequired();
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}