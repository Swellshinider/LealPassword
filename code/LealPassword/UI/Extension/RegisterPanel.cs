﻿using LealPassword.Database.Model;
using LealPassword.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed class RegisterPanel : Panel
    {
        internal delegate void ClickedMe(RegisterPanel registerPanel);
        internal event ClickedMe OnClickMe;

        internal delegate void EditMe(Register register);
        internal event EditMe OnEditMe;

        internal delegate void SeeMe(Register register);
        internal event SeeMe OnSeeMe;

        private readonly Panel _leftPanel;
        private readonly Panel _rightPanel;
        private readonly Label _lblName;
        private readonly Label _lblPassword;

        internal RegisterPanel(Register register)
        {
            Height = 100;
            Dock = DockStyle.Top;
            ForeColor = ThemeController.Black;

            _leftPanel = new Panel()
            {
                Width = 100,
                Dock = DockStyle.Left
            };
            _rightPanel = new Panel()
            {
                Width = 200,
                Dock = DockStyle.Right,
            };
            _lblName = new Label()
            {
                Text = register.Name,
                Height = 50,
                AutoSize = false,
                Dock = DockStyle.Top,
                ForeColor = ThemeController.Black,
                TextAlign = ContentAlignment.BottomLeft,
                Font = new Font("Arial", 18, FontStyle.Regular),
            };
            _lblPassword = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.TopLeft,
                ForeColor = ThemeController.LiteGray,
                Text = GetPasswordValue(register.Password.Length),
                Font = new Font("Verdana", 14,  FontStyle.Italic),
            };

            var lblSee = new Label
            {
                Text = "Ver",
                AutoSize = false,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                Width = _rightPanel.Width / 2,
                ForeColor = ThemeController.LiteGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Underline),
            };
            var lblEdit = new Label
            {
                Text = "Editar",
                AutoSize = false,
                Dock = DockStyle.Left,
                Cursor = Cursors.Hand,
                Width = _rightPanel.Width / 2,
                ForeColor = ThemeController.LiteGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Underline),
            };
            _rightPanel.Controls.Add(lblSee);
            _rightPanel.Controls.Add(lblEdit);
            lblSee.Click += (s, e) => OnSeeMe?.Invoke(register);
            lblEdit.Click += (s, e) => OnEditMe?.Invoke(register);

            Controls.Add(_lblPassword);
            Controls.Add(_lblName);
            Controls.Add(_leftPanel);
            Controls.Add(_rightPanel);

            Click += RegisterPanel_Click;
            _lblName.Click += RegisterPanel_Click;
            _leftPanel.Click += RegisterPanel_Click;
            _rightPanel.Click += RegisterPanel_Click;
            _lblPassword.Click += RegisterPanel_Click;
            HideOptions();
        }

        internal void HideOptions(bool hide = true)
        {
            _rightPanel.Visible = !hide;
            BorderStyle = hide ? BorderStyle.None : BorderStyle.Fixed3D;
        }

        private void RegisterPanel_Click(object sender, EventArgs e)
            => OnClickMe.Invoke(this);

        private static string GetPasswordValue(int length)
        {
            var fakePassword = "";

            for (int i = 0; i < length; i++)
                fakePassword += "*";

            return fakePassword;
        }
    }
}