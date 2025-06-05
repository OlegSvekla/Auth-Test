using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace IRLIX.Core.Di.Helpers;

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
