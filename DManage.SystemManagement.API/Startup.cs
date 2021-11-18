using DManage.SystemManagement.API.Filter;
using DManage.SystemManagement.Application.AutoMapper;
using DManage.SystemManagement.Application.Dependency;
using DManage.SystemManagement.Domain.Interface;
using DManage.SystemManagement.Infrastructure.Common.Interface;
using DManage.SystemManagement.Infrastructure.Common.Service;
using DManage.SystemManagement.Infrastructure.Repository;
using DManage.SystemManagement.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DManage.SystemManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(GlobalApiExceptionFilter));
            });
            services.AddHttpContextAccessor();
            //Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DManage",
                    Version = "v1"
                });
                options.DocInclusionPredicate((docName, description) => true);

                //Note: This is just for showing Authorize button on the UI. 
                //Authorize button's behaviour is handled in wwwroot/swagger/ui/index.html
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme());
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
