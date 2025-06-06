using IRLIX.Core.General;
using IRLIX.Ef.Identity.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IRLIX.Web.Identity.Lockouts.Middlewares;

public class LockoutMiddleware<TUser>(
    ILockoutClient lockoutClient
    ) : IMiddleware
    where TUser : EfIdentityUserEntity
{
    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        await ValidateAsync(context, context.RequestAborted);
        await next(context);
    }

    private async Task ValidateAsync(
        HttpContext context,
        CancellationToken ct)
    {
        var identity = context.User.Identity;
        if (identity == null || !identity.IsAuthenticated)
        {
            return;
        }

        var userIdStr = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = Guid.Parse(userIdStr.GetValue());

        await lockoutClient.ValidateOrResetAsync(userId, ct);
    }
}
