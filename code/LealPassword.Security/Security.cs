using System;
using System.Text;
using System.Security.Cryptography;

namespace LealPassword.Security
{
    public static class Security
    {
        private static readonly string DefaultKey = "srVgYPaP6TqWkfOLBU4n";

        private static readonly Random Random = new Random();
        private static readonly string UpperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string LowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string NumberListing = "1234567890";
        private static readonly string EspecialChars = "!@#%";

        public static string GeneratePassword(string seed)
        {
            var gen = new StringBuilder();

            foreach(var c in seed)
            {
                switch (c)
                {
                    case '1':
                        {
                            var index = Random.Next(0, UpperAlphabet.Length);
                            gen.Append(UpperAlphabet[index]);
                            break;
                        }
                    case '2':
                        {
                            var index = Random.Next(0, LowerAlphabet.Length);
                            gen.Append(LowerAlphabet[index]);
                            break;
                        }
                    case '3':
                        {
                            var index = Random.Next(0, NumberListing.Length);
                            gen.Append(NumberListing[index]);
                            break;
                        }
                    default:
                        {
                            var index = Random.Next(0, EspecialChars.Length);
                            gen.Append(EspecialChars[index]);
                            break;
                        }
                }
            }

            return gen.ToString().Shuffle();
        }

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

        private static string Shuffle(this string str)
        {
            var array = str.ToCharArray();
            var rng = new Random();
            int n = array.Length;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }

            return new string(array);
        }
    }
}