using IRLIX.Logging.Constants;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace IRLIX.Logging.Extensions;

public static class LocalLoggerEnricher
{
    public static void LogInformation(
        this ILogger logger,
        string fieldName,
        string fieldValue,
        Action<ILogger, object> methodEnrichment,
        object additionalData)
    {
        using (LogContext.PushProperty(fieldName, fieldValue))
        {
            methodEnrichment(logger, additionalData);
        }
    }
    
    public static void LogInformation(
        this ILogger logger,
        Dictionary<string, string?> fields,
        string message = LoggerConstants.MessageWithTrackedData)
    {
        if (fields.Count == 0)
        {
            logger.LogInformation("Info: {message}", message);
            return;
        }

        var disposables = new Stack<IDisposable>();

        try
        {
            foreach (var field in fields)
            {
                disposables.Push(LogContext.PushProperty(field.Key, field.Value));
            }

            logger.LogInformation("Info: {message}", message);
        }
        finally
        {
            while (disposables.Any())
            {
                disposables.Pop().Dispose();
            }
        }
    }
    
    public static void LogError(
        this ILogger logger,
        Exception ex,
        Dictionary<string, string> fields)
    {
        if (fields.Count == 0)
        {
            logger.LogError(ex, "Error: {message}", ex.Message);
            return;
        }

        var disposables = new Stack<IDisposable>();

        try
        {
            foreach (var field in fields)
            {
                disposables.Push(LogContext.PushProperty(field.Key, field.Value));
            }

            logger.LogError(ex, "Error: {message}", ex.Message);
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
