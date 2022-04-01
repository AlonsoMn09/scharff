using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Shartff.Shared.ApiRest.Configuration
{
    public static class StartupConfigureExtensions
    {
        public static void SharedConfigure(this IApplicationBuilder app, IWebHostEnvironment env, string apiName)
        {
            if (EnvironmentHelper.IsDebugEnvironment(env))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", $"{apiName} v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseResponseCaching();

            app.UseExceptionHandler(err => err.UseCustomErrors(env));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
