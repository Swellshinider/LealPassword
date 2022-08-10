using System;

namespace LealPassword.Database.Model
{
    internal sealed class Card
    {
        internal int Id { get; set; }
        internal string CardName { get; set; }
        internal string OwnrName { get; set; }
        internal string Number { get; set; }
        internal DateTime DueDate { get; set; }
        internal short SecurityNumber { get; set; }
    }
}