using LealPassword.Definitions;
using LealPassword.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.MainPartsSub
{
    internal sealed partial class ChooseRegistersCardsUI : UserControl
    {
        internal delegate void ChooseRegister();
        internal event ChooseRegister OnChooseRegister;

        internal delegate void ChooseCards();
        internal event ChooseCards OnChooseCards;

        internal ChooseRegistersCardsUI(Control parent)
        {
            Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            var panelLeft = new Panel()
            {
                Width = Width / 2,
                Dock = DockStyle.Left,
            };
            Controls.Add(panelLeft);

            var panelRight = new Panel()
            {
                Width = Width / 2,
                Dock = DockStyle.Right,
            };
            Controls.Add(panelRight);

            var labelCard = new Button()
            {
                Width = 350,
                Height = 350,
                Text = "Novo cartão",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.Black,
                TextAlign = ContentAlignment.BottomCenter,
                ImageAlign = ContentAlignment.MiddleCenter,
                Image = PRController.Images.CardsBlack256px,
                Font = new Font("Consolas", 21, FontStyle.Regular),
            };
            labelCard.FlatAppearance.BorderSize = 0;
            labelCard.FlatAppearance.MouseDownBackColor = ThemeController.BlueMain;
            labelCard.Region = Program.GenerateRoundRegion(labelCard.Width, labelCard.Height);
            panelRight.Controls.Add(labelCard);

            var labelRegister = new Button()
            {
                Width = 350,
                Height = 350,
                Cursor = Cursors.Hand,
                Text = "Novo registro",
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.Black,
                TextAlign = ContentAlignment.BottomCenter,
                ImageAlign = ContentAlignment.MiddleCenter,
                Image = PRController.Images.RegisterBlack256px,
                Font = new Font("Consolas", 21, FontStyle.Regular),
            };
            labelRegister.FlatAppearance.BorderSize = 0;
            labelRegister.FlatAppearance.MouseDownBackColor = ThemeController.BlueMain;
            labelRegister.Region = Program.GenerateRoundRegion(labelRegister.Width, labelRegister.Height);
            panelLeft.Controls.Add(labelRegister);

            Program.CentralizeControl(labelCard, panelLeft);
            labelCard.Location = new Point(labelCard.Location.X, labelCard.Location.Y - 30);
            Program.CentralizeControl(labelRegister, panelRight);
            labelRegister.Location = new Point(labelRegister.Location.X, labelRegister.Location.Y - 30);

            labelCard.Click += LabelCard_Click;
            labelRegister.Click += LabelRegister_Click;
        }

        private void LabelRegister_Click(object sender, EventArgs e)
            => OnChooseRegister?.Invoke();

        private void LabelCard_Click(object sender, EventArgs e)
            => OnChooseCards?.Invoke();
    }
}