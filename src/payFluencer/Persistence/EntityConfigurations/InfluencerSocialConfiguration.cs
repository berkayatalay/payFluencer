using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InfluencerSocialConfiguration : IEntityTypeConfiguration<InfluencerSocial>
{
    public void Configure(EntityTypeBuilder<InfluencerSocial> builder)
    {
        builder.ToTable("InfluencerSocials").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
        builder.Property(i => i.Link).HasColumnName("Link").IsRequired();
        builder.Property(i => i.InfluencerId).HasColumnName("InfluencerId").IsRequired();
        builder.Property(i => i.SocialId).HasColumnName("SocialId").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}