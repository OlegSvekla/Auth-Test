using IRLIX.Core.L11n.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Core.L11n;

public interface IL11nConfigProvider
{
    string GetDefaultCulture();
}

public sealed class L11nConfigProvider(
    IOptions<L11nConfig> options
    ) : IL11nConfigProvider
{
    private readonly L11nConfig config = options.Value;

    public string GetDefaultCulture()
        => config.DefaultCulture;
}
