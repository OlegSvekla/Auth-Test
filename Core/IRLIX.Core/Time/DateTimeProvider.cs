namespace IRLIX.Core.Time;

public interface IDateTimeProvider
{
    DateTimeOffset UtcNow();
}

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset UtcNow() => DateTimeOffset.UtcNow;
}
