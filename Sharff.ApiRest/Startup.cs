using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Sharff.ApiRest.Configuration;
using Sharff.Domain.Model.DbContexts;
using Shartff.Shared.ApiRest.Configuration;

namespace Sharff.ApiRest
{
    public class Startup
    {
        private readonly string _apiName = "Sharff.ApiRest";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSharedAPIRestServices(_apiName);

            //Appsettings file
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<SharffDbContext>(options => options.UseNpgsql(this.Configuration.GetConnectionString("DbConnetion")));
                
            services.AddCoreServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.SharedConfigure(env, _apiName);
            app.UseSerilogRequestLogging();
        }
    }
}
