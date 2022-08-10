using System.Collections.Generic;

namespace LealPassword.Database.Entity
{
    public sealed class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Card> Cards { get; set; }
        public List<Register> Registers { get; set; }
    }
}