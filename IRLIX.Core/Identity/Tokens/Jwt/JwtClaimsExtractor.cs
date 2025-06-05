using IRLIX.Core.Core.General;
using IRLIX.Core.Http.In;
using IRLIX.Core.Identity.Models;
using System.Globalization;
using System.Security.Claims;

namespace IRLIX.Core.Identity.Tokens.Jwt;

internal class JwtClaimsExtractor(
    IHttpContextDataSearcher httpContextDataSearcher
    ) : IHttpClaimsExtractor
{
    public Guid ExtractUserId()
    {
        var claims = httpContextDataSearcher.FindClaims().GetValue();
        var foundClaimValue = claims
            .First(x => string.Equals(
                x.Type,
                ClaimTypes.NameIdentifier,
                StringComparison.OrdinalIgnoreCase))
            .Value;
        var userId = Guid.Parse(foundClaimValue, CultureInfo.InvariantCulture);
        return userId;
    }

    public string ExtractUserName()
    {
        var claims = httpContextDataSearcher.FindClaims().GetValue();
        var userName = claims
            .First(x => string.Equals(
                x.Type,
                ClaimTypes.Name,
                StringComparison.OrdinalIgnoreCase))
            .Value;
        return userName;
    }

    public Guid ExtractSessionId()
    {
        var claims = httpContextDataSearcher.FindClaims().GetValue();
        var foundClaimValue = claims
            .First(x => string.Equals(
                x.Type,
                nameof(UserClaims.SessionId),
                StringComparison.OrdinalIgnoreCase))
            .Value;
        var sessionId = Guid.Parse(foundClaimValue, CultureInfo.InvariantCulture);
        return sessionId;
    }

    public string ExtractDeviceId()
    {
        var claims = httpContextDataSearcher.FindClaims().GetValue();
        var deviceId = claims
            .First(x => string.Equals(
                x.Type,
                nameof(UserClaims.DeviceId),
                StringComparison.OrdinalIgnoreCase))
            .Value;
        return deviceId;
    }
}
