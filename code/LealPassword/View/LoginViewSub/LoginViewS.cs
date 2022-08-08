using LealPassword.Settings;
using LealPassword.Theme;
using System.Drawing;
using System.Windows.Forms;
using Windows.Forms;

namespace LealPassword.View.LoginViewSub
{
    internal sealed partial class LoginViewS : UserControl
    {
        internal delegate void OpenningCreateAcc();
        internal event OpenningCreateAcc? OnOpenningCreateAcc;

        internal LoginViewS(Panel panelContainer)
        {
            panelContainer.Controls.Add(this);
            Dock = DockStyle.Fill;
            BackColor = ThemeController.SuperLiteGray;
            InitializeComponent();
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            var lblIcon = new Label
            {
                AutoSize = false,
                Width = 64,
                Height = 64,
                BorderStyle = BorderStyle.FixedSingle,
                Text = "",
                FlatStyle = FlatStyle.Flat
            };
            Controls.Add(lblIcon);
            var lblWelcome = new Label()
            {
                AutoSize = true,
                Font = new Font("Times new roman", 22, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.Black,
                Text = "LealPassword",
            };
            Controls.Add(lblWelcome);
            var lblNiceMessage = new Label()
            {
                AutoSize = false,
                Width = (int)(Width * 0.7f),
                Height = 75,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Consolas", 12, FontStyle.Italic),
                Text = DefinitionsConstants.RandomNiceMessage,
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.LiteGray,
            };
            Controls.Add(lblNiceMessage);
            var txtBoxEmail = new HintTextBox()
            {
                HintValue = "seu.email@email.com",
                BorderStyle = BorderStyle.None,
                Width = (int)(Width * 0.65f),
                Height = 40,
                Multiline = true,
                Font = new Font("Verdana", 18, FontStyle.Regular),
                ForeColor = ThemeController.BlueMain,
                BackColor = ThemeController.IceWhite,
            };
            txtBoxEmail.Region = Program.GenerateRoundRegion(txtBoxEmail.Width, txtBoxEmail.Height, 5);
            Controls.Add(txtBoxEmail);
            var txtBoxPass = new HintTextBox()
            {
                HintValue = "senhamestra123",
                PasswordChar = '*',
                BorderStyle = BorderStyle.None,
                Width = (int)(Width * 0.65f),
                Height = 40,
                Multiline = true,
                Font = new Font("Verdana", 18, FontStyle.Regular),
                ForeColor = ThemeController.BlueMain,
                BackColor = ThemeController.IceWhite,
            };
            txtBoxPass.Region = Program.GenerateRoundRegion(txtBoxPass.Width, txtBoxPass.Height, 5);
            Controls.Add(txtBoxPass);

            var lblDoesNotHaveAcc = new Label()
            {
                Text = "Ainda não tem uma conta? clique aqui!",
                Font = new Font("Arial", 11, FontStyle.Italic),
                ForeColor = ThemeController.LiteGray,
                AutoSize = false,
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Bottom,
                Height = 50,
                Cursor = Cursors.Hand,
            };
            lblDoesNotHaveAcc.Click += LblDoesNotHaveAcc_Click;
            Controls.Add(lblDoesNotHaveAcc);

            #region Location definition
            Program.HorizontalCentralize(lblIcon, this);
            lblIcon.Location = new Point(lblIcon.Location.X, lblIcon.Location.Y + 75);
            Program.HorizontalCentralize(lblWelcome, this);
            lblWelcome.Location = new Point(lblWelcome.Location.X, lblWelcome.Location.Y + 175);
            Program.HorizontalCentralize(lblNiceMessage, this);
            lblNiceMessage.Location = new Point(lblNiceMessage.Location.X, lblNiceMessage.Location.Y + 210);
            Program.HorizontalCentralize(txtBoxEmail, this);
            txtBoxEmail.Location = new Point(txtBoxEmail.Location.X, txtBoxEmail.Location.Y + 300);
            Program.HorizontalCentralize(txtBoxPass, this);
            txtBoxPass.Location = new Point(txtBoxPass.Location.X, txtBoxPass.Location.Y + 400);
            #endregion
        }

        private void LblDoesNotHaveAcc_Click(object? sender, System.EventArgs e)
            => OnOpenningCreateAcc!.Invoke();
    }
}
