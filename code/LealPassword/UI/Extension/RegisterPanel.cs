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

        internal delegate void SeeMe(Register register);
        internal event SeeMe OnSeeMe;

        private readonly Register _register;
        private readonly Panel _leftPanel;
        private readonly Panel _rightPanel;
        private readonly Label _lblName;
        private readonly Label _lblPassword;
        private readonly Panel _panelObserve;
        private readonly Label _buttonObserve;

        private readonly ToolTip _tooltipControl;

        internal RegisterPanel(Register register)
        {
            _register = register;
            _tooltipControl = new ToolTip();

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

            _panelObserve = new Panel()
            {
                Width = 96,
                Dock = DockStyle.Right,
                BackColor = Color.Transparent
            };
            _buttonObserve = new Label()
            {
                Text = "",
                Width = 32,
                Height = 32,
                AutoSize = false,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = PRController.Images.ClosedEye_50px,
            };
            _buttonObserve.Click += ButtonObserve_Click;
            _buttonObserve.MouseEnter += ButtonObserve_MouseEnter;
            _buttonObserve.MouseLeave += ButtonObserve_MouseLeave;

            _tooltipControl.SetToolTip(_buttonObserve, "Register details");

            _rightPanel.Controls.Add(_panelObserve);
            _panelObserve.Controls.Add(_buttonObserve);
            Program.CentralizeControl(_buttonObserve, _panelObserve);

            Controls.Add(_lblPassword);
            Controls.Add(_lblName);
            Controls.Add(_leftPanel);
            Controls.Add(_rightPanel);

            Resize += CardPanel_Resize;
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

        private void RegisterPanel_Click(object sender, EventArgs e) => OnClickMe?.Invoke(this);

        private void ButtonObserve_Click(object sender, EventArgs e) => OnSeeMe?.Invoke(_register);

        private void ButtonObserve_MouseEnter(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.Eye_50px;

        private void ButtonObserve_MouseLeave(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.ClosedEye_50px;

        private void CardPanel_Resize(object sender, EventArgs e) => Program.CentralizeControl(_buttonObserve, _panelObserve);
    }
}