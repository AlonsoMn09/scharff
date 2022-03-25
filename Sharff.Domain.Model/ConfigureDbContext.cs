using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sharff.Domain.Model.DbContexts;
using Sharff.Domain.Model.DbModel;

namespace Sharff.Domain.Model
{
    public static class ConfigureDbContext
    {
        public static void AddSharffDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<SharffDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
