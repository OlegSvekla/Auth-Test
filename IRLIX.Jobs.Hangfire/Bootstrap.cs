using Hangfire;
using IRLIX.Core.Interfaces.Jobs;
using IRLIX.Jobs.Hangfire.Authorization;
using IRLIX.Jobs.Hangfire.Authorization.Models;
using IRLIX.Jobs.Hangfire.Configs;
using IRLIX.Jobs.Hangfire.Execution;
using IRLIX.Jobs.Hangfire.Providers;
using IRLIX.Jobs.Hangfire.Sanitization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.Jobs.Hangfire;

public static class Bootstrap
{
    public static IServiceCollection AddBatchJobsHangfire(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddAppSettingsJobsHangfire(config);
        services.AddCoreJobsHangfire();

        return services;
    }

    private static void AddCoreJobsHangfire(
        this IServiceCollection services)
    {
        services.AddSingleton<IJobExecutor, HangfireJobExecutor>();
        services.AddSingleton<IJobSanitazer, HangfireJobSanitazer>();

        services.AddHangfire((sp, config) =>
        {
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
            config.UseSimpleAssemblyNameTypeSerializer();
            config.UseRecommendedSerializerSettings();

            var dbConnectionProvider = sp.GetRequiredService<IDbConnectionProvider>();
            dbConnectionProvider.AddDbConnection(config);
        });

        AddHangfireServerWithWorkerCount(services);
    }

    private static void AddHangfireServerWithWorkerCount(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var workerCountProvider = serviceProvider.GetRequiredService<IHangfireWorkerCountProvider>();
        var workerCount = workerCountProvider.GetWorkerCount();

        services.AddHangfireServer(options => options.WorkerCount = workerCount);
    }

    private static void AddAppSettingsJobsHangfire(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.Configure<HangfireUserCredentials>(config.GetSection(Consts.HangfireUserCredentialsKey));
        services.Configure<HangfireConfig>(config.GetSection(Consts.HangfireSectionKey));

        services.AddSingleton<IHangfireConnectionStringProvider, HangfireConnectionStringProvider>();
        services.AddSingleton<IHangfireUserCredentialsProvider, HangfireUserCredentialsProvider>();
        services.AddSingleton<IHangfireWorkerCountProvider, HangfireWorkerCountProvider>();
    }

    public static async ValueTask<IApplicationBuilder> UseJobsHangfire(
        this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var userProvider = scope.ServiceProvider.GetRequiredService<IHangfireUserCredentialsProvider>();
        var user = userProvider.GetUserCredentials();

        app.UseHangfireDashboard(options: new DashboardOptions
        {
            Authorization = [
                new DashboardAuthorization(
                    users: [
                        new HangfireUserCredentials
                        {
                            Username = user.Username,
                            Password = user.Password
                        } 
                    ]
                )
            ]
        });

        var cleaner = scope.ServiceProvider.GetRequiredService<IJobSanitazer>();
        await cleaner.DeleteAllExistingJobsAsync();

        return app;
    }
}
