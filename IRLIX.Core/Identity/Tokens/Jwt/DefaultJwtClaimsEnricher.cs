using IRLIX.Core.Identity.Models;
using System.Security.Claims;

namespace IRLIX.Core.Identity.Tokens.Jwt;

//public interface IJwtClaimsEnricher
//{
//    ValueTask<Claim[]> EncrichAsync(
//        Claim[] tokenClaims,
//        UserClaims claims,
//        CancellationToken ct);
//}

//public class DefaultJwtClaimsEnricher
//    : IJwtClaimsEnricher
//{
//    public ValueTask<Claim[]> EncrichAsync(
//        Claim[] tokenClaims,
//        UserClaims claims,
//        CancellationToken ct)
//        => ValueTask.FromResult(tokenClaims);
//}
