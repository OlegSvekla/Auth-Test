namespace IRLIX.Auth.Contracts.Queries.Users;

public sealed record GetUsersQuery(
    int? Amount,
    int? Offset
    ) : IMediatrQuery<IReadOnlyCollection<GetUsersQueryRs>>;

public sealed record GetUsersQueryRs(
    Guid Id,
    DateTimeOffset CreatedDate,
    Guid? CreatedByUserId,
    DateTimeOffset UpdatedDate,
    Guid? UpdatedByUserId,
    string? Phone,
    bool IsPhoneVerified,
    string? Email,
    bool IsEmailVerified,
    LockoutQueryRs Lockout,
    IReadOnlyCollection<string> RoleNames
    );

public sealed record LockoutQueryRs(
    DateTimeOffset? CreatedDate,
    Guid? CreatedByUserId,
    int? AttempsCount,
    DateTimeOffset? EndDate
    );
