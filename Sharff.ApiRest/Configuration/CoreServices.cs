using Microsoft.Extensions.DependencyInjection;
using Sharff.Core.Services;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model.DbContexts;
using Sharff.Domain.Model.DbContexts.Interfaces;

namespace Sharff.ApiRest.Configuration
{
    public static class CoreServices
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IDataManager, RepositoryManager>();

            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<IGuiaService, GuiaService>();
            services.AddScoped<ILogService, LogService>();
        }
    }
}
