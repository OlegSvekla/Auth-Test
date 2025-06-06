using IRLIX.Web.Startups;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Auth.Web;

internal sealed class UseJobsStartup : ServiceStartup
{
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Highest;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        var lifetime = provider.GetRequiredService<IHostApplicationLifetime>();
        var ct = lifetime.ApplicationStopping;

        JobsRegistrator.StartupJobs(scope, ct);

        return ValueTask.FromResult(services);
    }
}
