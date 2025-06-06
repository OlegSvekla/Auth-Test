using IRLIX.Http.Polly;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Https;

public class HttpPollyStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchHttpPolly(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
