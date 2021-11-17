using DManage.SystemManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DManage.SystemManagement.Infrastructure.Persistence.EntityConfiguration
{
    public class NodeEntityConfiguration : IEntityTypeConfiguration<Node>
    {
        public void Configure(EntityTypeBuilder<Node> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
