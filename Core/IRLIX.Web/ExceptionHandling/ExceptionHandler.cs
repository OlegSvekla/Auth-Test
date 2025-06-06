using IRLIX.Core.Exceptions;
using IRLIX.Core.Serializers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Mime;

namespace IRLIX.Web.ExceptionHandling;

public interface IExceptionHandler
{
    Task<HttpContext> HandleAsync(HttpContext context, Exception ex, CancellationToken ct);
}

public class ExceptionHandler(
    ILogger<ExceptionHandlerMiddleware> logger,
    ISerializer<string> serializer,
    IExceptionResponseExtractor responseExtractor,
    IHttpResponseStatusCodeExtractor statusCodeExtractor
    ) : IExceptionHandler
{
    public async Task<HttpContext> HandleAsync(HttpContext context, Exception ex, CancellationToken ct)
    {
        LogEx(ex);

        var rs = responseExtractor.Extract(ex);
        var rsString = serializer.Serialize(rs);
        var statusCode = statusCodeExtractor.Extract(ex);

        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsync(rsString, ct);

        return context;
    }

    private void LogEx(Exception ex)
    {
        if (ex is not DomainException)
        {
            logger.LogCritical(ex, ex.Message);
        }
        else
        {
            logger.LogError(ex, ex.Message);
        }
    }
}
