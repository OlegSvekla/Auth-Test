using Serilog;
using Serilog.Events;

namespace IRLIX.Logging.Configurators;

public sealed class LogEventLevelEnricher : ILoggerConfigurator
{
    public LoggerConfiguration Configure(LoggerConfiguration config)
        => config.MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Information);
}
