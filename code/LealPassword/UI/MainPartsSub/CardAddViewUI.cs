using LealPassword.Database.Model;
using LealPassword.Themes;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.MainPartsSub
{
    internal sealed partial class CardAddViewUI : UserControl
    {
        private readonly List<Card> _cards;

        internal CardAddViewUI(List<Card> registers, Control parent)
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

            foreach (var card in _cards)
            {
                if (!card.CardName.Contains(filter) && !card.CardName.Equals(filter))
                    continue;



                Update();
            }
        }

        internal void GenerateObjects()
        {
            if (_cards.Count <= 0)
            {
                var lblCards = new Label()
                {
                    Height = 100,
                    Dock = DockStyle.Top,
                    ForeColor = ThemeController.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Verdana", 18, FontStyle.Regular),
                    Text = "Você não tem nenhum cartão cadastrado.\n" +
                    "Adicione um novo no botão azul do painel superior.",
                };

                Controls.Add(lblCards);
                return;
            }

            foreach (var reg in _cards)
            {
                

                Update();
            }
        }
    }
}
