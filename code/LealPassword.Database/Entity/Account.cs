using LealPassword.Security;
using System.Collections.Generic;

namespace LealPassword.Database.Entity
{
    public sealed class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Card> Cards { get; set; }
        public List<Register> Registers { get; set; }

        internal Account Encrypt(string encryptionKey)
        {
            Username = Username.Encrypt(encryptionKey);
            Password = Password.Encrypt(encryptionKey);

            return this;
        }

        internal Account Decrypt(string decryptionKey)
        {
            Username = Username.Decrypt(decryptionKey);
            Password = Password.Decrypt(decryptionKey);

            return this;
        }
    }
}