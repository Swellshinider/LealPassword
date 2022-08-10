using System.Collections.Generic;

namespace LealPassword.Database.Model
{
    internal sealed class Account
    {
        internal string Username { get; set; }
        internal string Password { get; set; }
        internal List<Card> Cards { get; set; }
        internal List<Register> Registers { get; set; }
    }
}