using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sharff.Core.Services;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model;

namespace Sharff.ApiRest.Configuration
{
    public static class CoreServices
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<IGuiaService, GuiaService>();
            services.AddScoped<ILogService, LogService>();
        }
    }
}
