using IRLIX.Core.Email.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Core.Email.Providers;

public interface IGmailEmailConfigProvider
{
    GmailEmailConfig GetAuthConfig();
}

public sealed class GmailEmailConfigProvider(
    IOptions<GmailEmailConfig> options
    ) : IGmailEmailConfigProvider
{
    private readonly GmailEmailConfig config = options.Value;

    public GmailEmailConfig GetAuthConfig()
        => config;
}
