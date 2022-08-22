using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;

namespace LealPassword.Database.Logic
{
    public sealed class CardManagement : Interfaces.ICardManagement
    {
        private readonly ResourceAccess.Interfaces.ICardManagement _resource;

        public CardManagement(string directory, string fileName)
        {
            _resource = new ResourceAccess.CardManagement(directory, fileName);
        }

        public void ClearCards()
            => _resource.ClearCards();

        public void DeleteCard(Card card)
            => _resource.DeleteCard(card);

        public void InsertCard(Card card)
            => _resource.InsertCard(card);

        public void UpdateCard(Card card)
            => _resource.UpdateCard(card);

        public List<Card> GetCards()
            => _resource.GetCards();

        #region Dispose
        private void Dispose(bool disposing)
        {
            if (disposing)
                _resource.Dispose();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
