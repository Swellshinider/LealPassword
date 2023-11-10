using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Themes;
using LealPassword.UI.LoginCreateSub;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI
{
    internal sealed class LoginCreateAccountUI : BaseUI
    {
        private readonly Timer _bannerTimer;
        private readonly Timer _loginTimer;
        private int _currentIndex = 0;

        private Panel panelLeftContainer;
        private Panel panelRightContainer;

        internal LoginCreateAccountUI(Diagnostics.DiagnosticList diagnostic)
            : base(diagnostic)
        {
            Text = "LealPassword";
            Width = Constants.BaseUISize.Width;
            Height = Constants.BaseUISize.Height;
            _bannerTimer = new Timer() 
            { 
                Interval = 6000
            };
            _bannerTimer.Tick += BannerTimer_Tick;
            _loginTimer = new Timer()
            {
                Interval = 1500,
            };
            _loginTimer.Tick += LoginTimer_Tick;
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            _diagnostic.Debug("Loading basic layout");
            var panelTopSide = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 32,
                BackColor = ThemeController.SuperLiteGray
            };
            panelTopSide.MouseDown += ControlMouseDown;
            Controls.Add(panelTopSide);
            panelLeftContainer = new Panel()
            {
                Dock = DockStyle.Left,
                Width = Width - (int)(Width * 0.5f),
                BackColor = ThemeController.BlueMain,
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = PRController.BannerImages[_currentIndex]
            };
            panelLeftContainer.MouseDown += ControlMouseDown;
            Controls.Add(panelLeftContainer);
            _bannerTimer.Start();

            panelRightContainer = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = ThemeController.SuperLiteGray,
            };
            panelRightContainer.MouseDown += ControlMouseDown;
            Controls.Add(panelRightContainer);
            var btnClose = new Button()
            {
                Text = "",
                Width = 32,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                Image = PRController.Images.Close16px,
                ImageAlign = ContentAlignment.MiddleCenter,
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = ThemeController.MouseOverCloseButton;
            btnClose.FlatAppearance.MouseDownBackColor = ThemeController.MouseDownCloseButton;
            btnClose.Click += BtnClose_Click;
            panelTopSide.Controls.Add(btnClose);
            panelRightContainer.BringToFront();
            _diagnostic.Debug("Basic layout loaded");
            InitializeLoginUI();
        }

        private void InitializeLoginUI()
        {
            panelRightContainer.Controls.Clear();
            var loginUI = new LoginUI(panelRightContainer, _diagnostic);
            loginUI.OnLogginToAccount += LoginUI_OnLogginToAccount;
            loginUI.OnCreatingAccount += LoginUI_OnCreatingAccount;
            loginUI.MouseDown += ControlMouseDown;
            _diagnostic.Debug("Login UI loaded");

            if (PRController.AutoLogin)
            {
                loginUI.Enabled = false;
                panelRightContainer.Enabled = false;
                _loginTimer.Start();
            }
        }

        private void LoginUI_OnLogginToAccount(Account account, string masterpass)
        {
            var mainUI = new MainUI(_diagnostic, account);
            _diagnostic.Debug("mainUI loaded!");
            Program.Switch(this, mainUI);
            _diagnostic.Debug("mainUI showup");
        }

        private void LoginUI_OnCreatingAccount()
        {
            panelRightContainer.Controls.Clear();
            var createAccountUI = new CreateUI(panelRightContainer, _diagnostic);
            createAccountUI.OnAccountCreated += CreateAccountUI_OnAccountCreated;
            createAccountUI.MouseDown += ControlMouseDown;
            panelRightContainer.Controls.Add(createAccountUI);
        }

        private void CreateAccountUI_OnAccountCreated() => InitializeLoginUI();

        private void BannerTimer_Tick(object sender, EventArgs e)
        {
            var sum = _currentIndex + 1;
            _currentIndex = sum >= PRController.BannerImages.Length ? 0 : sum;
            panelLeftContainer.BackgroundImage = PRController.BannerImages[_currentIndex];
        }

        private void LoginTimer_Tick(object sender, EventArgs e)
        {
            if (panelRightContainer.Controls.Count <= 0)
                return;

            if (panelRightContainer.Controls[0] is LoginUI loginUI)
                loginUI.ButtonLogin_Click(null, null);

            _loginTimer.Stop();
        }

        private void ControlMouseDown(object sender, MouseEventArgs e) => Program.ControlMouseDown(Handle, e);

        private void BtnClose_Click(object sender, EventArgs e) => Program.Exit();
    }
}