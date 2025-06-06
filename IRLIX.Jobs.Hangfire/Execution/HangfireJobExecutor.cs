using Hangfire;
using IRLIX.Core.Interfaces.Jobs;
using IRLIX.Jobs.Hangfire.CronExpressionGenerator;
using System.Linq.Expressions;

namespace IRLIX.Jobs.Hangfire.Execution;

public class HangfireJobExecutor : IJobExecutor
{
    public string Execute<T>(
        Expression<Action<T>> methodCall)
        where T : IJobWrapper
        => BackgroundJob.Enqueue(methodCall);

    public string Execute<T>(
        Expression<Func<T, Task>> methodCall)
        where T : IJobWrapper
        => BackgroundJob.Enqueue(methodCall);

    public string Schedule<T>(
        Expression<Action<T>> methodCall,
        TimeSpan delay)
        where T : IJobWrapper
        => BackgroundJob.Schedule(methodCall, delay);

    public string Schedule<T>(
        Expression<Func<T, Task>> methodCall,
        TimeSpan delay)
        where T : IJobWrapper
        => BackgroundJob.Schedule(methodCall, delay);

    public void Recurring<T>(
        Expression<Action<T>> methodCall,
        string cronExpression,
        string? jobId = null)
        where T : IJobWrapper
    {
        if (string.IsNullOrWhiteSpace(jobId))
        {
            jobId = Guid.NewGuid().ToString();
        }

        RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression);
    }

    public void RecurringEveryMinutes<T>(
        Expression<Action<T>> methodCall,
        int minutes,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateMinutesCronExpression(minutes);
        Recurring(methodCall, cronExpression, jobId);
    }

    public void RecurringEveryHours<T>(
        Expression<Action<T>> methodCall,
        int hours,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateHourlyCronExpression(hours);
        Recurring(methodCall, cronExpression, jobId);
    }

    public void RecurringDaily<T>(
        Expression<Action<T>> methodCall,
        TimeSpan runTime,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateDailyCronExpression(runTime);
        Recurring(methodCall, cronExpression, jobId);
    }

    public void RecurringOnDays<T>(
        Expression<Action<T>> methodCall,
        TimeSpan runTime,
        List<DayOfWeek> daysToRun,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateMultiDayCronExpression(runTime, daysToRun);
        Recurring(methodCall, cronExpression, jobId);
    }

    public void Recurring<T>(
        Expression<Func<T, Task>> methodCall,
        string cronExpression,
        string? jobId = null)
        where T : IJobWrapper
    {
        if (string.IsNullOrWhiteSpace(jobId))
        {
            jobId = Guid.NewGuid().ToString();
        }

        RecurringJob.AddOrUpdate(jobId, methodCall, cronExpression);
    }

    public void RecurringEveryMinutes<T>(
        Expression<Func<T, Task>> methodCall,
        int minutes,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateMinutesCronExpression(minutes);
        Recurring(methodCall, cronExpression, jobId);
    }

    public void RecurringEveryHours<T>(
        Expression<Func<T, Task>> methodCall,
        int hours,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateHourlyCronExpression(hours);
        Recurring(methodCall, cronExpression, jobId);
    }

    public void RecurringDaily<T>(
        Expression<Func<T, Task>> methodCall,
        TimeSpan runTime,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateDailyCronExpression(runTime);
        Recurring(methodCall, cronExpression, jobId);
    }

    public void RecurringOnDays<T>(
        Expression<Func<T, Task>> methodCall,
        TimeSpan runTime,
        List<DayOfWeek> daysToRun,
        string? jobId = null)
        where T : IJobWrapper
    {
        var cronExpression = CronGenerator.GenerateMultiDayCronExpression(runTime, daysToRun);
        Recurring(methodCall, cronExpression, jobId);
    }
}
