using ShuttleX.Mq.Distributed.Kafka;
using ShuttleX.Web.Startups.Abstracts;

namespace IRLIX.Web.Startups.Concrete.Mqs;

/// <summary>
/// Kafka distributed message queue services.
/// 
/// Require services:
/// * IJobExecutor
/// * IMicroserviceDataProvider
/// * ILocalMessageBus
/// 
/// Require AppSettings section:
/// {
///     ...,
///     "Mq": {
///         "Kafka": {
///             "BootstrapServers": [
///                 ...,
///                 string,
///                 ...
///             ],
///             "StatisticsIntervalMs": int,
///             "Topic": {
///                 "TopicReplicationFactor": short,
///                 "TopicNumPartitions": int
///             },
///             "In": {
///                 "CommandSubscriptions": [
///                     ...,
///                     {
///                         "TasksCount": int,
///                         "Topics": [
///                             ...,
///                             string,
///                             ...
///                         ]
///                     },
///                     ...
///                 ],
///                 "EventSubscriptions": [
///                     ...,
///                     {
///                         "TasksCount": int,
///                         "Topics": [
///                             ...,
///                             string,
///                             ...
///                         ]
///                     },
///                     ...
///                 ],
///             },
///             "Out": {
///                 "MessageTimeoutMs": int,
///                 "MessageSendMaxRetries": int,
///                 "RetryBackoffMs": int
///             }
///         }
///     },
///     ...
/// }
/// </summary>
public sealed class MqDistributedKafkaStartup : BaseStartup
{
    public override MiddlewareOrderEnum MiddlewareOrder
        => MiddlewareOrderEnum.Jobs;

    public override ValueTask<IServiceCollection> AddAsync(
        IServiceCollection services,
        WebApplicationBuilder builder)
    {
        services.AddBatchMqDistributedKafka(builder.Configuration);

        return ValueTask.FromResult(services);
    }

    public override async ValueTask<WebApplication> UseAsync(
        WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await scope.ServiceProvider.UseKafkaJobsAsync(CancellationToken.None);
        return app;
    }
}
