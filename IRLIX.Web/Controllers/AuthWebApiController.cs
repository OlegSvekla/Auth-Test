using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShuttleX.Web.Models.Rss.Errors;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ShuttleX.Web.Controllers;

[Authorize]
[ProducesResponseType(Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(Status423Locked, Type = typeof(UserLockedOutErrorRs))]
public abstract class AuthWebApiController : WebApiController
{
}
