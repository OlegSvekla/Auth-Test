using IRLIX.Comm.Emails.MailKit.Gmail.Configs;
using Microsoft.Extensions.Options;

namespace IRLIX.Comm.Emails.MailKit.Gmail.Providers;

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
