using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Contexts;

/// <summary>
/// Context services.
/// Contains Call context injections
/// </summary>
public sealed class ContextStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchContext();

        return ValueTask.FromResult(services);
    }
}
