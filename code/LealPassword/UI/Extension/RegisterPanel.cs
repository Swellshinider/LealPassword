using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed class RegisterPanel : Panel
    {
        internal delegate void ClickedMe(RegisterPanel registerPanel);
        internal event ClickedMe OnClickMe;

        internal delegate void DiscardMe(Register register);
        internal event DiscardMe OnDiscardMe;

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

            var image = (Image)new Bitmap(64, 64);

            try
            {
                image = PRController.dictIdImages[register.ImageKey];
            }
            catch (KeyNotFoundException)
            {
                image = PRController.dictIdImages[""];
            }

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
                Text = register.Name,
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
                Text = register.Tag,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.TopLeft,
                ForeColor = ThemeController.LiteGray,
                Font = new Font("Verdana", 14,  FontStyle.Italic),
            };

            var lblIcon = new Label()
            {
                Text = "",
                Width = 96,
                AutoSize = false,
                Dock = DockStyle.Right,
                ImageAlign = ContentAlignment.MiddleCenter,
                Image = Program.ResizeImage(image, 32, 32),
            };
            lblIcon.Click += RegisterPanel_Click;
            _leftPanel.Controls.Add(lblIcon);

            var lblDiscart = new Button()
            {
                Text = "",
                Width = 50,
                AutoSize = false,
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                Image = PRController.Images.Close16px, // TODO: Adjust remove image
                ImageAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 11, FontStyle.Underline),
            };
            lblDiscart.FlatAppearance.BorderSize = 0;

            var lblSee = new Button
            {
                Width = 50,
                Text = "Ver",
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
                Text = "Editar",
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
            lblSee.Click += (s, e) => OnSeeMe?.Invoke(register);
            lblEdit.Click += (s, e) => OnEditMe?.Invoke(register);
            lblDiscart.Click += (s, e) => OnDiscardMe?.Invoke(register);

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
    }
}