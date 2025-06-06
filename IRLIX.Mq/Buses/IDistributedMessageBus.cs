namespace IRLIX.Mq.Buses;

public interface IDistributedMessageBus
    : ICommandDispatcher,
    IEventDispatcher,
    IQueryDispatcher
{
}
