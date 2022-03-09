using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Shartff.Shared.ApiRest.Configuration
{
    public static class SharedConfiguration
    {
        public static void AddSharedAPIRestServices(this IServiceCollection services, string apiName)
        {
            var serviceProvider = services.BuildServiceProvider();
            var env = serviceProvider.GetService<IWebHostEnvironment>();

            //Appsettings file
            var _configuration = EnvironmentHelper.GetEnvironmentConfiguration(env.EnvironmentName);

            services.AddSingleton<IConfiguration>(c => _configuration);

            services.AddApplicationInsightsTelemetry();

            services.AddResponseCaching();
            services.AddMemoryCache();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors();

            services.AddControllers()
                       .AddNewtonsoftJson();

            services.AddAuthorization();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = apiName, Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            //Authentication

            //Servicio para recuperar el contexto de la request
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
