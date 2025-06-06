using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Queries.Sessions;

public sealed record GetUserSessionsQuery(
    Guid UserId,
    int? Amount,
    int? Offset,
    string? SortBy,
    string? FilterBy,
    bool? IncludeDeleted
    ) : IMediatrQuery<IReadOnlyCollection<SessionQueryRs>>;
