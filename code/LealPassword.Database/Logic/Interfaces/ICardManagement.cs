using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.Database.Logic.Interfaces
{
    internal interface ICardManagement : IDisposable
    {
        void ClearCards();
        void InsertCard(Card card);
        void UpdateCard(Card card);
        void DeleteCard(Card card);
        List<Card> GetCards();
    }
}