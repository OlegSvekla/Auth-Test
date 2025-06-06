using IRLIX.Core.Exceptions;

namespace IRLIX.IpMapping.IpApi.Exceptions;

public class IpApiDataNotDeliveriedException(
    string message,
    Exception? innerEx = null
    ) : DomainException(
        message: message,
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.DataNotDeliveried;

    public static IpApiDataNotDeliveriedException CreateWhenUnknownEx(Exception innerEx, string ip)
        => new IpApiDataNotDeliveriedException(
            message: $"IpApi ip mapping error: on ip '{ip}' has not been delivered due to internal error",
            innerEx: innerEx);

    public static void ThrowWhenNotDileveredSuccessfully(bool delivered, string ip)
    {
        if (!delivered)
        {
            throw new IpApiDataNotDeliveriedException(
                message: $"IpApi ip mapping error: on ip '{ip}' has not been delivered successfully");
        }
    }
}
