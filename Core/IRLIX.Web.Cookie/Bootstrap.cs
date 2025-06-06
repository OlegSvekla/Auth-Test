using IRLIX.Web.Cookie.Configs;
using IRLIX.Web.Cookie.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IRLIX.Web.Cookie;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebCookie(
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
        services.Configure<CookieConfig>(config.GetSection(Consts.WebCookieConfigSectionKey));
        services.AddSingleton<ICookieProvider, CookieProvider>();

        return services;
    }

    public static IApplicationBuilder UseWebCookie(
        this IApplicationBuilder app)
    {
        var cookieConfig = app.ApplicationServices.GetRequiredService<IOptions<CookieConfig>>().Value;
        var cookiePolicyOptions = new CookiePolicyOptions
        {
            MinimumSameSitePolicy = cookieConfig.MinimumSameSitePolicy,
            HttpOnly = cookieConfig.HttpOnly,
            Secure = cookieConfig.Secure,
            ConsentCookie = new CookieBuilder
            {
                IsEssential = cookieConfig.IsEssential,
                Expiration = TimeSpan.FromDays(cookieConfig.ExpirationDay)
            }
        };

        app.UseCookiePolicy(cookiePolicyOptions);
        return app;
    }
}
