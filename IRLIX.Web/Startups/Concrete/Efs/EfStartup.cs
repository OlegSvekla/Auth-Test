using IRLIX.Web.Startups.Abstracts;
using IRLIX.Ef;
using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Efs;

public class EfStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Asap;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder appBuilder)
    {
        services.AddBatchEf(appBuilder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override async ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await scope.ServiceProvider.UseEfAsync(CancellationToken.None);
        return app;
    }
}
