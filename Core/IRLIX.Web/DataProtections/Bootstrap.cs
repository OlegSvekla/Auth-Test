using Microsoft.AspNetCore.DataProtection;

namespace IRLIX.Web.DataProtections;

public static class Bootstrap
{
    public static IServiceCollection AddBatchDataProtection(
        this IServiceCollection services)
    {
        services
            .AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"./keys"));

        return services;
    }
}
