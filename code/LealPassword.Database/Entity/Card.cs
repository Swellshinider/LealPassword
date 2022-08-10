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
    }
}