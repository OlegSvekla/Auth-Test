namespace IRLIX.Mq.Buses;

public interface ILocalMessageBus
    : ICommandDispatcher,
    IEventDispatcher,
    IQueryDispatcher
{
}
