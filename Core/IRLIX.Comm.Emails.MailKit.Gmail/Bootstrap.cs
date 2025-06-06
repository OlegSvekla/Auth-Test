using IRLIX.Comm.Emails.MailKit.Gmail.Configs;
using IRLIX.Comm.Emails.MailKit.Gmail.Mappers;
using IRLIX.Comm.Emails.MailKit.Gmail.Providers;

namespace IRLIX.Comm.Emails.MailKit.Gmail;

public static class Bootstrap
{
    /// <summary>
    /// Add batch Email communication services.
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
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddBatchCommEmailGmail(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsCommEmailGmail(config);
        services.AddCoreCommEmailGmail();

        return services;
    }

    public static IServiceCollection AddCoreCommEmailGmail(
        this IServiceCollection services)
    {
        services.AddSingleton<IEmailSender, GmailEmailSender>();
        services.AddSingleton<IGmailEmailSender, GmailEmailSender>();
        services.AddSingleton<IRecipientEmailDtoToEmailDtoMapper, RecipientEmailDtoToEmailDtoMapper>();

        return services;
    }

    /// <summary>
    /// Add Email communication services via AppSettings.
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
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddAppSettingsCommEmailGmail(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<GmailEmailConfig>(config.GetSection(Consts.CommEmailGmailConfigSectionKey));
        services.AddSingleton<IGmailEmailConfigProvider, GmailEmailConfigProvider>();

        return services;
    }
}
