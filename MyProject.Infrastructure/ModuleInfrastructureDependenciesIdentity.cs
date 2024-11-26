using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Data.Entities;
using MyProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure
{
    public static class ModuleInfrastructureDependenciesIdentity
    {

        public static IServiceCollection AddRegisterModuleInfrastructureDependencies(this IServiceCollection services)
        {
           
            services.AddIdentity<ApplicationUser,IdentityRole>(option =>
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


            return services;
        }
    }
        
}
