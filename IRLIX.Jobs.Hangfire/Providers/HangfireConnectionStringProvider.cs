using IRLIX.Jobs.Hangfire.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Jobs.Hangfire.Providers;

public interface IHangfireConnectionStringProvider
{
    string GetConnectionString();
}

public sealed class HangfireConnectionStringProvider(
    IOptions<HangfireConfig> options) : IHangfireConnectionStringProvider
{
    private readonly HangfireConfig config = options.Value;

    public string GetConnectionString()
        => config.ConnectionString;
}
