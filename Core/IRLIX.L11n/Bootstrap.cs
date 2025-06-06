using IRLIX.Di.Configs;
using IRLIX.L11n.Configs;
using IRLIX.L11n.Providers;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace IRLIX.L11n;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebL11n(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsWebL11n(config);
        services.AddCoreWebL11n(config);

        return services;
    }

    public static IServiceCollection AddCoreWebL11n(
        this IServiceCollection services,
        IConfiguration config)
    {
        var l11nConfig = config.Extract<L11nConfig>(Consts.WebL11nSectionKey);
        var resourcesPath = l11nConfig.ResourcesPath;
        var defaultCulture = l11nConfig.DefaultCulture;
        var supportedCultures = l11nConfig.SupportedCultures;

        services.AddLocalization(options => options.ResourcesPath = resourcesPath);
        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture(defaultCulture);
            options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
            options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
        });

        services.AddScoped<ICultureSetup, CultureSetup>();
        services.AddScoped<CultureStorage>();
        services.AddScoped<ICultureInitializer, CultureStorage>(sp => sp.GetRequiredService<CultureStorage>());
        services.AddScoped<ICultureProvider, CultureStorage>(sp => sp.GetRequiredService<CultureStorage>());

        return services;
    }

    public static IServiceCollection AddAppSettingsWebL11n(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<L11nConfig>(config.GetSection(Consts.WebL11nSectionKey));
        services.AddSingleton<IL11nConfigProvider, L11nConfigProvider>();

        return services;
    }

    public static IApplicationBuilder UseWebL11n(
        this IApplicationBuilder app)
    {
        var localizationOptions = app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
        app.UseRequestLocalization(localizationOptions);

        app.UseMiddleware<RequestLocalizationMiddleware>();

        return app;
    }
}
