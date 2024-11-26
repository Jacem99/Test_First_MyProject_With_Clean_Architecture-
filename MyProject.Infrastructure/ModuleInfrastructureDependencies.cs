using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Data.Entities;
using MyProject.Infrastructure.IRepository;
using MyProject.Infrastructure.Repository;

namespace MyProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services) {

           services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
           services.AddScoped<IStudentRepository, StudentRepository>() ;
           services.AddScoped<ISubjectRepository, SubjectRepository>();
           services.AddScoped<ISubjectRepository, SubjectRepository>();

            return services;
        }
    }
}
