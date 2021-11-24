using DManage.SystemManagement.API.Filter;
using DManage.SystemManagement.Application.AutoMapper;
using DManage.SystemManagement.Application.Dependency;
using DManage.SystemManagement.Domain;
using DManage.SystemManagement.Domain.Interface;
using DManage.SystemManagement.Infrastructure.Common.Interface;
using DManage.SystemManagement.Infrastructure.Common.Service;
using DManage.SystemManagement.Infrastructure.Repository;
using DManage.SystemManagement.Infrastructure.UnitOfWork;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace DManage.SystemManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConfigurationSettings>(Configuration);
            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(GlobalApiExceptionFilter));
            });
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DManage",
                    Version = "v1"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });

            });
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = Configuration.Get<ConfigurationSettings>().Authority;
                options.Audience = Configuration.Get<ConfigurationSettings>().Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuers = Configuration.Get<ConfigurationSettings>().IssuerUri,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.Get<ConfigurationSettings>().ApiSecret.ToSha256()))
                };
                options.RequireHttpsMetadata = false;
            });
            services.AddScoped<IRetryMechanism, RetryMechanism>();
            services.AddCustomDbContext(Configuration);
            services.InitialiseDatabase(Configuration.GetValue<int>("InitialiseDatabaseRetryCount"));
            services.AddEventBus(Configuration);
            services.AddScoped<IUserService, UserService>();            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddApplication();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "SystemManagement");
            });
        }
    }
}
