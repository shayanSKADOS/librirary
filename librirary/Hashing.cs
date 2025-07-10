using System.Security.Cryptography;
using System.Text;

namespace Library;

public class Hashing
{
    public static string QuickHash(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var inputHash = SHA256.HashData(inputBytes);
        return Convert.ToHexString(inputHash);
    }
}
