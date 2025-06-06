using IRLIX.Context;
using IRLIX.Logging.Helpers;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace IRLIX.Logging.Middlewares;

public class GlobalLoggerEnricherMiddleware(
    ICallContextProvider callContextProvider
    ) : IMiddleware
{
    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        var disposables = new Stack<IDisposable>();

        try
        {
            var contextProvider = callContextProvider.Get();
            foreach (var field in LoggerHelpers.GetAuthDictionaryLogEnricher(contextProvider))
            {
                disposables.Push(LogContext.PushProperty(field.Key, field.Value));
            }

            await next(context);
        }
        finally
        {
            while (disposables.Any())
            {
                disposables.Pop().Dispose();
            }
        }
    }
}
