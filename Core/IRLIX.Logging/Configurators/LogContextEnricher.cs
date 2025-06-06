using Serilog;

namespace IRLIX.Logging.Configurators;

public sealed class LogContextEnricher : ILoggerConfigurator
{
    public LoggerConfiguration Configure(LoggerConfiguration config)
        => config.Enrich.FromLogContext();
}
