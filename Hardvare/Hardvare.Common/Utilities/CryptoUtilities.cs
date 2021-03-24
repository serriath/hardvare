using System.Security.Cryptography;

namespace Hardvare.Common.Utilities
{
    public static class CryptoUtilities
    {
        public static byte[] HashPassword(byte[] plainText, byte[] salt)
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

        public static byte[] CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            var buff = new byte[128];
            rng.GetBytes(buff);

            return buff;
        }

    }
}
