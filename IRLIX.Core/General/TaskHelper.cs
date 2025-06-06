namespace IRLIX.Core.General;

public static class TaskHelper
{
    public static async ValueTask AsValueTask(
        this Task value)
        => await value;

    public static async ValueTask<TResult> AsValueTask<TResult>(
        this Task<TResult> value)
        => await value;

    public static async ValueTask AsValueTaskNoResult<TResult>(
        this Task<TResult> value)
        => await value;
}
