using Microsoft.AspNetCore.Http;

namespace IRLIX.Web.ExceptionHandling;

public class ExceptionHandlerMiddleware(
    IExceptionHandler exceptionHandler
    ) : IMiddleware
{
    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await exceptionHandler.HandleAsync(context, ex, CancellationToken.None);
        }
    }
}
