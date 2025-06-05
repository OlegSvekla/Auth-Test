namespace IRLIX.Core.Email.Configs;

public sealed class GmailEmailConfig
{
    /// <summary>
    /// Email is email address from which all messages will be sent
    /// </summary>
    /// <remarks>
    /// Example: noreply@shuttlex.com
    /// </remarks>
    public string Email { get; init; } = default!;

    /// <summary>
    /// Password of <see cref="Email"/> account
    /// </summary>
    public string Password { get; init; } = default!;

    /// <summary>
    /// Host. Should be provided by mail box app
    /// </summary>
    public string Host { get; init; } = default!;

    /// <summary>
    /// Port. Should be provided by mail box app
    /// </summary>
    public int Port { get; init; }
}
