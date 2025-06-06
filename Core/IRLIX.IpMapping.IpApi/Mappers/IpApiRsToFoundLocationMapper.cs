using IRLIX.Core.Interfaces.Mappers;
using IRLIX.IpMapping.IpApi.Models;
using IRLIX.IpMapping.Models;

namespace IRLIX.IpMapping.IpApi.Mappers;

public interface IIpApiRsToFoundLocationMapper
    : IMapper<IpApiRs, FoundLocation>;

public class IpApiRsToFoundLocationMapper
    : IIpApiRsToFoundLocationMapper
{
    public FoundLocation Map(IpApiRs input)
        => new FoundLocation(
            CountryIsoCode: input.CountryIsoCode,
            RegionIsoCode: input.RegionIsoCode,
            City: input.City
            );
}
