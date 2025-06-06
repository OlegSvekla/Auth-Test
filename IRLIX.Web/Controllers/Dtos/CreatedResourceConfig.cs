namespace ShuttleX.Web.Controllers.Dtos;

public sealed record CreatedResourceConfig(
    string NameOfAction,
    string? NameOfController = null,
    object? TargetEndpointRouteValue = null
    );
