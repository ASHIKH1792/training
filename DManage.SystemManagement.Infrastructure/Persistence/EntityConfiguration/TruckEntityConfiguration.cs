using DManage.SystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DManage.SystemManagement.Infrastructure.Persistence.EntityConfiguration
{
    public class TruckEntityConfiguration : IEntityTypeConfiguration<Trucks>
    {
        public void Configure(EntityTypeBuilder<Trucks> builder)
        {
            builder.Property(t => t.RegistrationNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Model)
              .HasMaxLength(50)
              .IsRequired();
        }
    }
}
