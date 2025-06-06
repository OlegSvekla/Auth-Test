using IRLIX.Auth.Web.Mappers;
using IRLIX.Auth.Web.Models;

namespace IRLIX.Auth.Web;

internal static class Bootstrap
{
    internal static IServiceCollection AddBatchAuthWeb(
        this IServiceCollection services)
    {
        services.AddAuthWebMappers();
        services.AddAuthWebModels();

        return services;
    }
}
