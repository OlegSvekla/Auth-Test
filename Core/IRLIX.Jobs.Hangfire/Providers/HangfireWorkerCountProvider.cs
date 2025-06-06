using IRLIX.Jobs.Hangfire.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Jobs.Hangfire.Providers;

public interface IHangfireWorkerCountProvider
{
    int GetWorkerCount();
}

public sealed class HangfireWorkerCountProvider(
    IOptions<HangfireConfig> options) : IHangfireWorkerCountProvider
{
    private readonly HangfireConfig config = options.Value;

    public int GetWorkerCount()
        => config.WorkerCount;
}
