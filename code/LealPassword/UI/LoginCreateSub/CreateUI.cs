using LealPassword.Database.Controllers;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LealPassword.UI.LoginCreateSub
{
    internal sealed partial class CreateUI : UserControl
    {
        private readonly DiagnosticList _diagnostic;

        internal delegate void AccountCreated();
        internal event AccountCreated OnAccountCreated;

        public CreateUI(Control parent, DiagnosticList diagnostic)
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
            _diagnostic.Debug("Generating createUI objects");
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
            #endregion

            #region UserTextBox
            textBoxUser.Text = "";
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

            #region PassTextBox
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
            textBoxPass.Region = Program.GenerateRoundRegion(textBoxUser.Width, textBoxUser.Height, 15);
            textBoxPass.KeyDown += TextBoxKeyDown;
            #endregion

            #region PassTextBox2
            textBoxPass2.Text = "";
            textBoxPass2.Height = 50;
            textBoxPass2.isPassword = true;
            textBoxPass2.HintText = "Confirme a senha";
            textBoxPass2.Width = (int)(Width * 0.65f);
            textBoxPass2.BorderStyle = BorderStyle.None;
            textBoxPass2.ForeColor = ThemeController.LiteGray;
            textBoxPass2.BackColor = ThemeController.IceWhite;
            textBoxPass2.HintForeColor = textBoxPass.ForeColor;
            textBoxPass2.LineIdleColor = textBoxPass.BackColor;
            textBoxPass2.LineFocusedColor = textBoxPass.BackColor;
            textBoxPass2.LineMouseHoverColor = textBoxPass.BackColor;
            textBoxPass2.Font = new Font("Arial", 14, FontStyle.Regular);
            textBoxPass2.Region = Program.GenerateRoundRegion(textBoxUser.Width, textBoxUser.Height, 15);
            textBoxPass2.KeyDown += TextBoxKeyDown;
            #endregion

            #region ButtonCreate
            var buttonCreate = new Button()
            {
                Height = 50,
                Text = "Criar",
                FlatStyle = FlatStyle.Flat,
                Width = (int)(Width * 0.65f),
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
                Region = Program.GenerateRoundRegion(textBoxUser.Width, textBoxUser.Height, 15),
            };
            buttonCreate.Click += ButtonCreate_Click;
            buttonCreate.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            buttonCreate.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;
            Controls.Add(buttonCreate);
            #endregion

            #region Copyright
            var lblcopyright = new Label()
            {
                Height = 50,
                AutoSize = false,
                Dock = DockStyle.Bottom,
                ForeColor = ThemeController.LiteGray,
                TextAlign = ContentAlignment.TopCenter,
                Text = "Já tem uma conta? Clique aqui para entrar!",
                Font = new Font("Arial", 11, FontStyle.Italic),
            };
            lblcopyright.Click += (s, e) => OnAccountCreated?.Invoke();
            Controls.Add(lblcopyright);
            #endregion

            #region Setting location
            SetDynamicHeight(lblIcon, 50);
            SetDynamicHeight(lblTitle, 125);
            SetDynamicHeight(textBoxUser, 200);
            SetDynamicHeight(textBoxPass, 260);
            SetDynamicHeight(textBoxPass2, 320);
            SetDynamicHeight(buttonCreate, 395);
            #endregion
            _diagnostic.Debug("createUI objects generated");
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            ButtonCreate_Click(sender, e);
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Você só pode ter uma conta por computador nessa versão, " +
                "ao criar uma nova, todas as outras contas e registros serão excluídas\n\n" +
                "Tem certeza disso?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (!dialog.Equals(DialogResult.Yes)) return;

            var user = textBoxUser.Text;
            var pass = textBoxPass.Text;
            var pass2 = textBoxPass2.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user) || user.Length < 3)
            {
                MessageBox.Show("Nome de usuário deve ter pelo menos 3 caracteres", "Usuário inválido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckIsValidCharacters(user))
            {
                MessageBox.Show($"Nome de usuário não deve conter os seguintes caracteres:\n" +
                    $"{new string(Constants.InvalidChar)}", "Usuário inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass)
                || string.IsNullOrEmpty(pass2) || string.IsNullOrWhiteSpace(pass2))
            {
                MessageBox.Show("Senha deve ter pelo menos 3 caractéres", "Senha inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckIsValidCharacters(pass))
            {
                MessageBox.Show($"Senha não deve conter os seguintes caracteres:\n" +
                    $"{new string(Constants.InvalidChar)}", "Usuário inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != pass2)
            {
                MessageBox.Show("As senhas devem ser iguais", "Senha inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hashedPass = Security.Security.HashValue(pass);
            var accountControler = new AccountController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, Security.Security.HashValue(hashedPass));

            accountControler.ClearAccounts();
            accountControler.InsertAccount(new Account()
            {
                Username = user,
                Password = hashedPass,
                Registers = new List<Register>(),
                Cards = new List<Card>()
            });

            var registerController = new RegisterController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, Security.Security.HashValue(hashedPass));
            registerController.ClearRegisters();

            OnAccountCreated?.Invoke();
        }

        private bool CheckIsValidCharacters(string user)
        {
            foreach(var c in user)
                if (Constants.InvalidChar.Contains(c)) 
                    return false;

            return true;
        }

        private void SetDynamicHeight(Control control, int dynamicHeight)
        {
            Program.HorizontalCentralize(control, this);
            control.Location = new Point(control.Location.X, control.Location.Y + dynamicHeight);
        }
    }
}