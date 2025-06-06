namespace IRLIX.Auth.Web.Models.Rqs.Users;

public sealed record SetUserLockoutRq(
    Guid UserId,
    SetUserLockoutBodyRq BodyRq
    );

public sealed record SetUserLockoutBodyRq(
    DateTime LockoutEndDate,
    string? LockoutReason
    );
