using DManage.SystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DManage.SystemManagement.Infrastructure.Persistence.EntityConfiguration
{
    public class PalletEntityConfiguration : IEntityTypeConfiguration<Pallet>
    {
        public void Configure(EntityTypeBuilder<Pallet> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
