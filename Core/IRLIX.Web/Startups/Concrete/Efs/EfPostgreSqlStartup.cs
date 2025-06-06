using IRLIX.Ef;
using IRLIX.Web.Startups.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace IRLIX.Web.Startups.Concrete.Efs;

public class EfPostgreSqlStartup<TEfContext> : ServiceStartup
    where TEfContext : DbContext, IEfContext
{
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Medium;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder appBuilder)
    {
        services.AddPostgreSqlEfConnection<TEfContext>(appBuilder.Configuration);

        return ValueTask.FromResult(services);
    }
}
