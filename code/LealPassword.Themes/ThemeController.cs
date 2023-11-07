using System.Drawing;

namespace LealPassword.Themes
{
    public static class ThemeController
    {
        public static ThemeType Type { get; set; } = ThemeType.WHITE;

        public static Color Black => Color.Black;

        #region Blue variations
        public static Color BlueMain => Color.FromArgb(41, 93, 197);
        public static Color LiteBlue => Color.FromArgb(175, 41, 93, 197);
        public static Color SligBlue => Color.FromArgb(225, 41, 93, 197);
        public static Color LineDarkBlue => Color.FromArgb(89, 130, 209);
        #endregion

        #region White variations
        public static Color White => Color.White;
        //public static Color IceWhite => Color.FromArgb(237, 244, 245);
        public static Color IceWhite => Color.FromArgb(240, 240, 240);
        public static Color LiteGray => Color.FromArgb(182, 182, 184);
        public static Color SuperLiteGray => Color.FromArgb(249, 251, 251);
        public static Color SuperCleanWhite => Color.FromArgb(227, 234, 235);
        #endregion

        #region PasswordStrenght
        public static Color ExcelentPassword => Color.FromArgb(56, 176, 120);
        public static Color GoodPassword => Color.FromArgb(4, 198, 228);
        public static Color FairPassword => Color.FromArgb(252, 160, 44);
        public static Color PoorPassword => Color.FromArgb(249, 97, 90);
        #endregion

        #region Functionable colors
        public static Color MouseOverCloseButton = Color.Red;
        public static Color MouseDownCloseButton = Color.DarkRed;
        public static Color ButtonSelectableColor => Color.FromArgb(31, 70, 148);
        #endregion
    }
}