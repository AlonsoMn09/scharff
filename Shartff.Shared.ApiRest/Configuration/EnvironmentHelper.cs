using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;



namespace Shartff.Shared.ApiRest.Configuration
{
    public class EnvironmentHelper
    {
        public static IConfigurationRoot GetEnvironmentConfiguration(string environmentName)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .Build();



            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();



            return configuration;
        }



        public static bool IsDebugEnvironment(IWebHostEnvironment env)
        {
            return env.IsDevelopment();
        }
    }
}