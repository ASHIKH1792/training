using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DManage.SystemManagement.Infrastructure.Persistence
{
    class SystemManagementDesignFactory : IDesignTimeDbContextFactory<SystemManagementDbContext>
    {
        public SystemManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SystemManagementDbContext>()
               .UseSqlServer("Data Source=localhost,5533;Initial Catalog=SystemManagement;user Id=sa;Password=Pa55word");
            return new SystemManagementDbContext(optionsBuilder.Options);
        }
    }
}
