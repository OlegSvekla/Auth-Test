using IRLIX.Web.Models.Rqs;

namespace IRLIX.Web.Models;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebModelValidators(
        this IServiceCollection services)
    {
        services.AddScoped<IValidator<SearchQueryRq>, SearchQueryRqValidator>();
        services.AddScoped<IValidator<SearchWithDeletedQueryRq>, SearchWithDeletedQueryRqValidator>();

        return services;
    }
}
