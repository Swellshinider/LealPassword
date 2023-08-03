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

            #region PassTextBox
            textBoxPass.Text = "";
            textBoxPass.Height = 50;
            textBoxPass.isPassword = true;
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

            #region PassTextBox2
            textBoxPass2.Text = "";
            textBoxPass2.Height = 50;
            textBoxPass2.isPassword = true;
            textBoxPass2.HintText = "Confirm password";
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
                Text = "Create account",
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
                Text = "Do you already have an account? Click here to sign in!",
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
            var dialog = MessageBox.Show("You can only have one account per computer in this version. " +
                "Creating a new account will delete all other accounts and registers.\n\n" +
                "Are you sure about this?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (!dialog.Equals(DialogResult.Yes)) return;

            var user = textBoxUser.Text;
            var pass = textBoxPass.Text;
            var pass2 = textBoxPass2.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user) || user.Length < 3)
            {
                MessageBox.Show("Username must have at least 3 characters", "Invalid Username", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckIsValidCharacters(user))
            {
                MessageBox.Show($"Username cannot handle with theses characters:\n" +
                    $"{new string(Constants.InvalidChar)}", "Invalid Username",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass)
                || string.IsNullOrEmpty(pass2) || string.IsNullOrWhiteSpace(pass2))
            {
                MessageBox.Show("Password must have at least 3 characters", "Invalid Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckIsValidCharacters(pass))
            {
                MessageBox.Show($"Password cannot handle with these characters:\n" +
                    $"{new string(Constants.InvalidChar)}", "Invalid Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != pass2)
            {
                MessageBox.Show("Passwords must be equal", "Invalid Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var accountControler = new AccountController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, pass);

            accountControler.ClearAccounts();
            accountControler.InsertAccount(new Account()
            {
                Username = user,
                Password = pass,
                Registers = new List<Register>(),
                Cards = new List<Card>()
            });

            var registerController = new RegisterController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, pass);
            registerController.ClearRegisters();

            OnAccountCreated?.Invoke();
        }

        private bool CheckIsValidCharacters(string user) => !Constants.InvalidChar.Any(c => user.Contains(c));

        private void SetDynamicHeight(Control control, int dynamicHeight)
        {
            Program.HorizontalCentralize(control, this);
            control.Location = new Point(control.Location.X, control.Location.Y + dynamicHeight);
        }
    }
}