using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SupportTicketConfiguration : IEntityTypeConfiguration<SupportTicket>
{
    public void Configure(EntityTypeBuilder<SupportTicket> builder)
    {
        builder.ToTable("SupportTickets").HasKey(st => st.Id);

        builder.Property(st => st.Id).HasColumnName("Id").IsRequired();
        builder.Property(st => st.Category).HasColumnName("Category").IsRequired();
        builder.Property(st => st.Title).HasColumnName("Title").IsRequired();
        builder.Property(st => st.Content).HasColumnName("Content").IsRequired();
        builder.Property(st => st.Status).HasColumnName("Status").IsRequired();
        builder.Property(st => st.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(st => st.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(st => st.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(st => !st.DeletedDate.HasValue);
    }
}