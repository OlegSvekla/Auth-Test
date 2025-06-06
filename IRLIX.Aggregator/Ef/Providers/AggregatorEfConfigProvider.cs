using IRLIX.Aggregator.Ef.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Aggregator.Ef.Providers;

public interface IAggregatorEfConfigProvider
{
    string? FindDefaultAdminEmail();

    string? FindDefaultAdminHardcodedCode();
}

public sealed class AggregatorEfConfigProvider(
    IOptions<AggregatorEfConfig> options
    ) : IAggregatorEfConfigProvider
{
    private readonly AggregatorEfConfig config = options.Value;

    public string? FindDefaultAdminEmail()
        => config.DefaultAdminEmail;

    public string? FindDefaultAdminHardcodedCode()
        => config.DefaultAdminHardcodedCode;
}
