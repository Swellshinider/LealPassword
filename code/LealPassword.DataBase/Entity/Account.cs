using System.Collections.Generic;

namespace LealPassword.DataBase.Entity
{
    public sealed class Account
    {
        internal string Name { get; set; }
        internal string Key { get; set; }
        internal List<Register> Registers { get; set; }
    }
}