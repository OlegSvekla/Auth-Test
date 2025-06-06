using IRLIX.Core.Interfaces.Mappers;
using IRLIX.IpMapping.ApiIpLocation.Models;
using IRLIX.IpMapping.Models;

namespace IRLIX.IpMapping.ApiIpLocation.Mappers;

public interface IApiIpLocationRsToFoundLocationMapper
    : IMapper<ApiIpLocationRs, FoundLocation>;

public class ApiIpLocationRsToFoundLocationMapper
    : IApiIpLocationRsToFoundLocationMapper
{
    public FoundLocation Map(ApiIpLocationRs input)
        => new FoundLocation(
            CountryIsoCode: input.CountryIsoCode
            );
}
