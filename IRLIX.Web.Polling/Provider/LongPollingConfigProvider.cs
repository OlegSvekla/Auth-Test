using IRLIX.Web.Polling.Config;
using Microsoft.Extensions.Options;

namespace IRLIX.Web.Polling.Provider;

public interface ILongPollingConfigProvider
{
    public int GetMaxHttpConnectionTimeSec();

    public int GetDelayAfterExecutionMilliseconds();
}

public class LongPollingConfigProvider(
    IOptions<LongPollingConfig> options
) : ILongPollingConfigProvider
{
    private readonly LongPollingConfig config = options.Value;

    public int GetMaxHttpConnectionTimeSec()
        => config.MaxHttpConnectionTimeSec;

    public int GetDelayAfterExecutionMilliseconds()
        => config.DelayAfterExecutionMilliseconds;
}
