using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;

namespace IRLIX.Web.Cookie.Configs;

public class CookieConfig
{
    /// <summary>
    /// Minimum SameSite policy for the cookie.
    /// </summary>
    public SameSiteMode MinimumSameSitePolicy { get; init; } = Consts.DefaultMinimumSameSitePolicy;

    /// <summary>
    /// Specifies that the cookie is only accessible through HTTP.
    /// </summary>
    public HttpOnlyPolicy HttpOnly { get; init; } = Consts.DefaultHttpOnly;

    /// <summary>
    /// Specifies that the cookie will only be sent over secure connections.
    /// </summary>
    public CookieSecurePolicy Secure { get; init; } = Consts.DefaultSecure;

    /// <summary>
    /// Indicates if the cookie is essential (used for necessary functions like authentication).
    /// </summary>
    public bool IsEssential { get; init; } = Consts.DefaultIsEssential;

    /// <summary>
    /// Expiration time in days for the cookie.
    /// </summary>
    public int ExpirationDay { get; init; } = Consts.DefaultExpirationDay;
}
