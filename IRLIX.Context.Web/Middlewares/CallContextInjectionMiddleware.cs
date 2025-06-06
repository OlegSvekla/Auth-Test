using Microsoft.AspNetCore.Http;

namespace IRLIX.Context.Web.Middlewares;

public class CallContextInjectionMiddleware(
    ICallContextInitializer callContextInitializer
    ) : IMiddleware
{
    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        callContextInitializer.Init();
        await next(context);
    }
}
