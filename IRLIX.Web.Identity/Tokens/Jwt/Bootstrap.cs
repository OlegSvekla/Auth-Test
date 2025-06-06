using IRLIX.Web.Identity.Tokens.Jwt.Configs;
using IRLIX.Web.Identity.Tokens.Jwt.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace IRLIX.Web.Identity.Tokens.Jwt;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebIdentityTokensJwt(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsWebIdentityTokensJwt(config);
        services.AddCoreWebIdentityTokensJwt(config);

        return services;
    }

    public static IServiceCollection AddCoreWebIdentityTokensJwt(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IJwtClaimsEnricher, DefaultJwtClaimsEnricher>();
        services.AddScoped<IHttpClaimsExtractor, JwtClaimsExtractor>();

        var jwtConfig = config.Extract<JwtConfig>(Consts.WebIdentityJwtSectionKey);

        var authBuilder = services.AddAuthentication(
            authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = jwtConfig.AuthScheme;
                authOptions.DefaultChallengeScheme = jwtConfig.AuthScheme;
                authOptions.DefaultScheme = jwtConfig.AuthScheme;
            });

        if (!JwtBearerDefaults.AuthenticationScheme.Equals(jwtConfig.AuthScheme, StringComparison.OrdinalIgnoreCase))
        {
            throw new NotImplementedException();
        }

        var symmetricSecurityKeyBytes = Encoding.UTF8.GetBytes(jwtConfig.SigningSecretKey);
        var signingKey = new SymmetricSecurityKey(symmetricSecurityKeyBytes);

        authBuilder.AddJwtBearer(jwtOptions
            => jwtOptions
                .TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = signingKey,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.IssuerAuthHost,
                    ValidateIssuer = true,
                    ValidAudience = jwtConfig.AudienceAuthHost,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RoleClaimType = ClaimTypes.Role
                });

        services
            .AddAuthorizationBuilder()
            .SetDefaultPolicy(new AuthorizationPolicyBuilder(jwtConfig.AuthScheme)
                .RequireAuthenticatedUser()
                .Build());

        //services.AddAuthorization(options
        //    => options.DefaultPolicy = new AuthorizationPolicyBuilder(jwtConfig.AuthScheme)
        //        .RequireAuthenticatedUser()
        //        .Build());

        return services;
    }

    public static IServiceCollection AddAppSettingsWebIdentityTokensJwt(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<JwtConfig>(config.GetSection(Consts.WebIdentityJwtSectionKey));
        services.AddSingleton<IJwtConfigProvider, JwtConfigProvider>();

        return services;
    }
}
