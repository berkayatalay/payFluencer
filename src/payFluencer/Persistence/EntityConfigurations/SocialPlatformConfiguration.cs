using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SocialPlatformConfiguration : IEntityTypeConfiguration<SocialPlatform>
{
    public void Configure(EntityTypeBuilder<SocialPlatform> builder)
    {
        builder.ToTable("SocialPlatforms").HasKey(sp => sp.Id);

        builder.Property(sp => sp.Id).HasColumnName("Id").IsRequired();
        builder.Property(sp => sp.Name).HasColumnName("Name").IsRequired();
        builder.Property(sp => sp.Link).HasColumnName("Link").IsRequired();
        builder.Property(sp => sp.LogoPicture).HasColumnName("LogoPicture").IsRequired();
        builder.Property(sp => sp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sp => sp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sp => sp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sp => !sp.DeletedDate.HasValue);
    }
}