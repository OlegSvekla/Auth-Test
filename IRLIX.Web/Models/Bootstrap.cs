using ShuttleX.Web.Models.Rqs;

namespace ShuttleX.Web.Models;

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
