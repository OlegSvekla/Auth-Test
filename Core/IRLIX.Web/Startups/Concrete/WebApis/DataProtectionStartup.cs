using IRLIX.Web.Startups.Abstracts;
using ShuttleX.Web.DataProtections;

namespace IRLIX.Web.Startups.Concrete.WebApis;

public sealed class DataProtectionStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchDataProtection();

        return ValueTask.FromResult(services);
    }
}
