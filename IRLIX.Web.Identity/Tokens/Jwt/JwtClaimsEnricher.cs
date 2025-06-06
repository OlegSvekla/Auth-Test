using IRLIX.Context;
using System.Security.Claims;

namespace IRLIX.Web.Identity.Tokens.Jwt;

public interface IJwtClaimsEnricher
{
    ValueTask<Claim[]> EncrichAsync(
        Claim[] tokenClaims,
        UserClaims claims,
        CancellationToken ct);
}

public class DefaultJwtClaimsEnricher
    : IJwtClaimsEnricher
{
    public ValueTask<Claim[]> EncrichAsync(
        Claim[] tokenClaims,
        UserClaims claims,
        CancellationToken ct)
        => ValueTask.FromResult(tokenClaims);
}
