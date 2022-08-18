using LealPassword.Themes;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed class RegisterPanel : Panel
    {
        internal readonly Panel _leftPanel;
        internal readonly Label _lblName;
        internal readonly Label _lblPassword;

        internal RegisterPanel(string name, int passwordLength)
        {
            Height = 100;
            Dock = DockStyle.Top;
            ForeColor = ThemeController.Black;

            _leftPanel = new Panel()
            {
                Width = 75,
                Dock = DockStyle.Left,

            };
            _lblName = new Label()
            {
                Text = name,
                Height = 50,
                AutoSize = false,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.BottomLeft,
                Font = new Font("Verdana", 21, FontStyle.Regular),
            };
            _lblPassword = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.TopLeft,
                Text = GetPasswordValue(passwordLength),
                Font = new Font("Verdana", 18,  FontStyle.Italic),
            };

            Controls.Add(_lblPassword);
            Controls.Add(_lblName);
            Controls.Add(_leftPanel);
        }

        private static string GetPasswordValue(int length)
        {
            var fakePassword = "";

            for (int i = 0; i < length; i++)
                fakePassword += "*";

            return fakePassword;
        }
    }
}