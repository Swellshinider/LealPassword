using Bunifu.Framework.UI;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LealPassword.UI.LoginCreateSub
{
    internal sealed partial class LoginUI : UserControl
    {
        private readonly DiagnosticList _diagnostic;
        private bool _remember = false;

        internal delegate void CreatingAccountUI();
        internal event CreatingAccountUI OnCreatingAccount;

        internal LoginUI(Control parent, DiagnosticList diagnostic)
        {
            parent.Controls.Add(this);
            _diagnostic = diagnostic;
            Dock = DockStyle.Fill;
            BackColor = ThemeController.SuperLiteGray;
            InitializeComponent();
            GenerateObjects();
        }

        internal void GenerateObjects()
        {
            _diagnostic.Debug("Generating login objects");
            var lblIcon = new Label
            {
                Width = 64,
                Height = 64,
                Text = "",
                AutoSize = false,
                FlatStyle = FlatStyle.Flat,
                BorderStyle = BorderStyle.FixedSingle
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

            textBoxEmail.Text = "";
            textBoxEmail.Height = 50;
            textBoxEmail.HintText = "Email";
            textBoxEmail.Width = (int)(Width * 0.65f);
            textBoxEmail.ForeColor = ThemeController.LiteGray;
            textBoxEmail.BackColor = ThemeController.IceWhite;
            textBoxEmail.HintForeColor = textBoxEmail.ForeColor;
            textBoxEmail.LineIdleColor = textBoxEmail.BackColor;
            textBoxEmail.LineFocusedColor = textBoxEmail.BackColor;
            textBoxEmail.LineMouseHoverColor = textBoxEmail.BackColor;
            textBoxEmail.Font = new Font("Arial", 14, FontStyle.Regular);
            textBoxEmail.Region = Program.GenerateRoundRegion(textBoxEmail.Width, textBoxEmail.Height, 15);

            textBoxPass.Text = "";
            textBoxPass.Height = 50;
            textBoxPass.isPassword = true;
            textBoxPass.HintText = "Senha";
            textBoxPass.Width = (int)(Width * 0.65f);
            textBoxPass.BorderStyle = BorderStyle.None;
            textBoxPass.ForeColor = ThemeController.LiteGray;
            textBoxPass.BackColor = ThemeController.IceWhite;
            textBoxPass.HintForeColor = textBoxPass.ForeColor;
            textBoxPass.LineIdleColor = textBoxPass.BackColor;
            textBoxPass.LineFocusedColor = textBoxPass.BackColor;
            textBoxPass.LineMouseHoverColor = textBoxPass.BackColor;
            textBoxPass.Font = new Font("Arial", 14, FontStyle.Regular);
            textBoxPass.Region = Program.GenerateRoundRegion(textBoxEmail.Width, textBoxEmail.Height, 15);

            var checkBoxRemember = new CheckBox()
            {
                AutoSize = true,
                Checked = _remember,
                Text = "Lembrar login",
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = ThemeController.LiteGray,
                Font = new Font("Times new roman", 11, FontStyle.Italic),
            };
            checkBoxRemember.Click += CheckBoxShowHidePassword_Click;
            Controls.Add(checkBoxRemember);

            var buttonLogin = new Button()
            {
                Height = 50,
                Text = "Entrar",
                FlatStyle = FlatStyle.Flat,
                Width = (int)(Width * 0.65f),
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
                Region = Program.GenerateRoundRegion(textBoxEmail.Width, textBoxEmail.Height, 15),
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
                Text = "Ainda não tem uma conta? clique aqui!",
                Font = new Font("Arial", 11, FontStyle.Italic),
            };
            lblDoesNotHaveAcc.Click += LblDoesNotHaveAcc_Click;
            Controls.Add(lblDoesNotHaveAcc);

            #region Setting location
            SetDynamicHeight(lblIcon, 50);
            SetDynamicHeight(lblTitle, 125);
            SetDynamicHeight(lblNiceMessage, 160);
            SetDynamicHeight(textBoxEmail, 250);
            SetDynamicHeight(textBoxPass, 325);
            SetDynamicHeight(checkBoxRemember, 380);
            checkBoxRemember.Location = new Point(checkBoxRemember.Location.X + 
                (checkBoxRemember.Width / 2) - (textBoxPass.Width / 2), checkBoxRemember.Location.Y);
            SetDynamicHeight(buttonLogin, 425);
            #endregion

            _diagnostic.Debug("login objects generated");
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Button loggin clicked");
        }

        private void CheckBoxShowHidePassword_Click(object sender, EventArgs e)
            => _remember = !_remember;

        private void LblDoesNotHaveAcc_Click(object sender, EventArgs e)
            => OnCreatingAccount?.Invoke();

        private void SetDynamicHeight(Control control, int dynamicHeight)
        {
            Program.HorizontalCentralize(control, this);
            control.Location = new Point(control.Location.X, control.Location.Y + dynamicHeight);
        }
    }
}