using IRLIX.Context;
using IRLIX.Core.Interfaces.Jobs;
using IRLIX.Logging.Constants;
using IRLIX.Logging.Extensions;
using IRLIX.Logging.Helpers;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace IRLIX.Jobs.Hangfire.Execution;

public abstract class BaseJobWrapper(
    ILogger<BaseJobWrapper> logger,
    ICallContextInitializer callContextInitializer,
    ICallContextProvider callContextProvider
    ) : IJobWrapper
{
    public async Task RunInsideJobAsync(
        object? payload,
        CancellationToken ct)
    {
        callContextInitializer.Init();
        var contextProvider = callContextProvider.Get();

        try
        {
            logger.LogInformation(
                fieldName: LoggerConstants.LocalField,
                fieldValue: LoggerConstants.HangfireStartJob,
                methodEnrichment: LoggerHelpers.AddDataToLogger,
                additionalData: callContextProvider);

            await InnerRunAsync(payload, ct);

            logger.LogInformation(
                fieldName: LoggerConstants.LocalField,
                fieldValue: LoggerConstants.HangfireFinishJob,
                methodEnrichment: LoggerHelpers.AddDataToLogger,
                additionalData: callContextProvider);
        }
        catch (Exception ex)
        {
            using (LogContext.PushProperty(nameof(contextProvider.CorrelationId), contextProvider.CorrelationId.ToString()))
            {
                logger.LogError(ex, "Job error: {message} {stackTrace}", ex.Message, ex.StackTrace);
            }

            throw;
        }
    }

    protected abstract Task InnerRunAsync(
        object? payload,
        CancellationToken ct);
}
