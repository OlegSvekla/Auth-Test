using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Queries.Sessions;

public sealed record GetMySessionsQuery
    : IMediatrQuery<IReadOnlyCollection<SessionQueryRs>>;
