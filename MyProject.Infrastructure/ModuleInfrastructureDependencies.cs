using Microsoft.Extensions.DependencyInjection;
using MyProject.Infrastructure.IRepository;
using MyProject.Infrastructure.Repository;

namespace MyProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) {

           services.AddScoped<IStudentRepository, StudentRepository>();

          services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));

            return services;
        }
    }
}
