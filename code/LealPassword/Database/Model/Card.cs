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

        internal bool Equals(Card other)
        {
            return Id == other.Id && 
                CardName == other.CardName && 
                OwnrName == other.OwnrName && 
                Number == other.Number && 
                DueDate.Day == other.DueDate.Day &&
                DueDate.Month == other.DueDate.Month &&
                DueDate.Year == other.DueDate.Year &&
                SecurityNumber == other.SecurityNumber;
        }
    }
}