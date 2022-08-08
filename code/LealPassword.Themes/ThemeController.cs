using System.Drawing;

namespace LealPassword.Themes
{
    public static class ThemeController
    {
        public static ThemeType Type { get; set; } = ThemeType.WHITE;

        public static Color BlueMain => Color.FromArgb(41, 93, 197);
        public static Color IceWhite => Color.FromArgb(237, 244, 245);
        public static Color LiteGray => Color.FromArgb(182, 182, 184);
        public static Color SuperLiteGray => Color.FromArgb(249, 251, 251);

        public static Color White => Color.White;
        public static Color Black => Color.Black;
        public static Color MouseOverCloseButton = Color.Red;
        public static Color MouseDownCloseButton = Color.DarkRed;
    }
}