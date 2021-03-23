using System.Security.Cryptography;

namespace Hardvare.Services.Utilities
{
    public static class CryptoUtilities
    {
        internal static byte[] HashPassword(byte[] plainText, byte[] salt)
        {
            var algorithm = new SHA256Managed();

            var plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }

            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        internal static byte[] CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            var buff = new byte[128];
            rng.GetBytes(buff);

            return buff;
        }

    }
}
