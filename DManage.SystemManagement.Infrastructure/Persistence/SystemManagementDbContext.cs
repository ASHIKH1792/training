using DManage.SystemManagement.Infrastructure.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

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


        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        private void OnBeforeSaving()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Metadata.FindProperty("CreatorUserId") != null)
                {
                    AddAudit(item);
                }
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
