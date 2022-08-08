﻿using LealPassword.Definitions;
using LealPassword.Themes;
using LealPassword.UI.LoginCreateSub;
using System;
using System.Windows.Forms;

namespace LealPassword.UI
{
    internal sealed class LoginCreateAccountUI : BaseUI
    {
        private Panel panelLeftContainer;
        private Panel panelRightContainer;

        internal LoginCreateAccountUI(string title, Diagnostics.DiagnosticList diagnostic)
            : base(title, diagnostic)
        {
            Width = Constants.LoginCreateAccountSize.Width;
            Height = Constants.LoginCreateAccountSize.Height;
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
                Width = Width - (int)(Width * 0.5f),
                Dock = DockStyle.Left,
                BackColor = ThemeController.BlueMain,
            };
            panelLeftContainer.MouseDown += ControlMouseDown;
            Controls.Add(panelLeftContainer);
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
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = ThemeController.MouseOverCloseButton;
            btnClose.FlatAppearance.MouseDownBackColor = ThemeController.MouseDownCloseButton;
            btnClose.Click += BtnClose_Click;
            panelTopSide.Controls.Add(btnClose);
            btnClose.Region = Program.GenerateRoundRegion(btnClose.Width, btnClose.Height);
            _diagnostic.Debug("Basic layout loaded");

            InitializeLoginUI();
        }

        private void InitializeLoginUI()
        {
            panelRightContainer.Controls.Clear();
            var loginUI = new LoginUI();
            loginUI.OnCreatingAccount += LoginUI_OnCreatingAccount;
            loginUI.MouseDown += ControlMouseDown;
            panelRightContainer.Controls.Add(loginUI);
        }

        private void LoginUI_OnCreatingAccount()
        {
            panelRightContainer.Controls.Clear();
            var createAccountUI = new CreateUI();
            createAccountUI.OnAccountCreated += CreateAccountUI_OnAccountCreated;
            createAccountUI.MouseDown += ControlMouseDown;
            panelRightContainer.Controls.Add(createAccountUI);
        }

        private void CreateAccountUI_OnAccountCreated()
        {
            throw new NotImplementedException();
        }

        private void ControlMouseDown(object sender, MouseEventArgs e)
            => Program.ControlMouseDown(Handle, e);

        private void BtnClose_Click(object sender, EventArgs e)
            => Program.Exit();
    }
}