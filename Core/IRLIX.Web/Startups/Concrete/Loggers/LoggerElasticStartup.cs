using IRLIX.Logging;
using IRLIX.Web.Startups.Abstracts;
using Serilog;

namespace IRLIX.Web.Startups.Concrete.Loggers;

/// <summary>
/// Logger.
/// Setup logger functionality with predefault configuration
/// </summary>
public sealed class LoggerElasticStartup : BaseStartup
{
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Medium;

    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Logger;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder appBuilder)
    {
        services.AddBatchLogging();
        appBuilder.Host.UseSerilog();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseGlobalLoggerEnricher();
       
        app.Services.UseLogging();

        return ValueTask.FromResult(app);
    }
}
