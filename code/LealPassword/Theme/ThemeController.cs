using System.Drawing;

namespace LealPassword.Theme
{
    internal static class ThemeController
    {
        internal static ThemeType Type { get; set; } = ThemeType.WHITE;

        internal static Color BlueMain => Color.FromArgb(41, 93, 197);
        internal static Color IceWhite => Color.FromArgb(237, 244, 245);
        internal static Color LiteGray => Color.FromArgb(182, 182, 184);
        internal static Color SuperLiteGray => Color.FromArgb(249, 251, 251);

        internal static Color White => Color.White;
        internal static Color Black => Color.Black;
        internal static Color MouseOverCloseButton = Color.Red;
        internal static Color MouseDownCloseButton = Color.DarkRed;
    }
}