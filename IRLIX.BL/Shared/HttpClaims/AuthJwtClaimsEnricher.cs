using IRLIX.Core.Entities;
using IRLIX.Core.Identity;
using IRLIX.Core.Identity.Models;
using IRLIX.Core.Identity.Tokens.Jwt;
using System.Security.Claims;

namespace IRLIX.BL.Shared.HttpClaims;

public class AuthJwtClaimsEnricher(
    IAuthUserManager<UserEntity> userManager
    ) : IJwtClaimsEnricher
{
    public async ValueTask<Claim[]> EncrichAsync(
        Claim[] tokenClaims,
        UserClaims claims,
        CancellationToken ct)
    {
        var callContextUserClaims = new[]
        {
            new Claim(nameof(UserClaims.SessionId), claims.SessionId.ToString()),
            new Claim(nameof(UserClaims.DeviceId), claims.DeviceId),
        };
        var userClaims = await userManager.GetClaimsAsync(claims.UserName, ct);
        var roles = await userManager.GetRolesAsync(claims.UserName, ct);
        var roleClaims = roles
            .Select(role => new Claim(ClaimTypes.Role, role))
            .ToArray();

        var result = tokenClaims
            .Union(callContextUserClaims)
            .Union(userClaims)
            .Union(roleClaims)
            .ToArray();
        return result;
    }
}
