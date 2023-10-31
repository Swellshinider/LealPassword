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
        internal delegate void DiscardMe(Card card);
        internal event DiscardMe OnDiscardMe;

        internal delegate void EditMe(Card card);
        internal event EditMe OnEditMe;

        internal delegate void SeeMe(Card card);
        internal event SeeMe OnSeeMe;

        private readonly List<Card> _cards;
        private readonly Control _parent;

        internal CardViewUI(List<Card> registers, Control parent)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _cards = registers;
            _parent = parent;
            _parent.Controls.Clear();
            _parent.Controls.Add(this);
            BackColor = Color.Transparent;
            GenerateObjects();
        }

        internal void Filter(string filter)
        {
            Controls.Clear();
            filter = filter.ToLower();

            if (filter == "" || filter == null)
            {
                GenerateObjects();
                return;
            }

            foreach (var card in _cards)
            {
                if (!card.CardName.ToLower().Contains(filter) &&
                    !card.CardName.ToLower().Equals(filter))
                    continue;

                var cardPanel = new CardPanel(card);
                cardPanel.OnClickMe += CardPanel_OnClickMe;
                cardPanel.OnSeeMe += CardPanel_OnSeeMe;
                cardPanel.OnEditMe += CardPanel_OnEditMe;
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
                    Text = "You don't have any card registered.\nAdd a new one on the blue button in the top panel.",
                };
                Controls.Add(image);
                return;
            }

            foreach (var card in _cards)
            {
                var cardPanel = new CardPanel(card);
                cardPanel.OnClickMe += CardPanel_OnClickMe;
                cardPanel.OnSeeMe += CardPanel_OnSeeMe;
                cardPanel.OnEditMe += CardPanel_OnEditMe;
                cardPanel.OnDiscardMe += CardPanel_OnDiscardMe;
                Controls.Add(cardPanel);
                Update();
            }
        }

        #region Card panel
        private void CardPanel_OnEditMe(Card card)
            => OnEditMe?.Invoke(card);

        private void CardPanel_OnSeeMe(Card card)
            => OnSeeMe?.Invoke(card);

        private void CardPanel_OnDiscardMe(Card card)
            => OnDiscardMe?.Invoke(card);

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