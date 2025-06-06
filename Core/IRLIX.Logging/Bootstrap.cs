using IRLIX.Core.General;
using IRLIX.Logging.Configurators;
using IRLIX.Logging.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace IRLIX.Logging;

public static class Bootstrap
{
    public static IServiceCollection AddBatchLogging(
        this IServiceCollection services)
    {
        services.AddScoped<GlobalLoggerEnricherMiddleware>();
        services.AddTransient<ILoggerConfigurator, ConsoleSinker>();
        services.AddTransient<ILoggerConfigurator, LogEventLevelEnricher>();
        services.AddTransient<ILoggerConfigurator, LogContextEnricher>();
        services.AddTransient<ILoggerConfigurator, MachineNameEnricher>();
        return services;
    }

    public static IServiceProvider UseLogging(
        this IServiceProvider sp)
    {
        var configurators = sp.GetServices<ILoggerConfigurator>()?.ToList();
        //var globalEnricher = sp.GetRequiredService<GlobalLoggerEnricher>();

        if (configurators.IsNullOrEmpty())
        {
            throw new InvalidOperationException(nameof(configurators));
        }

        var loggerConfig = new LoggerConfiguration();
        //loggerConfig.Enrich.With(globalEnricher);
        configurators.ForEach(configurator => loggerConfig = configurator.Configure(loggerConfig));
        Log.Logger = loggerConfig.CreateLogger();
        return sp;
    }
    
    public static IApplicationBuilder UseGlobalLoggerEnricher(
        this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalLoggerEnricherMiddleware>();

        return app;
    }
}
