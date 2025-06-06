using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace IRLIX.Di.Helpers;

public static class ServiceCollectionHelper
{
    public static IServiceCollection OverrideAndAddScoped<
        TService,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImpl>(
        this IServiceCollection services)
        where TService : class
        where TImpl : class, TService
    {
        services.RemoveAll<TService>();
        services.AddScoped<TService, TImpl>();
        return services;
    }

    public static IServiceCollection OverrideAndAddScoped<
        TService,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImpl>(
        this IServiceCollection services,
        Func<IServiceProvider, TImpl> implFactory)
        where TService : class
        where TImpl : class, TService
    {
        services.RemoveAll<TService>();
        services.AddScoped<TService, TImpl>(implFactory);
        return services;
    }
}
