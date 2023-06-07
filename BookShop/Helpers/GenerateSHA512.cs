using System.Security.Cryptography;
using System.Text;

namespace BookShop.Helpers;

public static class GenerateSHA512
{
    public static string Create(string input)
    {
        using SHA512 hash = SHA512.Create();
        return Convert.ToHexString(hash.ComputeHash(Encoding.UTF8.GetBytes(input)));
    }
}
