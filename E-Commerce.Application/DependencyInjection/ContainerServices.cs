using E_Commerce.Application.Mapping;
using E_Commerce.Application.Services;
using E_Commerce.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DependencyInjection
{
    public static class ContainerServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductServices,ProductServices>();
            services.AddScoped<ICategoryServices,CategoryServices>();

            return services;
        }
    }
}
