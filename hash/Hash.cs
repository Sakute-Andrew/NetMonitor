using System.Security.Cryptography;
using System.Text;

namespace NetMonitor.hash;

public class Hash
{
    public static string HashCode(string password)
    {
        string hash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(password))).Replace("-", string.Empty);
        hash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(hash))).Replace("-", string.Empty);
        return hash;
    }

}