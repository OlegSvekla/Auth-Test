using IRLIX.Core.Identity.Models;

namespace IRLIX.Core.Identity.Tokens;

public interface IAccessTokenGenerator
{
    ValueTask<(string AccessToken, DateTimeOffset ExpiresAt)> GenerateAsync(
        UserClaims claims,
        CancellationToken ct);
}
