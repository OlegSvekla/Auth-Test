using IRLIX.Core.Identity.Models;
using IRLIX.Core.Identity.Tokens.Jwt.Providers;
using IRLIX.Core.Time;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IRLIX.Core.Identity.Tokens.Jwt;

public interface IJwtTokenGenerator : IAccessTokenGenerator;

internal class JwtTokenGenerator(
    IJwtConfigProvider configProvider,
    IDateTimeProvider dateTimeProvider,
    IJwtClaimsEnricher jwtClaimsEnricher
    ) : IJwtTokenGenerator
{
    public async ValueTask<(string AccessToken, DateTimeOffset ExpiresAt)> GenerateAsync(
        UserClaims claims,
        CancellationToken ct)
    {
        var config = configProvider.GetJwtConfig();

        var symmetricSecurityKeyBytes = Encoding.UTF8.GetBytes(config.SigningSecretKey);
        var signingKey = new SymmetricSecurityKey(symmetricSecurityKeyBytes);
        var signingCred = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var lifeTimeMin = config.AccessTokenLifeTimeMin;
        var currentDateTime = dateTimeProvider.UtcNow();
        var expiresAt = currentDateTime + TimeSpan.FromMinutes(lifeTimeMin);

        var tokenClaims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Iss, config.IssuerAuthHost),
            new Claim(JwtRegisteredClaimNames.Aud, config.AudienceAuthHost),
            new Claim(JwtRegisteredClaimNames.Exp, expiresAt.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture)),
            new Claim(JwtRegisteredClaimNames.Iat, currentDateTime.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture)),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, claims.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, claims.UserName)
        };
        tokenClaims = await jwtClaimsEnricher.EncrichAsync(tokenClaims, claims, ct);

        var tokenDescriptor = new JwtSecurityToken(
            signingCredentials: signingCred,
            issuer: config.IssuerAuthHost,
            audience: config.AudienceAuthHost,
            expires: expiresAt.DateTime,
            claims: tokenClaims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var accessToken = tokenHandler.WriteToken(tokenDescriptor);

        return (accessToken, expiresAt);
    }
}
