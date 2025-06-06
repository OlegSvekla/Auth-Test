using System.Globalization;
using Serilog;

namespace IRLIX.Logging.Configurators;

public sealed class ConsoleSinker : ILoggerConfigurator
{
    public LoggerConfiguration Configure(LoggerConfiguration config)
        => config.WriteTo.Console(
            formatProvider: CultureInfo.InvariantCulture);
}
