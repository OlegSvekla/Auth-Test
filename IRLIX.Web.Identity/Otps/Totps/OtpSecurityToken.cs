namespace IRLIX.Web.Identity.Otps.Totps;

internal sealed class OtpSecurityToken(
    byte[] data
    )
{
    private readonly byte[] _data
        = (byte[])data.Clone();

    internal byte[] GetDataNoClone()
        => _data;
}
