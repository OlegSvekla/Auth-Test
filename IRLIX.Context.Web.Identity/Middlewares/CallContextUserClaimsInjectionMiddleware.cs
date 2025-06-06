using IRLIX.Http.In;
using IRLIX.Web.Identity.Tokens;
using Microsoft.AspNetCore.Http;
using ShuttleX.Context;

namespace IRLIX.Context.Web.Identity.Middlewares;

public class CallContextUserClaimsInjectionMiddleware(
    IHttpContextDataSearcher httpContextDataSearcher,
    IHttpClaimsExtractor httpClaimsExtractor,
    ICallContextInitializer callContextInitializer
    ) : IMiddleware
{
    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        if (httpContextDataSearcher.IsUserAuthorized())
        {
            var userId = httpClaimsExtractor.ExtractUserId();
            var userName = httpClaimsExtractor.ExtractUserName();
            var sessionId = httpClaimsExtractor.ExtractSessionId();
            var deviceId = httpClaimsExtractor.ExtractDeviceId();

            var claims = new UserClaims(userId, userName, sessionId, deviceId);

            var callContext = callContextInitializer.InitClaims(claims);
            context.Items.Add(nameof(CallContext), callContext);
        }

        await next(context);
    }
}
