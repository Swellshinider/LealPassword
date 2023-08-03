using LealPassword.Security;

namespace LealPassword.Database.Entity
{
    public sealed class Register
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string ImageKey { get; set; }
        public string Password { get; set; }

        internal Register Encrypt(string encryptionKey)
        {
            Name = Name.Encrypt(encryptionKey);
            Description = Description.Encrypt(encryptionKey);
            Tag = Tag.Encrypt(encryptionKey);
            Email = Email.Encrypt(encryptionKey);
            Password = Password.Encrypt(encryptionKey);
            ImageKey = ImageKey.Encrypt(encryptionKey);

            return this;
        }

        internal Register Decrypt(string decryptionKey)
        {
            Name = Name.Decrypt(decryptionKey);
            Description = Description.Decrypt(decryptionKey);
            Tag = Tag.Decrypt(decryptionKey);
            Email = Email.Decrypt(decryptionKey);
            Password = Password.Decrypt(decryptionKey);
            ImageKey = ImageKey.Decrypt(decryptionKey);

            return this;
        }
    }
}