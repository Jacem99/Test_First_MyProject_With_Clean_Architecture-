using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace MyProject.Core
{
    public static class ModuleCoreDependenciesLocalization
    {
        public static IServiceCollection AddModuleCoreDependenciesLocalization(this IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });
            services.Configure<RequestLocalizationOptions>(option =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar-EG"),
        new CultureInfo("de-DE"),
        new CultureInfo("fr-FR")
    };
                option.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar");
                option.SupportedCultures = supportedCultures;
                option.SupportedUICultures = supportedCultures;
            });


            return services;
        }
    }
}
