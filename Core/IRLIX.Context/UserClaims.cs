namespace IRLIX.Context;

public record UserClaims(
    Guid UserId,
    string UserName,
    Guid SessionId,
    string DeviceId
    );
