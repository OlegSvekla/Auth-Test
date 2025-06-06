using Newtonsoft.Json;

namespace IRLIX.IpMapping.ApiIpLocation.Models;

public class ApiIpLocationRs
{
    /// <summary>
    /// Official state name.
    /// Example: Poland
    /// </summary>
    [JsonProperty("country_name")]
    public string Country { get; set; } = default!;

    /// <summary>
    /// Country iso code in ISO 3166-1 alpha-2 standard.
    /// Example: PL
    /// </summary>
    [JsonProperty("country_code2")]
    public string CountryIsoCode { get; set; } = default!;

    /// <summary>
    /// Internet service provider.
    /// Example: Inea S.A
    /// </summary>
    [JsonProperty("isp")]
    public string InternetServiceProvider { get; set; } = default!;
}
