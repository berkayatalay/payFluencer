using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DisputeConfiguration : IEntityTypeConfiguration<Dispute>
{
    public void Configure(EntityTypeBuilder<Dispute> builder)
    {
        builder.ToTable("Disputes").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.Title).HasColumnName("Title").IsRequired();
        builder.Property(d => d.Description).HasColumnName("Description").IsRequired();
        builder.Property(d => d.Status).HasColumnName("Status").IsRequired();
        builder.Property(d => d.GigId).HasColumnName("GigId").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}