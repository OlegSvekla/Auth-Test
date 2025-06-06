using Serilog;

namespace IRLIX.Logging.Configurators;

public sealed class MachineNameEnricher : ILoggerConfigurator
{
    public LoggerConfiguration Configure(LoggerConfiguration config)
        => config.Enrich.WithMachineName();
}
