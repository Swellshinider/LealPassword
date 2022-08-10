using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace LealPassword.Security
{
    internal static class Decryption
    {
        internal static string DecryptString(string key, string decryptionText)
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(decryptionText);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var memoryStream = new MemoryStream(buffer))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}