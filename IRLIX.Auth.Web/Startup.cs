using IRLIX.Web.Startups.Abstracts;
using IRLIX.Web.Startups;
using IRLIX.BL;

namespace IRLIX.Auth.Web;

internal sealed class Startup : ServiceStartup
{
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Highest;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchBL();
        services.AddBatchAuthWeb();

        return ValueTask.FromResult(services);
    }
}
