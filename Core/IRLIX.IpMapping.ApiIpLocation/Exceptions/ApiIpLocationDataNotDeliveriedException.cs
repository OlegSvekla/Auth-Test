using IRLIX.Core.Exceptions;

namespace IRLIX.IpMapping.ApiIpLocation.Exceptions;

public class ApiIpLocationDataNotDeliveriedException(
    string message,
    Exception? innerEx = null
    ) : DomainException(
        message: message,
        innerEx: innerEx)
{
    public override int Code => (int)ExCodes.DataNotDeliveried;

    public static ApiIpLocationDataNotDeliveriedException CreateWhenUnknownEx(Exception innerEx, string ip)
        => new ApiIpLocationDataNotDeliveriedException(
            message: $"ApiIpLocation ip mapping error: on ip '{ip}' has not been delivered due to internal error",
            innerEx: innerEx);

    public static void ThrowWhenNotDileveredSuccessfully(bool delivered, string ip)
    {
        if (!delivered)
        {
            throw new ApiIpLocationDataNotDeliveriedException(
                message: $"ApiIpLocation ip mapping error: on ip '{ip}' has not been delivered successfully");
        }
    }
}
