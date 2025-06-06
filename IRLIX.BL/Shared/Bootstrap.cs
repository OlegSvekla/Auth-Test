using IRLIX.BL.Shared.HttpClaims;
using IRLIX.BL.Shared.Lockouts;
using IRLIX.BL.Shared.Modifiers.Creators;
using IRLIX.BL.Shared.Modifiers.Searchers;
using IRLIX.BL.Shared.Modifiers.Updaters;
using IRLIX.BL.Shared.Modifiers.Validators.SignInAttempts;
using IRLIX.BL.Shared.Modifiers.Validators.Users;
using IRLIX.Web.Identity.Tokens.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace ShuttleX.Auth.Shared;

public static class Bootstrap
{
    public static IServiceCollection AddBatchAuthShared(
        this IServiceCollection services)
    {
        services.OverrideAndAddScoped<IJwtClaimsEnricher, AuthJwtClaimsEnricher>();

        services.AddScoped<IUserLockoutSetter, UserLockoutSetter>();

        services.AddScoped<ISessionCreator, SessionCreator>();
        services.AddScoped<ISignInAttemptCreator, SignInAttemptCreator>();
        services.AddScoped<IUserCreator, UserCreator>();

        services.AddScoped<ISessionsExpirationUpdater, SessionsExpirationUpdater>();
        services.AddScoped<ISignInAttemptByCodeUpdater, SignInAttemptByCodeUpdater>();
        services.AddScoped<IUserFieldConfirmedUpdater, UserFieldConfirmedUpdater>();

        services.AddScoped<IUserWithEmailSearcher, UserWithEmailSearcher>();
        services.AddScoped<IUserWithPhoneSearcher, UserWithPhoneSearcher>();

        services.AddScoped<ILastSignInAttemptValidator, LastSignInAttemptValidator>();
        services.AddScoped<IAccessFailedCountValidator, SignInAttemptsCountValidator>();
        services.AddScoped<IUserWithSameEmailExistValidator, UserWithSameEmailExistValidator>();

        return services;
    }
}
