using LealPassword.Database.Model;
using LealPassword.Themes;
using LealPassword.UI.Extension;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.RegCardManageSub
{
    internal sealed partial class CardViewUI : UserControl
    {
        internal delegate void SeeMe(Card card);
        internal event SeeMe OnSeeMe;

        private readonly List<Card> _cards;

        internal CardViewUI(List<Card> registers, Control parent)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _cards = registers;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            BackColor = Color.Transparent;
            GenerateObjects();
        }

        internal void Filter(string filter)
        {
            Controls.Clear();

            if (filter == "" || filter == null)
            {
                GenerateObjects();
                return;
            }

            filter = filter.ToLower();

            foreach (var card in _cards)
            {
                if (!card.CardName.ToLower().Contains(filter) &&
                    !card.CardName.ToLower().Equals(filter))
                    continue;

                var cardPanel = new CardPanel(card);
                cardPanel.OnSeeMe += CardPanel_OnSeeMe;
                Controls.Add(cardPanel);
                Update();
            }
        }

        private void GenerateObjects()
        {
            if (_cards.Count <= 0)
            {
                var image = new Label()
                {
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = ThemeController.LiteGray,
                    Font = new Font("Arial", 32, FontStyle.Regular),
                    Text = "You don't have any registered cards yet.",
                };
                Controls.Add(image);
                return;
            }

            foreach (var card in _cards)
            {
                var cardPanel = new CardPanel(card);
                cardPanel.OnClickMe += CardPanel_OnClickMe;
                cardPanel.OnSeeMe += CardPanel_OnSeeMe;
                Controls.Add(cardPanel);
                Update();
            }
        }

        #region Card panel
        private void CardPanel_OnSeeMe(Card card) => OnSeeMe?.Invoke(card);

        private void CardPanel_OnClickMe(CardPanel cardPanel)
        {
            foreach (var card in Controls)
                if (card is CardPanel crlPanel)
                    crlPanel.HideOptions();

            cardPanel.HideOptions(false);
        }
        #endregion
    }
}