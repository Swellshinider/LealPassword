namespace LealPassword.Security
{
    public static class Security
    {
        private static readonly string DefaultKey = "srVgYPaP6TqWkfOLBU4n";

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