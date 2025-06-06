namespace IRLIX.Auth.Contracts.Queries;

public sealed record AuthTokensQueryRs(
    string AccessToken,
    string RefreshToken,
    DateTimeOffset ExpiresAt
    );
