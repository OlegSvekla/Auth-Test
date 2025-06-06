using IRLIX.Core.General;
using IRLIX.Http.Out;
using IRLIX.Http.Out.Models;
using IRLIX.IpMapping.IpApi.Exceptions;
using IRLIX.IpMapping.IpApi.Mappers;
using IRLIX.IpMapping.IpApi.Models;
using IRLIX.IpMapping.IpApi.Providers;
using IRLIX.IpMapping.Models;

namespace IRLIX.IpMapping.IpApi;

public interface IIpApiSearcher : ILocationByIpSearcher;

public sealed class IpApiSearcher(
    IIpApiConfigProvider configProvider,
    IHttpSender httpSender,
    IIpApiRsToFoundLocationMapper mapper
    ) : IIpApiSearcher
{
    public async ValueTask<FoundLocation> SearchLocationByIpAsync(
        string ip,
        CancellationToken ct)
    {
        try
        {
            var (delivered, rs) = await InnerSearchLocationByIpAsync(ip, ct);
            IpApiDataNotDeliveriedException.ThrowWhenNotDileveredSuccessfully(delivered, ip);
            return rs.GetValue();
        }
        catch (Exception ex)
        {
            throw IpApiDataNotDeliveriedException.CreateWhenUnknownEx(ex, ip);
        }
    }

    private async ValueTask<(bool Delivered, FoundLocation? Value)> InnerSearchLocationByIpAsync(
        string ip,
        CancellationToken ct = default)
    {
        var host = configProvider.GetHost();
        var uri = new Uri($"{host}/{ip}");
        var method = HttpMethod.Get;

        var rq = new HttpRq(
            Uri: uri,
            Method: method);
        var rs = await httpSender.ForceSendAsync<IpApiRs>(
            rq: rq,
            ct: ct);

        var result = mapper.Map(rs);
        return (Delivered: true, Value: result);
    }
}
