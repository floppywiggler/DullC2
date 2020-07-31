using System;
using System.Linq;
using System.Text;

namespace TeamServer
{
    public class Helpers
    {
        public static byte[] GeneratePseudoRandomBytes(int length)
        {
            return Encoding.UTF8.GetBytes(GeneratePseudoRandomString(length));
        }

        public static string GeneratePseudoRandomString(int length) // Not cryptographically sound this one... But we're not protecting nation secrets.
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
