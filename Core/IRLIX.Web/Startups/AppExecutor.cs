using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups;

public interface IAppExecutor
{
    Task<WebApplication> ExecuteAsync(WebApplicationBuilder builder);
}

public sealed class AppExecutor(
    IEnumerable<IStartup> startups
    ) : IAppExecutor
{
    public async Task<WebApplication> ExecuteAsync(WebApplicationBuilder builder)
    {
        var orderedServiceStartups = startups
            .OrderBy(b => b.ServiceRegistrationOrder)
            .ToArray();

        foreach (var startup in orderedServiceStartups)
        {
            await startup.AddAsync(builder.Services, builder);
        }

        var app = builder.Build();

        var orderedMiddlewareStartups = startups
            .OrderBy(b => b.MiddlewareOrder)
            .ToArray();

        foreach (var startup in orderedMiddlewareStartups)
        {
            await startup.UseAsync(app);
        }

        return app;
    }
}
