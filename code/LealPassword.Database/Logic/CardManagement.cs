using LealPassword.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LealPassword.Database.Logic
{
    public sealed class CardManagement : Interfaces.ICardManagement
    {
        private readonly ResourceAccess.Interfaces.ICardManagement _resource;
        private readonly string _unhashedPassword;

        public CardManagement(string directory, string fileName, string unhashedPassword)
        {
            _resource = new ResourceAccess.CardManagement(directory, fileName);
            _unhashedPassword = unhashedPassword;
        }

        public void ClearCards()
            => _resource.ClearCards();

        public void DeleteCard(Card card) 
            => _resource.DeleteCard(card.Encrypt(_unhashedPassword));

        public void InsertCard(Card card)
            => _resource.InsertCard(card.Encrypt(_unhashedPassword));

        public void UpdateCard(Card card)
            => _resource.UpdateCard(card.Encrypt(_unhashedPassword));

        public List<Card> GetCards()
            => _resource.GetCards().Select(enCard => enCard.Decrypt(_unhashedPassword)).ToList();

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
