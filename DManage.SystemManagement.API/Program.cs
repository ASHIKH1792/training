using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace DManage.SystemManagement.API
{
    public class Program
    {
        public static readonly string AppName = "SystemManagement";
        public static void Main(string[] args)
        {
            try
            {
                var configuration = GetConfiguration();
                CreateHostBuilder(args, configuration).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Program terminated {AppName}!", AppName);

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args).UseSerilog((builderContext, config) =>
            {
                config
                    .MinimumLevel.Verbose()
                    .Enrich.WithProperty("ApplicationContext", AppName)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File(string.IsNullOrWhiteSpace(configuration["LogFilePath"]) ? "Logs.txt" : configuration["LogFilePath"])
                    .ReadFrom.Configuration(configuration);
            }).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}
