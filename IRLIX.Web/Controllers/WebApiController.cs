using System.Net.Mime;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ShuttleX.Core.General;
using ShuttleX.Web.Controllers.Dtos;
using ShuttleX.Web.Models.Rss;
using ShuttleX.Web.Models.Rss.Errors;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace ShuttleX.Web.Controllers;

[ApiController]
[ApiVersion(1)]
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
