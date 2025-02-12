using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Content).HasColumnName("Content").IsRequired();
        builder.Property(m => m.SenderUserId).HasColumnName("SenderUserId").IsRequired();
        builder.Property(m => m.RecieverUserId).HasColumnName("RecieverUserId").IsRequired();
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}