using IRLIX.Mq.Local.MediatR.Messages;

namespace IRLIX.Auth.Contracts.Queries.VerifyCodes;

public sealed record VerifyCodeByMeViaEmailQuery(
    Guid Id
    ) : IMediatrQuery<AuthTokensQueryRs>;
