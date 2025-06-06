using IRLIX.Core.General;
using IRLIX.Mq.Messages;
using System.Collections.Concurrent;
using System.Data;

namespace IRLIX.Mq.Assemblies;

public interface ISolutionCommandTypeSearcher
{
    Type? FindCommandTypeByFriendlyShortName(string name);
}

public interface ISolutionEventTypeSearcher
{
    Type? FindEventTypeByFriendlyShortName(string name);
}

public interface ISolutionQueryTypeSearcher
{
    Type? FindQueryTypeByFriendlyShortName(string name);
}

public class SolutionMessageTypeSearcher
    : ISolutionCommandTypeSearcher,
    ISolutionEventTypeSearcher,
    ISolutionQueryTypeSearcher
{
    private readonly IDictionary<string, Type> commandNameTypeDict;
    private readonly IDictionary<string, Type> eventNameTypeDict;
    private readonly IDictionary<string, Type> queryNameTypeDict;

    public SolutionMessageTypeSearcher()
    {
        var commandTypes = SolutionHelper.GetSolutionClassesByInterface<ICommand>();
        var eventTypes = SolutionHelper.GetSolutionClassesByInterface<IEvent>();
        var queryTypes = SolutionHelper.GetSolutionClassesByInterface<IQuery>();

        var commandNameTypePairs = commandTypes
            .Select(commandType => new KeyValuePair<string, Type>(
                key: commandType.GetFriendlyShortName(),
                value: commandType));
        var eventNameTypePairs = eventTypes
            .Select(eventType => new KeyValuePair<string, Type>(
                key: eventType.GetFriendlyShortName(),
                value: eventType));
        var queryNameTypePairs = queryTypes
            .Select(queryType => new KeyValuePair<string, Type>(
                key: queryType.GetFriendlyShortName(),
                value: queryType));

        commandNameTypeDict = new ConcurrentDictionary<string, Type>(commandNameTypePairs);
        eventNameTypeDict = new ConcurrentDictionary<string, Type>(eventNameTypePairs);
        queryNameTypeDict = new ConcurrentDictionary<string, Type>(queryNameTypePairs);
    }

    public Type? FindCommandTypeByFriendlyShortName(string name)
    {
        commandNameTypeDict.TryGetValue(name, out var value);
        return value;
    }

    public Type? FindEventTypeByFriendlyShortName(string name)
    {
        eventNameTypeDict.TryGetValue(name, out var value);
        return value;
    }

    public Type? FindQueryTypeByFriendlyShortName(string name)
    {
        queryNameTypeDict.TryGetValue(name, out var value);
        return value;
    }
}
