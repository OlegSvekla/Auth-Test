using Newtonsoft.Json;

namespace IRLIX.IpMapping.IpApi.Models;

/// <summary>
/// Ip lookup response.
/// Code created by support https://ip-api.com/docs/api:json#test
/// </summary>
public class IpApiRs
{
    /// <summary>
    /// Request status.
    /// Example: success
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; } = default!;

    /// <summary>
    /// Official state name.
    /// Example: Poland
    /// </summary>
    [JsonProperty("country")]
    public string Country { get; set; } = default!;

    /// <summary>
    /// Country iso code in ISO 3166-1 alpha-2 standard.
    /// Example: PL
    /// </summary>
    [JsonProperty("countryCode")]
    public string CountryIsoCode { get; set; } = default!;

    /// <summary>
    /// Region iso code in ISO 3166-2 standard.
    /// Example: Poznan
    /// </summary>
    [JsonProperty("region")]
    public string RegionIsoCode { get; set; } = default!;

    /// <summary>
    /// Official region name.
    /// Example: Greater Poland
    /// </summary>
    [JsonProperty("regionName")]
    public string Region { get; set; } = default!;

    /// <summary>
    /// Official city name.
    /// Example: Poznan
    /// </summary>
    [JsonProperty("city")]
    public string City { get; set; } = default!;

    /// <summary>
    /// Zip code.
    /// Example: 61-005
    /// </summary>
    [JsonProperty("zip")]
    public string ZipCode { get; set; } = default!;

    /// <summary>
    /// Latitude.
    /// Example: 52.3867
    /// </summary>
    [JsonProperty("lat")]
    public decimal Latitude { get; set; }

    /// <summary>
    /// Longitude.
    /// Example: 16.8988
    /// </summary>
    [JsonProperty("lon")]
    public decimal Longitude { get; set; }

    /// <summary>
    /// Time zone name.
    /// Example: Europe/Warsaw
    /// </summary>
    [JsonProperty("timezone")]
    public string TimeZone { get; set; } = default!;

    /// <summary>
    /// Internet service provider.
    /// Example: Inea S.A
    /// </summary>
    [JsonProperty("isp")]
    public string InternetServiceProvider { get; set; } = default!;

    /// <summary>
    /// Organization name.
    /// Example: Google
    /// </summary>
    [JsonProperty("org")]
    public string Organization { get; set; } = default!;

    /// <summary>
    /// AS number and organization, separated by space (RIR). Empty for IP blocks not being announced in BGP tables.
    /// Example: AS15169 Google Inc.
    /// </summary>
    [JsonProperty("as")]
    public string AutonomousSystem { get; set; } = default!;
}
