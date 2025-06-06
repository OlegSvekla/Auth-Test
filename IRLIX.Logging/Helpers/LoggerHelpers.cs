using IRLIX.Context;
using IRLIX.Logging.Constants;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace IRLIX.Logging.Helpers;

public static class LoggerHelpers
{ 
    public static void AddDataToLogger(
        ILogger logger,
        object additionalData)
    {
        var dispatcher = new Dictionary<Type, Action<ILogger, object>>
        {
            { typeof(CallContextStorage), AddCallContextData },
        };

        dispatcher[additionalData.GetType()](logger, additionalData);
    }

    private static void AddCallContextData(
        ILogger logger,
        object additionalData)
    {
        var callContextProvider = (ICallContextProvider)additionalData;
        var contextProvider = callContextProvider.Get();

        using (LogContext.PushProperty($"{nameof(contextProvider.UserClaims.UserId)}", contextProvider.UserClaims?.UserId))
        using (LogContext.PushProperty($"{nameof(contextProvider.UserClaims.UserName)}", contextProvider.UserClaims?.UserName))
        using (LogContext.PushProperty($"{nameof(contextProvider.UserClaims.DeviceId)}", contextProvider.UserClaims?.DeviceId))
        using (LogContext.PushProperty($"{nameof(contextProvider.UserClaims.SessionId)}", contextProvider.UserClaims?.SessionId))
        using (LogContext.PushProperty($"{nameof(contextProvider.CorrelationId)}", contextProvider.CorrelationId))
        {
            logger.LogInformation(LoggerConstants.MessageWithTrackedData);
        }
    }
    
    public static Dictionary<string, string?> GetAuthDictionaryLogEnricher(
        ICallContext contextProvider)
        => new Dictionary<string, string?>
        {   
            { LoggerConstants.LocalField, LoggerConstants.Request },
            { nameof(contextProvider.UserClaims.UserId), contextProvider.UserClaims?.UserId.ToString() },
            { nameof(contextProvider.UserClaims.UserName), contextProvider.UserClaims?.UserName },
            { nameof(contextProvider.UserClaims.DeviceId), contextProvider.UserClaims?.DeviceId },
            { nameof(contextProvider.UserClaims.SessionId), contextProvider.UserClaims?.SessionId.ToString() },
            { nameof(contextProvider.CorrelationId), contextProvider.CorrelationId.ToString() },
        };
}
