using IRLIX.BL.Otps.Senders;
using Microsoft.Extensions.DependencyInjection;

namespace IRLIX.BL.Otps;

public static class Bootstrap
{
    public static IServiceCollection AddBatchAuthOtps(
        this IServiceCollection services)
    {
        services.AddScoped<IAggregatedEmailSender, AggregatedEmailSender>();

        services.AddScoped<IOtpCodeClient, FourDigitOtpCodeClient>();

        return services;
    }
}
