using LealPassword.Database.Logic;
using LealPassword.Database.Model;
using System.Collections.Generic;

namespace LealPassword.Database.Controllers
{
    internal sealed class CardController : BaseController
    {
        internal CardController(string directory, string fileName, string unhashedPassword)
            : base(directory, fileName, unhashedPassword) { }

        internal void ClearCards()
        {
            using (var logic = new CardManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.ClearCards();
            }
        }

        internal void UpdateCard(Card card)
        {
            var entity = Mapper.Map(card);

            using (var logic = new CardManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.UpdateCard(entity);
            }
        }

        internal void InsertCard(Card card)
        {
            var entity = Mapper.Map(card);

            using (var logic = new CardManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.InsertCard(entity);
            }
        }

        internal void DeleteCard(Card card)
        {
            var entity = Mapper.Map(card);

            using (var logic = new CardManagement(_directory, _fileName, _unhashedPassword))
            {
                logic.DeleteCard(entity);
            }
        }

        internal List<Card> GetCards()
        {
            using (var logic = new CardManagement(_directory, _fileName, _unhashedPassword))
            {
                var entity = logic.GetCards();
                return Mapper.Map(entity);
            }
        }
    }
}