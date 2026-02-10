using E_Commerce.Application.Mapping;
using E_Commerce.Application.Services;
using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Application.Validation;
using E_Commerce.Application.Validation.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Application.DependencyInjection
{
    public static class ContainerServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<LoginUserValidation>();
            services.AddScoped<IValidationServices, ValidationServices>();
            return services;
        }
    }
}