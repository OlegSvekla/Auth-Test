using Microsoft.Extensions.Hosting;
using ShuttleX.Web.Startups.Abstracts;
using ShuttleX.Web.Swagger;

namespace IRLIX.Web.Startups.Concrete.WebApis;

/// <summary>
/// Swagger.
/// It provides ability to see exist endpoints.
/// See <see cref="https://aka.ms/aspnetcore/swashbuckle"/>
/// </summary>
public sealed class SwaggerStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.PreEndpoint;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder appBuilder)
    {
        services.AddBatchSwagger(appBuilder.Configuration, appBuilder.Environment.EnvironmentName);

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        if (app.Environment.IsDevelopment()
            || app.Environment.IsEnvironment("tst")
            || app.Environment.IsEnvironment("docker"))
        {
            app.UseBatchSwagger();
        }

        return ValueTask.FromResult(app);
    }
}
