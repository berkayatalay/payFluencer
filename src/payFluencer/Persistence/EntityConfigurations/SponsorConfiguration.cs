using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
{
    public void Configure(EntityTypeBuilder<Sponsor> builder)
    {
        builder.ToTable("Sponsors").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(s => s.CompanyName).HasColumnName("CompanyName").IsRequired();
        builder.Property(s => s.ProfilePicture).HasColumnName("ProfilePicture").IsRequired();
        builder.Property(s => s.About).HasColumnName("About").IsRequired();
        builder.Property(s => s.Rating).HasColumnName("Rating").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}