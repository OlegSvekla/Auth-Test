using IRLIX.Comm.Emails.MailKit.Gmail;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Comms;

/// <summary>
/// Email communication services.
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "Comm": {
///         ...,
///         "Email": {
///             ...,
///             "Gmail": {
///                 "Email": "string",
///                 "Password": "string",
///                 "Host": "string",
///                 "Port": int
///             },
///             ...
///         },
///         ...
///     },
///     ...
/// }
/// </summary>
public sealed class CommEmailGmailStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchCommEmailGmail(builder.Configuration);

        return ValueTask.FromResult(services);
    }
}
