using IRLIX.Web.Startups.Abstracts;
using ShuttleX.Web.Models;

namespace IRLIX.Web.Startups.Concrete.WebApis;

public sealed class ValidationStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Validation;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchWebValidationFluentValidation();
        services.AddBatchWebModelValidators();

        return ValueTask.FromResult(services);
    }

    public override ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        app.UseValidation();
        return ValueTask.FromResult(app);
    }
}
