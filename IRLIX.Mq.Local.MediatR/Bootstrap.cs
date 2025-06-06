using IRLIX.Mq.Buses;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.Mq.Local.MediatR;

public static class Bootstrap
{
    public static void AddBatchMqLocalMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg
            => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddScoped<ILocalMessageBus, MediatrLocalMessageBus>();
        services.AddScoped<IMediatrLocalMessageBus, MediatrLocalMessageBus>();
    }
}
