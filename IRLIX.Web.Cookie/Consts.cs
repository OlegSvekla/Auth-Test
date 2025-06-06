using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;

namespace IRLIX.Web.Cookie;

public static class Consts
{
    public const string WebCookieConfigSectionKey = "Web:Cookie";

    public const SameSiteMode DefaultMinimumSameSitePolicy = SameSiteMode.Lax;
    public const HttpOnlyPolicy DefaultHttpOnly = HttpOnlyPolicy.Always;
    public const CookieSecurePolicy DefaultSecure = CookieSecurePolicy.Always;
    public const bool DefaultIsEssential = true;
    public const int DefaultExpirationDay = 10080;
}
