using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shartff.Shared.ApiRest.Configuration
{
    public static class ErrorHandlingMiddelware
    {
        public class Result
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }

        private static IHostEnvironment env;

        public static void UseCustomErrors(this IApplicationBuilder app, IHostEnvironment enviroment)
        {
            env = enviroment;
            app.Use(WriteResponse);
        }

        private static async Task WriteResponse(HttpContext httpContext, Func<Task> next)
        {
            var exceptionDetails = httpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionDetails.Error;
            Result problem = null;
            string traceId = null;
            if (ex != null)
            {
                problem = new Result();
                httpContext.Response.ContentType = "application/problem+json";

                var title = $"Ocurrio un error: {ex.Message}";
                var details = ex.ToString();

                if (env.IsDevelopment())
                {
                    problem.StatusCode = httpContext.Response.StatusCode;
                    problem.Message = ex.StackTrace;
                }
                else
                {
                    problem.Message = title;
                }

                traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            }
            Log.Error(ex, traceId);

            await httpContext.Response.WriteAsJsonAsync(problem);
        }
    }
}