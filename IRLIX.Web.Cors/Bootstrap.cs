using IRLIX.Web.Cors.Configs;
using IRLIX.Web.Cors.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IRLIX.Web.Cors;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebCors(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsCommEmailGmail(config);

        return services;
    }

    public static IServiceCollection AddAppSettingsCommEmailGmail(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<CorsConfig>(config.GetSection(Consts.WebCorsConfigSectionKey));
        services.AddSingleton<ICorsProvider, CorsProvider>();

        return services;
    }

    public static IApplicationBuilder UseWebCors(
        this IApplicationBuilder app)
    {
        var corsConfig = app.ApplicationServices.GetRequiredService<IOptions<CorsConfig>>().Value;

        app.UseCors(builder => builder
            .WithOrigins(corsConfig.AllowedOrigins)
            .AllowAnyHeader()
            .AllowCredentials()
            .WithMethods(corsConfig.AllowedMethods));
        return app;
    }
}
