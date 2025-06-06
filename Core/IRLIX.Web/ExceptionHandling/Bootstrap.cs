namespace ShuttleX.Web.ExceptionHandling;

public static class Bootstrap
{
    public static IServiceCollection AddBatchWebExceptionHandling(
        this IServiceCollection services)
    {
        services.AddScoped<IExceptionHandler, ExceptionHandler>();
        services.AddScoped<ExceptionHandlerMiddleware>();
        services.AddScoped<IExceptionResponseExtractor, ExceptionResponseExtractor>();
        services.AddScoped<IHttpResponseStatusCodeExtractor, HttpResponseStatusCodeExtractor>();
        return services;
    }
}
