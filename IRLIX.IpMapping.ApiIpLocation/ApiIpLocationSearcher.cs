using IRLIX.Core.General;
using IRLIX.Http.Out;
using IRLIX.Http.Out.Models;
using IRLIX.IpMapping.ApiIpLocation.Exceptions;
using IRLIX.IpMapping.ApiIpLocation.Mappers;
using IRLIX.IpMapping.ApiIpLocation.Models;
using IRLIX.IpMapping.ApiIpLocation.Providers;
using IRLIX.IpMapping.Models;

namespace IRLIX.IpMapping.ApiIpLocation;

public interface IApiIpLocationSearcher : ILocationByIpSearcher;

public sealed class ApiIpLocationSearcher(
    IApiIpLocationConfigProvider configProvider,
    IHttpSender httpSender,
    IApiIpLocationRsToFoundLocationMapper mapper
    ) : IApiIpLocationSearcher
{
    public async ValueTask<FoundLocation> SearchLocationByIpAsync(
        string ip,
        CancellationToken ct)
    {
        try
        {
            var (delivered, rs) = await InnerSearchLocationByIpAsync(ip, ct);
            ApiIpLocationDataNotDeliveriedException.ThrowWhenNotDileveredSuccessfully(delivered, ip);
            return rs.GetValue();
        }
        catch (Exception ex)
        {
            throw ApiIpLocationDataNotDeliveriedException.CreateWhenUnknownEx(ex, ip);
        }
    }

    private async ValueTask<(bool Delivered, FoundLocation? Value)> InnerSearchLocationByIpAsync(
        string ip,
        CancellationToken ct = default)
    {
        var host = configProvider.GetHost();
        var uri = new Uri(host);
        var method = HttpMethod.Get;
        var queries = new Dictionary<string, string>()
        {
            { Consts.QueryIp, ip }
        };

        var rq = new HttpRq(
            Uri: uri,
            Method: method,
            Queries: queries);
        var rs = await httpSender.ForceSendAsync<ApiIpLocationRs>(
            rq: rq,
            ct: ct);

        var result = mapper.Map(rs);
        return (Delivered: true, Value: result);
    }
}
