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
        private readonly Label _lblName;
        private readonly Label _lblPassword;
        private readonly Panel _panelCopy;
        private readonly Button _buttonCopy;
        private readonly Panel _panelObserve;
        private readonly Label _buttonObserve;

        private readonly Timer _timerCopy;
        private readonly ToolTip _tooltipControl;

        internal RegisterPanel(Register register)
        {
            _register = register;
            _timerCopy = new Timer()
            {
                Interval = 2000
            };
            _timerCopy.Tick += TimerCopy_Tick;
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

            _panelCopy = new Panel()
            {
                Width = 150,
                Visible = false,
                Dock = DockStyle.Right,
            };
            _buttonCopy = new Button()
            {
                Height = 50,
                Width = 120,
                Cursor = Cursors.Hand,
                Text = "Copy Password",
                FlatStyle = FlatStyle.Flat,
                BackColor = ThemeController.BlueMain,
                ForeColor = ThemeController.IceWhite,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Verdana", 12, FontStyle.Regular),
            };
            _buttonCopy.Click += ButtonCopy_Click;
            _panelCopy.Controls.Add(_buttonCopy);
            Program.CentralizeControl(_buttonCopy, _panelCopy);

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

            _panelObserve.Controls.Add(_buttonObserve);
            Program.CentralizeControl(_buttonObserve, _panelObserve);

            Controls.Add(_lblPassword);
            Controls.Add(_lblName);
            Controls.Add(_leftPanel);
            Controls.Add(_panelCopy);
            Controls.Add(_panelObserve);

            Resize += CardPanel_Resize;
            Click += RegisterPanel_Click;
            _lblName.Click += RegisterPanel_Click;
            _leftPanel.Click += RegisterPanel_Click;
            _lblPassword.Click += RegisterPanel_Click;
            HideOptions();
        }

        internal void HideOptions(bool hide = true)
        {
            _panelObserve.Visible = !hide;
            _panelCopy.Visible = !hide;
            BorderStyle = hide ? BorderStyle.None : BorderStyle.Fixed3D;
        }

        private void RegisterPanel_Click(object sender, EventArgs e) => OnClickMe?.Invoke(this);

        private void ButtonObserve_Click(object sender, EventArgs e) => OnSeeMe?.Invoke(_register);

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_register.Password);
            _buttonCopy.Text = "Copied!";
            _buttonCopy.BackColor = ThemeController.ButtonSelectableColor;
            _timerCopy.Start();
        }

        private void TimerCopy_Tick(object sender, EventArgs e)
        {
            _timerCopy.Stop();
            _buttonCopy.Text = "Copy Password";
            _buttonCopy.BackColor = ThemeController.BlueMain;
        }

        private void ButtonObserve_MouseEnter(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.Eye_50px;

        private void ButtonObserve_MouseLeave(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.ClosedEye_50px;

        private void CardPanel_Resize(object sender, EventArgs e) => Program.CentralizeControl(_buttonObserve, _panelObserve);
    }
}