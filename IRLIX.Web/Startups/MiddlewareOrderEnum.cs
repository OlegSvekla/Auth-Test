namespace IRLIX.Web.Startups;

/// <summary>
/// Order middleware in right direction.
/// See <see cref="https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware"/>
/// </summary>
public enum MiddlewareOrderEnum
{
    Asap = 1,
    Logger,
    ExceptionHandler,
    Hsts,
    StaticFiles,
    CookiePolicy,
    Routing,
    RateLimit,
    L11n,
    Cors,
    Auth,
    Session,
    ResponseHandler,
    Validation,
    PreEndpoint,
    Jobs,
    Endpoint,
    Vault,
    Final = 1000
}
