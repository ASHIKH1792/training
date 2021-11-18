using DManage.SystemManagement.Domain;
using DManage.SystemManagement.Infrastructure.Common.Interface;
using DManage.SystemManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Reflection;

namespace DManage.SystemManagement.API
{
    public static class StartupExtension
    {
        internal static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SystemManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.Get<ConfigurationSettings>().SqlServerConnectionString,
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

        internal static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddCap(options =>
            {
                options.UseSqlServer(configuration.Get<ConfigurationSettings>().SqlServerConnectionString);
                options.UseRabbitMQ(conf =>
                {
                    conf.ConnectionFactoryOptions = (factory) =>
                    {
                        ConnectionFactory(factory, configuration);
                    };
                });

                if (configuration.Get<ConfigurationSettings>().EventBusRetryCount != 0)
                {
                    options.FailedRetryCount = configuration.Get<ConfigurationSettings>().EventBusRetryCount;
                }

                if (!string.IsNullOrEmpty(configuration.Get<ConfigurationSettings>().SubscriptionClientName))
                {
                    options.DefaultGroupName = configuration.Get<ConfigurationSettings>().SubscriptionClientName;
                }
            });

            return services;
        }

        private static void ConnectionFactory(ConnectionFactory factory, IConfiguration configuration)
        {
            if (configuration.Get<ConfigurationSettings>().EventBusConnection.StartsWith("amqp"))
            {
                factory.Uri = new Uri(configuration.Get<ConfigurationSettings>().EventBusConnection);
            }
            else
            {
                factory.HostName = configuration.Get<ConfigurationSettings>().EventBusConnection;
            }
            factory.UserName = configuration.Get<ConfigurationSettings>().EventBusUserName ?? string.Empty;
            factory.Password = configuration.Get<ConfigurationSettings>().EventBusPassword ?? string.Empty;

            if (configuration.Get<ConfigurationSettings>().EventBusPort != 0)
                factory.Port = configuration.Get<ConfigurationSettings>().EventBusPort;
            if (!string.IsNullOrWhiteSpace(configuration.Get<ConfigurationSettings>().EventBusVirtualHost))
                factory.VirtualHost = configuration.Get<ConfigurationSettings>().EventBusVirtualHost;
        }
    }
}
