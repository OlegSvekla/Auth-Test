using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Wxs;

public class WxOpenWeatherStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWxOpenWeather(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
