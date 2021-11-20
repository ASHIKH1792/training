using DManage.SystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DManage.SystemManagement.Infrastructure.Persistence.EntityConfiguration
{
    public class ProductTypeEntityConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.ReferenceId).HasDefaultValueSql("NEWID()");
        }
    }
}
