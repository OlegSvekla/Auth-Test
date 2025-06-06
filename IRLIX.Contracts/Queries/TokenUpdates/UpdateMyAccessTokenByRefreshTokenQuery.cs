using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Queries.TokenUpdates;

public sealed record UpdateMyAccessTokenByRefreshTokenQuery(
    Guid Id
    ) : IMediatrQuery<AuthTokensQueryRs>;
