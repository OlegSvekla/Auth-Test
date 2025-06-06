using Serilog;

namespace IRLIX.Logging;

public interface ILoggerConfigurator
{
    LoggerConfiguration Configure(LoggerConfiguration config);
}
