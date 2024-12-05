using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped(typeof(IApplicationUserService), typeof(ApplicationUserService));
            services.AddScoped(typeof(IAuthenticationUserService), typeof(AuthenticationUserService));
            services.AddTransient(typeof(IEmailService), typeof(EmailService));

            return services;
        }

    }
}
