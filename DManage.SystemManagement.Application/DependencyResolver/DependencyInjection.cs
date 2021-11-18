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

            #region Queries
            services.AddScoped<IWareHouseQueries, WareHouseQueries>();
            services.AddScoped<IWareHouseNodeQueries, WareHouseNodeQueries>();
            services.AddScoped<IWareHouseProductTypeQueries, WareHouseProductTypeQueries>();
            services.AddScoped<IPalletLpnQueries, PalletLpnQueries>();
            services.AddScoped<IPalletQueries, PalletQueries>();
            services.AddScoped<INodesQueries, NodesQueries>();
            services.AddScoped<ILpnQueries, LpnQueries>();
            services.AddScoped<IProductTypeQueries, ProductTypeQueries>();
            #endregion
            return services;
        }
    }
}
