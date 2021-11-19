using DManage.SystemManagement.Domain.Entities;
using DManage.SystemManagement.Infrastructure.Common.Interface;
using DManage.SystemManagement.Infrastructure.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DManage.SystemManagement.Infrastructure.Persistence
{
    public class SystemManagementDbContext : DbContext
    {
        private readonly IUserService _userService;
        public SystemManagementDbContext(DbContextOptions options, IUserService userService) : base(options)
        {
            _userService = userService;
        }

        public SystemManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WareHouse> WareHouse { get; set; }

        public DbSet<ProductType> ProductType { get; set; }

        public DbSet<Node> Node { get; set; }
        public DbSet<LicensePlateNumber> LicensePlateNumber { get; set; }
        public DbSet<WareHouseProductTypeMapping> WareHouseProductTypeMapping { get; set; }
        public DbSet<WareHouseNodeMapping> WareHouseNodeMapping { get; set; }
        public DbSet<Pallet> Pallet { get; set; }

        public DbSet<PalletLpnMapping> PalletLpnMapping { get; set; }

        public DbSet<Trucks> Trucks { get; set; }

        public DbSet<Drivers> Drivers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WareHouseEntityConfiguration());
            builder.ApplyConfiguration(new NodeEntityConfiguration());
            builder.ApplyConfiguration(new PalletEntityConfiguration());
            builder.ApplyConfiguration(new ProductTypeEntityConfiguration());
            base.OnModelCreating(builder);
        }
        private void OnBeforeSaving()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                AddAudit(item);
            }
        }

        private void AddAudit(EntityEntry entry)
        {
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsDeleted"] = true;
                    entry.CurrentValues["DeletedUserId"] = _userService.GetUserId();
                    entry.CurrentValues["DeletionTime"] = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Added;
                    entry.CurrentValues["IsDeleted"] = false;
                    entry.CurrentValues["CreatorUserId"] = _userService.GetUserId();
                    entry.CurrentValues["CreationTime"] = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsDeleted"] = false;
                    entry.CurrentValues["ModifiedUserId"] = _userService.GetUserId();
                    entry.CurrentValues["ModificationTime"] = DateTime.UtcNow;
                    break;

            }
        }
    }
}
