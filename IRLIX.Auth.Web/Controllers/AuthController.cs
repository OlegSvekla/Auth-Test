using IRLIX.Contracts.Commands.SignIns;
using IRLIX.Core.Core.Interfaces.Mappers;
using IRLIX.Core.IRLIX.Web.Models.Rss.Errors;
using IRLIX.Core.L11n;
using IRLIX.Core.Mq.Buses;
using IRLIX.Web.Models.Rqs.SignIns;
using Microsoft.AspNetCore.Mvc;
using static IRLIX.Core.L11n.Consts;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.Web.Controllers;

[Route("api/v{version:apiVersion}/auth")]
public class AuthController(
    ICultureSetup cultureSetup,
    ILocalMessageBus localMessageBus,
    IMapper<SignMeInViaEmailBodyRq, SignMeInViaEmailCommand> signMeInViaEmailBodyRqToCommandMapper
    ) : WebApiController
{
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
}
