using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyProject.Data.Entities;
using MyProject.Data.Helper;
using MyProject.Infrastructure.Data;

namespace MyProject.Infrastructure
{
    public static class ModuleInfrastructureDependenciesIdentity
    {

        public static IServiceCollection AddRegisterModuleInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.SignIn.RequireConfirmedEmail = true;
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;

                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.AllowedForNewUsers = true;

                option.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders
                ();

            var JwtSettings = new JwtSettings();
            configuration.GetSection(nameof(JwtSettings)).Bind(JwtSettings);

            services.AddSingleton(JwtSettings);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = JwtSettings.ValidateIssuer,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidateIssuerSigningKey = JwtSettings.ValidateIssuerSigningKey,
                    ValidateAudience = JwtSettings.ValidateAudience,
                    ValidAudience = JwtSettings.Audience,
                    ValidateLifetime = JwtSettings.ValidateLifetime,
                };
            });


            return services;
        }
    }

}
