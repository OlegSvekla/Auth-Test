using IRLIX.Context;

namespace IRLIX.Web.Identity.Tokens;

public interface IAccessTokenGenerator
{
    ValueTask<(string AccessToken, DateTimeOffset ExpiresAt)> GenerateAsync(
        UserClaims claims,
        CancellationToken ct);
}
