using IRLIX.Web.Controllers;
using IRLIX.Web.Models.Rss.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.Web.Controllers;

[Authorize]
[ProducesResponseType(Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(Status423Locked, Type = typeof(UserLockedOutErrorRs))]
public abstract class AuthWebApiController : WebApiController
{
}
