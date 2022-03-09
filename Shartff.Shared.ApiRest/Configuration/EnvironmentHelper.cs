using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Shartff.Shared.ApiRest.Configuration
{
    public class EnvironmentHelper
    {
        public static IConfigurationRoot GetEnvironmentConfiguration(string environmentName)
        {
            return new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                                .Build();
        }

        public static bool IsDebugEnvironment(IWebHostEnvironment env)
        {
            return env.IsDevelopment();
        }
    }
}
