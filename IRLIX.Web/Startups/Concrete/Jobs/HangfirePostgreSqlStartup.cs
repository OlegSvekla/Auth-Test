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
///             "ConnectionString": "string"
///         },
///         ...
///     },
///     ...
/// }
/// </summary>
public sealed class HangfirePostgreSqlStartup : ServiceStartup
{
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Lower;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchJobsHangfirePostgreSql();

        return ValueTask.FromResult(services);
    }
}
