using Bunifu.Framework.UI;
using LealPassword.Themes;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed class SidePanel : BunifuFlatButton
    {
        private const string _spaces = "                    ";

        internal SidePanel(string title, Image image = null)
        {
            IconMarginLeft = 25;
            Dock = DockStyle.Top; 
            Text = $"{_spaces}{title}";
            BackColor = Color.Transparent;
            Normalcolor = Color.Transparent;
            ButtonText = $"{_spaces}{title}";
            OnHovercolor = ThemeController.SligBlue;
            TextAlign = ContentAlignment.MiddleLeft;
            ForeColor = ThemeController.SuperLiteGray;
            Textcolor = ThemeController.SuperLiteGray;
            OnHoverTextColor = ThemeController.SuperLiteGray;
            Activecolor = ThemeController.ButtonSelectableColor;
            TextFont = new Font("Arial", 11, FontStyle.Regular);

            if (image != null) Iconimage = image;
        }
    }
}