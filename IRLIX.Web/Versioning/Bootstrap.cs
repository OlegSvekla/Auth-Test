using Asp.Versioning;

namespace IRLIX.Web.Versioning;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebVersioning(
        this IServiceCollection services)
    {
        services
            .AddApiVersioning(option =>
            {
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

        return services;
    }
}
