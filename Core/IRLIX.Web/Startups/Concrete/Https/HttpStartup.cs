using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Https;

public class HttpStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchHttp();

        return ValueTask.FromResult(services);
    }
}
