using IRLIX.Core.IRLIX.Web.Models.Rss.Errors;
using IRLIX.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.Core.IRLIX.Web.Controllers;

[Authorize]
[ProducesResponseType(Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(Status423Locked, Type = typeof(UserLockedOutErrorRs))]
public abstract class AuthWebApiController : WebApiController
{
}
