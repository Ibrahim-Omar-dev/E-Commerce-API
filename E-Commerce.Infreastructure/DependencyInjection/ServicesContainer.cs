using E_Commerce.Application.Services.Interfaces;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.Identity;
using E_Commerce.Domain.Interface;
using E_Commerce.Domain.IRepository;
using E_Commerce.Infrastructure.Logging;
using E_Commerce.Infreastructure.Data;
using E_Commerce.Infreastructure.MiddleWare;
using E_Commerce.Infreastructure.Repository;
using E_Commerce.Infreastructure.Repository.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
                    }));


            services.AddDefaultIdentity<AppUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                //Lockout prevents brute-force attacks (trying many passwords until one works).
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            var jwtSettings = config.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true; 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,

                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
            }); 

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("admin"));
            //    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("user"));
            //});

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAppLogger), typeof(SerlogLogger));

            services.AddScoped<IUserManagement, UserManagement>();
            services.AddScoped<IRoleManagement, RoleManagement>();
            services.AddScoped<ITokenManagement, TokenManagement>();

            return services;
        }

        public static IApplicationBuilder UseInfreastructureServices(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleWare>();
            return app;
        }
    }
}