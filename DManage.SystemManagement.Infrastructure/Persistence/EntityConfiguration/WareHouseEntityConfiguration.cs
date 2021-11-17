using DManage.SystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DManage.SystemManagement.Infrastructure.Persistence.EntityConfiguration
{
    public class WareHouseEntityConfiguration : IEntityTypeConfiguration<WareHouse>
    {
        public void Configure(EntityTypeBuilder<WareHouse> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
