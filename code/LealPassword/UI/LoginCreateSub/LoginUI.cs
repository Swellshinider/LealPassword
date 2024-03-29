﻿using LealPassword.Database.Controllers;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace LealPassword.UI.LoginCreateSub
{
    internal sealed partial class LoginUI : UserControl
    {
        private readonly DiagnosticList _diagnostic;

        internal delegate void CreatingAccountUI();
        internal event CreatingAccountUI OnCreatingAccount;

        internal delegate void LogginToAccountUI(Account account, string masterpass);
        internal event LogginToAccountUI OnLogginToAccount;

        internal CheckBox _checkBoxShowHidePassword;

        internal LoginUI(Control parent, DiagnosticList diagnostic)
        {
            InitializeComponent(); 
            parent.Controls.Add(this);
            _diagnostic = diagnostic;
            Dock = DockStyle.Fill;
            BackColor = ThemeController.SuperLiteGray;
            GenerateObjects();
        }

        internal void GenerateObjects()
        {
            _diagnostic.Debug("Generating LoginUI objects");

            #region Labels
            var lblIcon = new Panel
            {
                Width = 64,
                Height = 64,
                AutoSize = false,
                BorderStyle = BorderStyle.None,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = PRController.Images.LealPasswordLogo500px
            };
            Controls.Add(lblIcon);
            var lblTitle = new Label()
            {
                AutoSize = true,
                Text = "LealPassword",
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.Black,
                Font = new Font("Times new roman", 22, FontStyle.Bold),
            };
            Controls.Add(lblTitle);
            var lblNiceMessage = new Label()
            {
                Height = 75,
                AutoSize = false,
                Width = (int)(Width * 0.7f),
                FlatStyle = FlatStyle.Flat,
                Text = Constants.RandomNiceMessage,
                ForeColor = ThemeController.LiteGray,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Consolas", 12, FontStyle.Italic),
            };
            Controls.Add(lblNiceMessage);
            #endregion

            #region TextBoxUser
            textBoxUser.Text = PRController.LastUser;
            textBoxUser.Height = 50;
            textBoxUser.HintText = "Username";
            textBoxUser.Width = (int)(Width * 0.65f);
            textBoxUser.ForeColor = ThemeController.LiteGray;
            textBoxUser.BackColor = ThemeController.IceWhite;
            textBoxUser.HintForeColor = textBoxUser.ForeColor;
            textBoxUser.LineIdleColor = textBoxUser.BackColor;
            textBoxUser.LineFocusedColor = textBoxUser.BackColor;
            textBoxUser.LineMouseHoverColor = textBoxUser.BackColor;
            textBoxUser.Font = new Font("Arial", 14, FontStyle.Regular);
            textBoxUser.Region = Program.GenerateRoundRegion(textBoxUser.Width, textBoxUser.Height, 15);
            textBoxUser.KeyDown += TextBoxKeyDown;
            #endregion

            #region TextBoxPass
            textBoxPass.Text = PRController.LastPassword;
            textBoxPass.Height = 50;
            textBoxPass.HintText = "Password";
            textBoxPass.Width = (int)(Width * 0.65f);
            textBoxPass.BorderStyle = BorderStyle.None;
            textBoxPass.ForeColor = ThemeController.LiteGray;
            textBoxPass.BackColor = ThemeController.IceWhite;
            textBoxPass.HintForeColor = textBoxPass.ForeColor;
            textBoxPass.LineIdleColor = textBoxPass.BackColor;
            textBoxPass.LineFocusedColor = textBoxPass.BackColor;
            textBoxPass.LineMouseHoverColor = textBoxPass.BackColor;
            textBoxPass.Font = new Font("Arial", 14, FontStyle.Regular);
            textBoxPass.Region = Program.GenerateRoundRegion(textBoxUser.Width, textBoxUser.Height, 15);
            textBoxPass.KeyDown += TextBoxKeyDown;
            #endregion

            _checkBoxShowHidePassword = new CheckBox()
            {
                AutoSize = true,
                Checked = true,
                Text = "Show Password",
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = ThemeController.LiteGray,
                Font = new Font("Times new roman", 11, FontStyle.Italic),
            };
            _checkBoxShowHidePassword.Click += CheckBoxShowHidePassword_Click;
            Controls.Add(_checkBoxShowHidePassword);

            var buttonLogin = new Button()
            {
                Height = 50,
                Text = "Login",
                FlatStyle = FlatStyle.Flat,
                Width = (int)(Width * 0.65f),
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
                Region = Program.GenerateRoundRegion(textBoxUser.Width, textBoxUser.Height, 15),
            };
            buttonLogin.Click += ButtonLogin_Click;
            buttonLogin.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            buttonLogin.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;
            Controls.Add(buttonLogin);

            var lblDoesNotHaveAcc = new Label()
            {
                Height = 50,
                AutoSize = false,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Bottom,
                ForeColor = ThemeController.LiteGray,
                TextAlign = ContentAlignment.TopCenter,
                Text = "Does not have an account? click here!",
                Font = new Font("Arial", 11, FontStyle.Italic),
            };
            lblDoesNotHaveAcc.Click += LblDoesNotHaveAcc_Click;
            Controls.Add(lblDoesNotHaveAcc);

            #region Setting location
            SetDynamicHeight(lblIcon, 50);
            SetDynamicHeight(lblTitle, 125);
            SetDynamicHeight(lblNiceMessage, 160);
            SetDynamicHeight(textBoxUser, 250);
            SetDynamicHeight(textBoxPass, 325);
            SetDynamicHeight(_checkBoxShowHidePassword, 380);
            _checkBoxShowHidePassword.Location = new Point(_checkBoxShowHidePassword.Location.X + (_checkBoxShowHidePassword.Width / 2) - (textBoxPass.Width / 2), _checkBoxShowHidePassword.Location.Y);
            SetDynamicHeight(buttonLogin, 425);
            #endregion

            _diagnostic.Debug("LoginUI objects generated");
        }

        #region Private methods
        private bool IsLoginValid(string user, string pass, out Account account)
        {
            account = null;

            if (user.IsNullString() || pass.IsNullString())
            {
                MessageBox.Show("Username or password are invalid", "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                var controller = new AccountController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, pass);
                account = controller.GetAccount(user);
            }
            catch (CryptographicException)
            {
                account = new Account()
                {
                    Username = "",
                    Password = ""
                };
            }

            if (account == null || account.Username == null || account.Password == null)
            {
                MessageBox.Show("There is no account created with these parameters.",
                    "Account does not exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (account.Username != user || account.Password != pass)
            {
                MessageBox.Show("Username or password are invalid.",
                    "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonLogin_Click(sender, e);
                return;
            }
        }

        private void SetDynamicHeight(Control control, int dynamicHeight)
        {
            Program.HorizontalCentralize(control, this);
            control.Location = new Point(control.Location.X, control.Location.Y + dynamicHeight);
        }
        #endregion

        #region Buttons
        internal void ButtonLogin_Click(object sender, EventArgs e)
        {
            var user = textBoxUser.Text;
            var pass = textBoxPass.Text;

            if (!IsLoginValid(user, pass, out var account)) return;

            PRController.LastUser = PRController.AutoCompleteUser ? user : "";
            PRController.LastPassword = PRController.AutoCompletePassword ? pass : "";
            OnLogginToAccount?.Invoke(account, pass);
        }

        private void LblDoesNotHaveAcc_Click(object sender, EventArgs e) => OnCreatingAccount?.Invoke();

        private void CheckBoxShowHidePassword_Click(object sender, EventArgs e) => textBoxPass.isPassword = !_checkBoxShowHidePassword.Checked;
        #endregion
    }
}