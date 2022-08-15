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
            if (image != null) Iconimage = image;

            IconZoom = 64;
            IconMarginLeft = 32;
            Dock = DockStyle.Top; 
            Text = $"{_spaces}{title}";
            BackColor = Color.Transparent;
            Normalcolor = Color.Transparent;
            ButtonText = $"{_spaces}{title}";
            TextAlign = ContentAlignment.MiddleLeft;
            OnHovercolor = ThemeController.SligBlue;
            ForeColor = ThemeController.SuperLiteGray;
            Textcolor = ThemeController.SuperLiteGray;
            OnHoverTextColor = ThemeController.SuperLiteGray;
            Activecolor = ThemeController.ButtonSelectableColor;
            TextFont = new Font("Arial", 12, FontStyle.Regular);
        }
    }
}