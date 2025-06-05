namespace IRLIX.Core.Identity.Models;

public record UserClaims(
    Guid UserId,
    string UserName,
    Guid SessionId,
    string DeviceId
    );
