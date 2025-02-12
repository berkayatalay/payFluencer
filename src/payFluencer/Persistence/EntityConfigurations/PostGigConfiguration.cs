using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PostGigConfiguration : IEntityTypeConfiguration<PostGig>
{
    public void Configure(EntityTypeBuilder<PostGig> builder)
    {
        builder.ToTable("PostGigs").HasKey(pg => pg.Id);

        builder.Property(pg => pg.Id).HasColumnName("Id").IsRequired();
        builder.Property(pg => pg.PostId).HasColumnName("PostId").IsRequired();
        builder.Property(pg => pg.GigId).HasColumnName("GigId").IsRequired();
        builder.Property(pg => pg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pg => pg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pg => pg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pg => !pg.DeletedDate.HasValue);
    }
}