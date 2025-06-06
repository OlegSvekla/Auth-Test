using System.Runtime.CompilerServices;

namespace IRLIX.Core.Exceptions.Helpers;

public static class ArgumentOutOfRangeExceptionHelper
{
    private const int MaxOneItemEnumerableLength = 1;

    public static void ThrowIfGreaterThanOneItemEnumerable<T>(
        IEnumerable<T> value,
        [CallerArgumentExpression(nameof(value))] string? paramName = null)
        => ArgumentOutOfRangeException.ThrowIfGreaterThan(
            value: value.Count(),
            other: MaxOneItemEnumerableLength,
            paramName: paramName);
}
