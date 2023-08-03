﻿using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed class CardPanel : Panel
    {
        internal delegate void ClickedMe(CardPanel cardPanel);
        internal event ClickedMe OnClickMe;

        internal delegate void DiscardMe(Card card);
        internal event DiscardMe OnDiscardMe;

        internal delegate void EditMe(Card card);
        internal event EditMe OnEditMe;

        internal delegate void SeeMe(Card card);
        internal event SeeMe OnSeeMe;

        private readonly Panel _leftPanel;
        private readonly Panel _rightPanel;
        private readonly Label _lblName;
        private readonly Label _lblPassword;

        internal CardPanel(Card card)
        {
            Height = 100;
            Dock = DockStyle.Top;
            ForeColor = ThemeController.Black;
            BorderStyle = BorderStyle.FixedSingle;

            _leftPanel = new Panel()
            {
                Width = 125,
                Dock = DockStyle.Left
            };
            _rightPanel = new Panel()
            {
                Width = 250,
                Dock = DockStyle.Right,
            };
            _lblName = new Label()
            {
                Text = card.CardName,
                Height = 50,
                AutoSize = false,
                Dock = DockStyle.Top,
                ForeColor = ThemeController.Black,
                TextAlign = ContentAlignment.BottomLeft,
                Font = new Font("Arial", 16, FontStyle.Bold),
            };
            _lblPassword = new Label()
            {
                AutoSize = false,
                Text = FormatValue(card.Number, card.DueDate),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.TopLeft,
                ForeColor = ThemeController.LiteGray,
                Font = new Font("Verdana", 14, FontStyle.Italic),
            };

            var lblIcon = new Label()
            {
                Text = "",
                Width = 96,
                AutoSize = false,
                Dock = DockStyle.Right,
                ImageAlign = ContentAlignment.MiddleCenter,
                Image = Program.ResizeImage(PRController.dictIdImages["cartao_de_credito"], 32, 32),
            };
            lblIcon.Click += CardPanel_Click;
            _leftPanel.Controls.Add(lblIcon);

            var lblDiscart = new Button()
            {
                Text = "",
                Width = 50,
                AutoSize = false,
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Image = PRController.Images.Close16px,  // TODO: Adjust remove image
                ImageAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Underline),
            };
            lblDiscart.FlatAppearance.BorderSize = 0;

            var lblSee = new Button
            {
                Width = 50,
                Text = "See",
                AutoSize = false,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.LiteGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Underline),
            };
            lblSee.FlatAppearance.BorderSize = 0;

            var lblEdit = new Button
            {
                Width = 75,
                Text = "Edit",
                AutoSize = false,
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.LiteGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Underline),
            };
            lblEdit.FlatAppearance.BorderSize = 0;

            _rightPanel.Controls.Add(lblSee);
            _rightPanel.Controls.Add(lblEdit);
            _rightPanel.Controls.Add(lblDiscart);
            lblSee.Click += (s, e) => OnSeeMe?.Invoke(card);
            lblEdit.Click += (s, e) => OnEditMe?.Invoke(card);
            lblDiscart.Click += (s, e) => OnDiscardMe?.Invoke(card);

            Controls.Add(_lblPassword);
            Controls.Add(_lblName);
            Controls.Add(_leftPanel);
            Controls.Add(_rightPanel);

            Click += CardPanel_Click;
            _lblName.Click += CardPanel_Click;
            _leftPanel.Click += CardPanel_Click;
            _rightPanel.Click += CardPanel_Click;
            _lblPassword.Click += CardPanel_Click; 
            HideOptions();
        }

        internal void HideOptions(bool hide = true)
        {
            _rightPanel.Visible = !hide;
            BorderStyle = hide ? BorderStyle.None : BorderStyle.Fixed3D;
        }

        private void CardPanel_Click(object sender, EventArgs e)
            => OnClickMe.Invoke(this);

        private static string FormatValue(string number, DateTime dueDate)
        {
            var lastFor = number.Substring(12, 4);
            var date = $"{dueDate.Month}/{dueDate.Year - 2000}";

            return $"Final: {lastFor}                        {date}";
        }
    }
}