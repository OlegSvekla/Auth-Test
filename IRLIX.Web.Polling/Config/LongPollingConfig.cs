namespace IRLIX.Web.Polling.Config;

public class LongPollingConfig
{
    public int MaxHttpConnectionTimeSec { get; init; }

    public int DelayAfterExecutionMilliseconds { get; init; }
}
