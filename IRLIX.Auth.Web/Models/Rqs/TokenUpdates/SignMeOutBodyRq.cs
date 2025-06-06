namespace IRLIX.Auth.Web.Models.Rqs.TokenUpdates;

public sealed record SignMeOutBodyRq(
    string RefreshToken,
    string DeviceId,
    bool? AllOpenSessions
    );
