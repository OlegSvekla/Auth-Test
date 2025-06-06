namespace IRLIX.Jobs.Hangfire.CronExpressionGenerator.Utils;

public record CronValidationResults(
    bool IsValidCron,
    string ValidationMessage
    );
