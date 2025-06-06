using IRLIX.Web.Swagger.OperationFilters;
using IRLIX.Web.Swagger.SchemaFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace IRLIX.Web.Swagger;

public static class Bootstrap
{
    public static IServiceCollection AddBatchSwagger(
        this IServiceCollection services,
        IConfiguration configuration,
        string env)
    {
        var appVersion = configuration[Consts.AppVersionConfigSectionKey] ?? "1.0.0";
        var appTitle = Assembly.GetEntryAssembly()?.GetName().Name ?? "Default API";

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = appTitle,
                Version = $"{env}-{appVersion}"
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

            options.SchemaFilter<EnumSchemaFilter>();
            options.OperationFilter<EnumOperationFilter>();
        });

        return services;
    }

    public static IApplicationBuilder UseBatchSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
