using IRLIX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Mqs;

public class MqDistributedHttpKafkaStartup : ServiceStartup
{
    public override ServiceRegistrationOrderEnum ServiceRegistrationOrder
        => ServiceRegistrationOrderEnum.Medium;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchMqDistributedHttpKafka();

        return ValueTask.FromResult(services);
    }
}
