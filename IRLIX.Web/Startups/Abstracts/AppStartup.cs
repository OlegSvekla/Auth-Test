namespace IRLIX.Web.Startups.Abstracts;

public interface IAppStartup : IStartup
{
}

public abstract class AppStartup
    : BaseStartup, IAppStartup
{
    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder appBuilder)
        => ValueTask.FromResult(services);
}
