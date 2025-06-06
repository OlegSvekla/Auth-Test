namespace IRLIX.Auth.Web.Models.Rqs.TokenUpdates;

public sealed record UpdateMyAccessTokenByRefreshTokenBodyRq(
    string RefreshToken,
    string DeviceId
    );
