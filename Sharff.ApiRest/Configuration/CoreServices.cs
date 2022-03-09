using Microsoft.Extensions.DependencyInjection;
using Sharff.Core.Services;
using Sharff.Core.Services.Interfaces;

namespace Sharff.ApiRest.Configuration
{
    public static class CoreServices
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IExampleService, ExampleService>();
        }
    }
}
