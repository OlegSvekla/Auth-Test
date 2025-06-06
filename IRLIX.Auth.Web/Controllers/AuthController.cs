using IRLIX.Auth.Contracts.Commands.SignIns;
using IRLIX.Auth.Contracts.Commands.SignUps;
using IRLIX.Auth.Contracts.Commands.TokenUpdates;
using IRLIX.Auth.Contracts.Commands.VerifyCodes;
using IRLIX.Auth.Contracts.Queries;
using IRLIX.Auth.Contracts.Queries.Users;
using IRLIX.Auth.Contracts.Queries.VerifyCodes;
using IRLIX.Auth.Web.Models.Rqs.SignIns;
using IRLIX.Auth.Web.Models.Rqs.SignUps;
using IRLIX.Auth.Web.Models.Rqs.TokenUpdates;
using IRLIX.Auth.Web.Models.Rqs.VerifyCodes;
using IRLIX.Auth.Web.Models.Rss;
using IRLIX.Auth.Web.Models.Rss.Users;
using IRLIX.Core.Interfaces.Mappers;
using IRLIX.L11n;
using IRLIX.Mq.Buses;
using IRLIX.Web.Models.Rss.Errors;
using Microsoft.AspNetCore.Mvc;
using static IRLIX.L11n.Consts;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.Web.Controllers;

[Route("api/v{version:apiVersion}/auth")]
public class AuthController(
    ICultureSetup cultureSetup,
    ILocalMessageBus localMessageBus,
    IMapper<SignMeInViaEmailBodyRq, SignMeInViaEmailCommand> signMeInViaEmailBodyRqToCommandMapper,
    IMapper<SignMeUpBodyRq, SignMeUpCommand> signMeUpBodyRqToCommandMapper,
    IMapper<VerifyCodeByMeViaEmailBodyRq, VerifyCodeByMeViaEmailCommand> verifyCodeByMeViaEmailBodyRqToCommandMapper,
    IMapper<Guid, VerifyCodeByMeViaEmailQuery> verifyCodeByMeViaEmailCommandIdToQueryMapper,
    IMapper<SignMeOutBodyRq, SignMeOutCommand> signMeOutBodyRqToCommandMapper,
    IMapper<AuthTokensQueryRs, AuthTokensRs> authTokensQueryRsToRsMapper,
    IMapper<IReadOnlyCollection<GetUsersQueryRs>, IReadOnlyCollection<GetUsersRs>> getUsersQueryRssToRssMapper
    ) : AuthWebApiController
{
    [HttpPost("sign-up")]
    [ProducesResponseType(Status204NoContent)]
    public async Task<IActionResult> SignMeUpAsync(
    [FromBody] SignMeUpBodyRq bodyRq,
    CancellationToken ct)
    {
        var command = signMeUpBodyRqToCommandMapper.Map(bodyRq);
        await localMessageBus.DispatchAsync(command, ct);

        return NoContent();
    }

    [HttpPost("sign-in/email")]
    [ProducesResponseType(Status423Locked, Type = typeof(UserLockedOutErrorRs))]
    [ProducesResponseType(Status204NoContent)]
    public async Task<IActionResult> SignMeInViaEmailAsync(
        [FromHeader(Name = CultureInfoKeyHttpHeader)] string? language,
        [FromBody] SignMeInViaEmailBodyRq bodyRq,
        CancellationToken ct)
    {
        cultureSetup.Set(language);

        var command = signMeInViaEmailBodyRqToCommandMapper.Map(bodyRq);
        await localMessageBus.DispatchAsync(command, ct);

        return NoContent();
    }

    [HttpPost("verify-code/email")]
    [ProducesResponseType(Status423Locked, Type = typeof(UserLockedOutErrorRs))]
    [ProducesResponseType(Status200OK, Type = typeof(AuthTokensQueryRs))]
    public async Task<IActionResult> VerifyCodeByMeViaEmailAsync(
    [FromBody] VerifyCodeByMeViaEmailBodyRq rq,
    CancellationToken ct)
    {
        var command = verifyCodeByMeViaEmailBodyRqToCommandMapper.Map(rq);
        await localMessageBus.DispatchAsync(command, ct);

        var query = verifyCodeByMeViaEmailCommandIdToQueryMapper.Map(command.Id);
        var queryRs = await localMessageBus.DispatchAsync(query, ct);

        var result = authTokensQueryRsToRsMapper.Map(queryRs);
        return Ok(result);
    }

    [HttpGet("users")]
    [ProducesResponseType(Status200OK, Type = typeof(IReadOnlyCollection<GetUsersQueryRs>))]
    public async Task<IActionResult> GetUsersAsync(
        [FromQuery] GetUsersQuery query,
        CancellationToken ct)
    {
        var queryRs = await localMessageBus.DispatchAsync(query, ct);

        var result = getUsersQueryRssToRssMapper.Map(queryRs);
        return Ok(result);
    }

    [HttpPost("sign-out")]
    [ProducesResponseType(Status204NoContent)]
    public async Task<IActionResult> SignMeOutAsync(
        [FromBody] SignMeOutBodyRq bodyRq,
        CancellationToken ct)
    {
        var command = signMeOutBodyRqToCommandMapper.Map(bodyRq);
        await localMessageBus.DispatchAsync(command, ct);

        return NoContent();
    }
}
