using IRLIX.Web.Identity.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace IRLIX.Web.Identity.Tokens;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebIdentityTokens(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddBatchWebIdentityTokensJwt(config);

        services.AddSingleton<IRefreshTokenGenerator, RefreshTokenGenerator>();

        return services;
    }
}
