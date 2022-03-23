using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sharff.Core.Services;
using Sharff.Core.Services.Interfaces;
using Sharff.Domain.Model;

namespace Sharff.ApiRest.Configuration
{
    public static class CoreServices
    {
        private static IConfiguration _configuration;

        public static void AddCoreServices(this IServiceCollection services)
        {
            //Appsettings file
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSharffDbContext(_configuration.GetConnectionString("DbConnetion"));

            services.AddScoped<IExampleService, ExampleService>();
        }
    }
}
