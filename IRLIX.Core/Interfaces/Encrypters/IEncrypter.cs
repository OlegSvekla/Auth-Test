namespace IRLIX.Core.Interfaces.Encrypters;

public interface IEncrypter
{
    ValueTask<string> EncryptAsync(
        string value,
        CancellationToken ct = default);

    ValueTask<string> DecryptAsync(
        string encValue,
        CancellationToken ct = default);
}
