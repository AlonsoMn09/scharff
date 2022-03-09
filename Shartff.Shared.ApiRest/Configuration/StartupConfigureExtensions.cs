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


            //app.UseAuthentication();

            //app.UseAuthorization();

            app.UseResponseCaching();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var error = context.Features.Get<IExceptionHandlerFeature>().Error;
                var problem = new ProblemDetails { Title = "Error" };
                if (error != null)
                {
                    if (EnvironmentHelper.IsDebugEnvironment(env))
                    {
                        problem.Title = error.Message;
                        problem.Detail = error.StackTrace;
                    }
                    else
                        problem.Detail = error.Message;
                }
                await context.Response.WriteAsJsonAsync(problem);
            }));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //Health ckecks
                //endpoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
                //{
                //    ResultStatusCodes = {
                //        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                //        [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                //        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                //    },
                //    Predicate = (check) => check.Tags.Count == 0,
                //    AllowCachingResponses = false
                //});
            });
        }
    }
}
