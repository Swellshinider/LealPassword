using LealPassword.Security;
using System;

namespace LealPassword.Database.Entity
{
    public sealed class Card
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public string OwnrName { get; set; }
        public string Number { get; set; }
        public DateTime DueDate { get; set; }
        public short SecurityNumber { get; set; }

        internal Card Encrypt(string encryptionKey)
        {
            CardName = CardName.Encrypt(encryptionKey);
            OwnrName = OwnrName.Encrypt(encryptionKey);
            Number = Number.Encrypt(encryptionKey);

            return this;
        }

        internal Card Decrypt(string decryptionKey)
        {
            CardName = CardName.Decrypt(decryptionKey);
            OwnrName = OwnrName.Decrypt(decryptionKey);
            Number = Number.Decrypt(decryptionKey);

            return this;
        }
    }
}