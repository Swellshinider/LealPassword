using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace LealPassword.Security
{
    public static class Security
    {
        private static readonly string DefaultKey = "srVgYPaP6TqWkfOLBU4n";

        private static readonly string UpperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string LowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string NumberListing = "1234567890";
        private static readonly string EspecialChars = "!@#%*?&";

        public static string GeneratePassword(int size = 8)
        {
            var password = new StringBuilder();
            password.Append(GetRandomCharacter(EspecialChars));
            password.Append(GetRandomCharacter(LowerAlphabet));
            password.Append(GetRandomCharacter(UpperAlphabet));
            password.Append(GetRandomCharacter(NumberListing));

            for (int i = 0; i < size - 4; i++)
                password.Append(GetRandomCharacter(EspecialChars + LowerAlphabet + UpperAlphabet + NumberListing));

            return password.ToString().Shuffle();
        }

        public static int GetPasswordStrength(string text)
        {
            var counter = 0;

            if (text.Length >= 10)
                counter++;

            if (HasDigit(text))
                counter++;

            if (HasLowerCaseLetter(text))
                counter++;

            if (HasUpperCaseLetter(text))
                counter++;

            if (HasSpecialChar(text))
                counter++;

            return counter;
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

        public static string Encrypt(this string text) => Encrypt(text, DefaultKey);

        public static string Decrypt(this string text) => Decrypt(text, DefaultKey);

        public static string Encrypt(this string text, string key) => Encryption.EncryptString(key, text);

        public static string Decrypt(this string text, string key) => Decryption.DecryptString(key, text);

        private static bool HasDigit(string text) => text.Any(c => char.IsDigit(c));

        private static bool HasLowerCaseLetter(string text) => text.Any(c => char.IsLower(c));

        private static bool HasUpperCaseLetter(string text) => text.Any(c => char.IsUpper(c));

        private static bool HasSpecialChar(string text) => text.IndexOfAny(EspecialChars.ToCharArray()) != -1;

        private static string Shuffle(this string str)
        {
            var array = str.ToCharArray();
            int n = array.Length;

            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                (array[n], array[k]) = (array[k], array[n]);
            }

            return new string(array);
        }

        private static char GetRandomCharacter(string charSet)
        {
            int index = new Random().Next(0, charSet.Length);
            return charSet[index];
        }
    }
}