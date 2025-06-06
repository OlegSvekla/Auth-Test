namespace IRLIX.Auth.Web.Models.Rss.Users;

public sealed record GetUsersRs(
    Guid Id,
    DateTimeOffset CreatedDate,
    Guid? CreatedByUserId,
    DateTimeOffset UpdatedDate,
    Guid? UpdatedByUserId,
    string? Phone,
    bool IsPhoneVerified,
    string? Email,
    bool IsEmailVerified,
    LockoutRs Lockout,
    IReadOnlyCollection<string> RoleNames
    );

public sealed record LockoutRs(
    DateTimeOffset? CreatedDate,
    Guid? CreatedByUserId,
    int? AttempsCount,
    DateTimeOffset? EndDate
    );
