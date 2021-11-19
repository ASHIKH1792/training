using DManage.SystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DManage.SystemManagement.Infrastructure.Persistence.EntityConfiguration
{
    public class DriverEntityConfiguration : IEntityTypeConfiguration<Drivers>
    {
        public void Configure(EntityTypeBuilder<Drivers> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.MobileNumber)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
