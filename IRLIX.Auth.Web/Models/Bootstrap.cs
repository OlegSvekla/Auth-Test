using FluentValidation;

namespace IRLIX.Auth.Web.Models;

internal static class Bootstrap
{
    internal static IServiceCollection AddAuthWebModels(
        this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Program>();

        return services;
    }
}
