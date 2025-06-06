using IRLIX.Web.Validation.FluentValidation.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace IRLIX.Web.Validation.FluentValidation;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebValidationFluentValidation(
        this IServiceCollection services)
    {
        services.AddScoped<ValidationMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseValidation(
        this IApplicationBuilder app)
    {
        app.UseMiddleware<ValidationMiddleware>();

        return app;
    }
}
