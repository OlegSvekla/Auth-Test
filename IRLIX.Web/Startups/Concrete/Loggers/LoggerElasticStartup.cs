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
        services.AddBatchElasticLogging(appBuilder.Configuration);
        //services.AddTransient<LogEnrichPropertiesMiddleware>();
        // var sp = services.BuildServiceProvider();
        // sp.UseLogging();
        appBuilder.Host.UseSerilog();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseGlobalLoggerEnricher();
        
        app.Services.UseLogging();
        // using var scope = app.Services.CreateScope();
        // scope.ServiceProvider.UseLogging();
        return ValueTask.FromResult(app);
    }
}
