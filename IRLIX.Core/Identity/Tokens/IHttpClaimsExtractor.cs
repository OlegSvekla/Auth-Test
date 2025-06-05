namespace IRLIX.Core.Identity.Tokens;

public interface IHttpClaimsExtractor
{
    Guid ExtractUserId();

    string ExtractUserName();

    Guid ExtractSessionId();

    string ExtractDeviceId();
}
