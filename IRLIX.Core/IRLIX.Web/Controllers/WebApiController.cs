using IRLIX.Core.IRLIX.Web.Controllers.Dtos;
using IRLIX.Core.IRLIX.Web.General;
using IRLIX.Core.IRLIX.Web.Models.Rss;
using IRLIX.Core.IRLIX.Web.Models.Rss.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IRLIX.Web.Controllers;

[ApiController]
//[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(Status400BadRequest, Type = typeof(FieldErrorRs[]))]
[ProducesResponseType(Status500InternalServerError, Type = typeof(MessageErrorRs))]
[ProducesResponseType(Status429TooManyRequests, Type = typeof(void))]
public abstract class WebApiController : ControllerBase
{
    [NonAction]
    public CreatedAtActionResult Created(
        CreatedResourceRs rs,
        CreatedResourceConfig config)
        => string.IsNullOrWhiteSpace(config.NameOfController)
            ? CreatedAtAction(
                actionName: config.NameOfAction.RemoveSuffixWhenFound(Consts.AsyncSuffix),
                routeValues: config.TargetEndpointRouteValue ?? rs,
                value: rs)
            : CreatedAtAction(
                actionName: config.NameOfAction.RemoveSuffixWhenFound(Consts.AsyncSuffix),
                controllerName: config.NameOfController.RemoveSuffixWhenFound(Consts.ControllerSuffix),
                routeValues: config.TargetEndpointRouteValue ?? rs,
                value: rs);
}
