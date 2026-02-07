using E_Commerce.Domain.Entities;
using E_Commerce.Domain.IRepository;
using E_Commerce.Infreastructure.Data;
using E_Commerce.Infreastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infreastructure.DependencyInjection
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddInfreastructureServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(
                    config.GetConnectionString("DefaultConnection"),
                    sqloption =>
                    {
                        sqloption.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                        sqloption.EnableRetryOnFailure();
                    })); // Removed explicit ServiceLifetime.Scoped as it's the default

            // Register generic repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}