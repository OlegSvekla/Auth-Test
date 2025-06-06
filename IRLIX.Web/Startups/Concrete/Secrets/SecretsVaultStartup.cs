using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Secrets;

/// <summary>
/// Vault secrets
/// 
/// Require services:
/// * EncVaultStartup
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "Secrets": {
///         ...,
///         "Vault": {
///             "DefaultMountPath": "string"
///         },
///         ...
///     },
///     ...
/// }
/// </summary>
public class SecretsVaultStartup : ServiceStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchSecretsVault(builder.Configuration);
        return ValueTask.FromResult(services);
    }
}
