namespace IRLIX.Auth.Web.Models.Rss;

public sealed record AuthTokensRs(
    string AccessToken,
    string RefreshToken,
    DateTimeOffset ExpiresAt
    );
