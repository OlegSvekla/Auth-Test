using Serilog.Core;
using Serilog.Events;

namespace IRLIX.Logging.Extensions;

//TODO try to do with global logger

public class GlobalLoggerEnricher() : ILogEventEnricher
{
    public void Enrich(
        LogEvent logEvent,
        ILogEventPropertyFactory propertyFactory)
    {
        // var httpContext = httpContextAccessor.HttpContext;
        // if (httpContext != null)
        // {
            // if (httpContextDataSearcher.IsUserAuthorized())
            // {
            //     var contextProvider = callContextProvider.Get();
            //
            //     AddPropertyToLog(
            //         propertyFactory,
            //         logEvent,
            //         LoggerDictionaryDataEnricher.LoggerCleimsEnrich(contextProvider));
            // }
            
        //     AddPropertyToLog(
        //         propertyFactory,
        //         logEvent,
        //         LoggerDictionaryDataEnricher.LoggerHttpEnrich(httpContext));
        // }
    }

    // private void AddPropertyToLog(
    //     ILogEventPropertyFactory propertyFactory,
    //     LogEvent logEvent,
    //     Dictionary<string, object> logProperties)
    // {
    //     foreach (var property in logProperties)
    //     {
    //         var logEventProperty = propertyFactory.CreateProperty(property.Key, property.Value);
    //         logEvent.AddPropertyIfAbsent(logEventProperty);
    //     }
    // }
}

