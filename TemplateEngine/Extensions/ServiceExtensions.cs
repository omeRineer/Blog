using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using RazorLight;

namespace TemplateEngine.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRazorLight(this IServiceCollection services, Action<RazorLightOptions> options)
        {
            services.AddRazorLight(options);

            return services;
        }
    }
}
