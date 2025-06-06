using IRLIX.Core.Time;
using IRLIX.Web.Identity.Tokens.Jwt.Providers;
using System.Security.Cryptography;

namespace IRLIX.Web.Identity.Tokens;

public interface IRefreshTokenGenerator
{
    (string RefreshToken, DateTimeOffset ExpiresAt) Generate();
}

internal class RefreshTokenGenerator(
    IJwtConfigProvider configProvider,
    IDateTimeProvider dateTimeProvider
    ) : IRefreshTokenGenerator
{
    public (string RefreshToken, DateTimeOffset ExpiresAt) Generate()
    {
        using var rng = RandomNumberGenerator.Create();

        var randomNumber = new byte[32];
        rng.GetBytes(randomNumber);

        var refreshToken = Convert.ToBase64String(randomNumber);

        var config = configProvider.GetJwtConfig();

        var lifeTimeMin = config.AccessTokenLifeTimeMin;
        var currentDateTime = dateTimeProvider.UtcNow();
        var expiresAt = currentDateTime + TimeSpan.FromMinutes(lifeTimeMin);

        return (refreshToken, expiresAt);
    }
}
