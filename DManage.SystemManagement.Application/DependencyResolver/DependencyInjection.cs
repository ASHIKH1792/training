using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using DManage.SystemManagement.Application.Common;
using System.Reflection;
using DManage.SystemManagement.Application.Queries.Internal;
using DManage.SystemManagement.Application.Queries;

namespace DManage.SystemManagement.Application.Dependency
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());           
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped<IWareHouseQueries, WareHouseQueries>();
            return services;
        }
    }
}
