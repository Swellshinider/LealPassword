using System.Security.Cryptography;
using System.Text;

namespace LealPassword.Security
{
    public static class Security
    {
        private static readonly string DefaultKey = "srVgYPaP6TqWkfOLBU4n";

        public static string HashValue(string valueToHash)
        {
            var bytes = Encoding.UTF8.GetBytes(valueToHash);

            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);

                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));

                return hashedInputStringBuilder.ToString();
            }
        }

        public static string Encrypt(string text) 
            => Encrypt(text, DefaultKey);

        public static string Decrypt(string text)
            => Decrypt(text, DefaultKey);

        public static string Encrypt(string text, string key)
            => Encryption.EncryptString(text, key);

        public static string Decrypt(string text, string key)
            => Decryption.DecryptString(key, text);
    }
}