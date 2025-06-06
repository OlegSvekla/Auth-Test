using IRLIX.BL.Handlers.Jobs;

namespace IRLIX.Auth.Web;

public static class JobsRegistrator
{
    public static async void StartupJobs(
        IServiceScope scope,
        CancellationToken ct)
    {
        var deleteExpiresRefreshTokens = scope.ServiceProvider.GetRequiredService<IDeleteExpiresRefreshTokens>();

        await deleteExpiresRefreshTokens.ExecuteAsync(ct);
    }
}
