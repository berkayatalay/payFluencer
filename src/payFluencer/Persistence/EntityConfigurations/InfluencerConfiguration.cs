using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InfluencerConfiguration : IEntityTypeConfiguration<Influencer>
{
    public void Configure(EntityTypeBuilder<Influencer> builder)
    {
        builder.ToTable("Influencers").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(i => i.Name).HasColumnName("Name").IsRequired();
        builder.Property(i => i.Surname).HasColumnName("Surname").IsRequired();
        builder.Property(i => i.ProfilePicture).HasColumnName("ProfilePicture").IsRequired();
        builder.Property(i => i.About).HasColumnName("About").IsRequired();
        builder.Property(i => i.Rating).HasColumnName("Rating").IsRequired();
        builder.Property(i => i.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}