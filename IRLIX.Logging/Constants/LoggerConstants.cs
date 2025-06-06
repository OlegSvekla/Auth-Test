namespace IRLIX.Logging.Constants;

public static class LoggerConstants
{
    public const string AuthMessageAboutParameters = "Log enriched with all parameters from CallContext";
    public const string MessageWithTrackedData = "Log potentialy enriched only with part of CallContext, can have another tracked data";
    public const string EmptyMessage = "Empty message";
    
    public const string HangfireStartJob = "Hangfire start job";
    public const string HangfireFinishJob = "Hangfire finish job";
    
    public const string Request = "Request";
    
    public const string LocalField = "TypeOfAction";
    
    public const string KafkaListenTopic = "Service listen kafka topic";
    public const string KafkaConsumeMessage = "Service consume message from kafka";
    public const string KafkaErrorMessage = "Service when handle message from kafka throw exception";

}
