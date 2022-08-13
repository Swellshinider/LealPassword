using LealPassword.Database.Controllers;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.LoginCreateSub
{
    internal sealed partial class LoginUI : UserControl
    {
        private readonly DiagnosticList _diagnostic;
        private readonly bool _remember;

        internal delegate void CreatingAccountUI();
        internal event CreatingAccountUI OnCreatingAccount;

        internal delegate void LogginToAccountUI(Account account, string masterpass);
        internal event LogginToAccountUI OnLogginToAccount;

        internal LoginUI(Control parent, DiagnosticList diagnostic)
        {
            InitializeComponent(); 
            parent.Controls.Add(this);
            _diagnostic = diagnostic;
            Dock = DockStyle.Fill;
            BackColor = ThemeController.SuperLiteGray;
            _remember = !string.IsNullOrEmpty(PRController.LastUser) &&
                !string.IsNullOrWhiteSpace(PRController.LastUser);
            textBoxUser.Text = PRController.LastUser;
            GenerateObjects();
        }

        internal void GenerateObjects()
        {
            _diagnostic.Debug("Generating login objects");
            #region Labels
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
            #endregion

            #region TextBoxUser
            textBoxUser.Height = 50;
            textBoxUser.HintText = "Usuário";
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
            textBoxPass.Text = "";
            textBoxPass.Height = 50;
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
            textBoxPass.Region = Program.GenerateRoundRegion(textBoxUser.Width, textBoxUser.Height, 15);
            textBoxPass.KeyDown += TextBoxKeyDown;
            #endregion

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
                Text = "Ainda não tem uma conta? clique aqui!",
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
            SetDynamicHeight(checkBoxRemember, 380);
            checkBoxRemember.Location = new Point(checkBoxRemember.Location.X + 
                (checkBoxRemember.Width / 2) - (textBoxPass.Width / 2), checkBoxRemember.Location.Y);
            SetDynamicHeight(buttonLogin, 425);
            #endregion

            _diagnostic.Debug("login objects generated");
        }

        #region Private methods
        private CheckBox ExtractBox()
        {
            foreach(var ctrl in Controls)
                if (ctrl is CheckBox box) return box;

            return null;
        }

        private bool IsLoginValid(string user, string pass, out Account account)
        {
            account = null;
            pass = "Papibaquigrafo1!"; // HACK: Exclude this

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrEmpty(user) || 
                string.IsNullOrWhiteSpace(pass) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Usuário ou senha inválidos",
                    "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var hashedPass = Security.Security.HashValue(pass);
            var controller = new AccountController(Constants.DEFAULT_DATABASE_PATH, 
                Constants.DEFAULT_DATABASE_FILE, Security.Security.HashValue(hashedPass));
            account = controller.GetAccount(user);

            if (account == null || account.Username == null || account.Password == null)
            {
                MessageBox.Show("Não existe nenhuma conta criada com esses parâmetros",
                    "Conta inexistente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (account.Username != user || account.Password != hashedPass)
            {
                MessageBox.Show("Usuário ou senha inválidos",
                    "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            ButtonLogin_Click(sender, e);
        }

        private void SetDynamicHeight(Control control, int dynamicHeight)
        {
            Program.HorizontalCentralize(control, this);
            control.Location = new Point(control.Location.X, control.Location.Y + dynamicHeight);
        }
        #endregion

        #region Buttons
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            var user = textBoxUser.Text;
            var pass = textBoxPass.Text;

            if (!IsLoginValid(user, pass, out var account)) return;

            CheckBoxShowHidePassword_Click(ExtractBox(), e);
            OnLogginToAccount?.Invoke(account, pass);
        }

        private void CheckBoxShowHidePassword_Click(object sender, EventArgs e)
        {
            var cbox = (CheckBox)sender;
            PRController.LastUser = cbox.Checked ? textBoxUser.Text : "";
        }

        private void LblDoesNotHaveAcc_Click(object sender, EventArgs e)
            => OnCreatingAccount?.Invoke();
        #endregion
    }
}