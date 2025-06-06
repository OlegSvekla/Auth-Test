using IRLIX.Jobs.Hangfire;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Jobs;

/// <summary>
/// Hangfire jobs services.
/// 
/// Creates and manipulate background jobs.
/// See <see cref="https://github.com/HangfireIO/Hangfire"/>
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "Jobs": {
///         ...,
///         "Hangfire": {
///             "ConnectionString": "string",
///             "User": {
///                 "Username": "string",
///                 "Password": "string"
///             }
///         },
///         ...
///     },
///     ...
/// }
/// </summary>
public sealed class HangfireStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.PreEndpoint;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchJobsHangfire(builder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override async ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        await app.UseJobsHangfire();
        return app;
    }
}
