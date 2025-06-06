using IRLIX.Aggregator.Ef.Entities.Auth;
using IRLIX.Auth.Contracts.Queries;
using IRLIX.Auth.Contracts.Queries.VerifyCodes;
using IRLIX.Context;
using IRLIX.Core.General;
using IRLIX.Ef.Repositories;
using IRLIX.Mq.Local.MediatR.Handlers;
using IRLIX.Web.Identity.Tokens.Jwt;

namespace IRLIX.BL.Handlers.Commands;

internal class VerifyCodeByMeViaEmailQueryHandler(
    IRepository<SessionEntity> sessionRepository,
    IJwtTokenGenerator jwtTokenGenerator
    ) : MediatrQueryHandler<VerifyCodeByMeViaEmailQuery, AuthTokensQueryRs>
{
    public override async ValueTask<AuthTokensQueryRs> HandleAsync(
        VerifyCodeByMeViaEmailQuery query,
        CancellationToken ct)
    {
        var dto = await sessionRepository.GetByIdAsync(
            id: query.Id,
            selector: session => new
            {
                SessionId = session.Id,
                session.DeviceId,
                session.UserId,
                session.RefreshToken,
                session.User.UserName
            },
            ct: ct);

        var userClaims = new UserClaims(
            dto.UserId,
            dto.UserName.GetValue(),
            dto.SessionId,
            dto.DeviceId);
        var (accessToken, expiresAt) = await jwtTokenGenerator.GenerateAsync(userClaims, ct);

        var result = new AuthTokensQueryRs(
            AccessToken: accessToken,
            RefreshToken: dto.RefreshToken,
            ExpiresAt: expiresAt);
        return result;
    }
}
