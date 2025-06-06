namespace IRLIX.Core.Exceptions.Helpers;

public static class NullReferenceExceptionHelper
{
    public static void ThrowWhenNull<T>(T? value)
    {
        if (value is null)
        {
            throw new NullReferenceException(nameof(T));
        }
    }
}
