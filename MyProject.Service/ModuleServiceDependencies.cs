using Microsoft.Extensions.DependencyInjection;
using MyProject.Infrastructure.IRepository;
using MyProject.Infrastructure.Repository;
using MyProject.Service.IServices;
using MyProject.Service.Services;


namespace MyProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentServiece, StudentServiece>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }

    }
}
