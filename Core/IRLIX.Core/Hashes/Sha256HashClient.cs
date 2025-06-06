using IRLIX.Core.General;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace IRLIX.Core.Hashes;

public interface IHashClient
{
    string Generate(string input);

    bool Validate(string input, string hash);
}

internal class Sha256HashClient : IHashClient
{
    public string Generate(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA256.HashData(bytes);

        var builder = new StringBuilder();
        hashBytes.ForEach(b
            => builder.Append(b.ToString("x2", CultureInfo.InvariantCulture)));

        var result = builder.ToString();
        return result;
    }

    public bool Validate(string input, string hash)
    {
        var inputHash = Generate(input);
        var result = inputHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
        return result;
    }
}
