using DManage.SystemManagement.Domain;
using DManage.SystemManagement.Infrastructure.Common.Interface;
using DManage.SystemManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DManage.SystemManagement.API
{
    public static class StartupExtension
    {
        internal static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SystemManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.Get<ConfigurationSettings>().SqlServerConnectionStringStudentDetail,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(SystemManagementDbContext).GetTypeInfo().Assembly.GetName().Name);
                    });
            }, ServiceLifetime.Scoped);

            return services;
        }

        internal static void InitialiseDatabase(this IServiceCollection services, int retries)
        {
            var retryPolicy = services.BuildServiceProvider().GetRequiredService<IRetryMechanism>();
            var policy = retryPolicy.CreatePolicy(retries,5, "");
            policy.Execute(() =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var dbcotext = serviceProvider.GetService<SystemManagementDbContext>();
                dbcotext.Database.Migrate();
            });
        }
    }
}
