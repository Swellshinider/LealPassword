namespace LealPassword.Theme
{
    internal static class ThemeController
    {
        private static readonly List<string> BlackTheme = new() { "#020202", "#696d7d", "#e2e2e2", "#ec058e", "#02040f" };
        private static readonly List<string> WhiteTheme = new() { "#020202", "#696d7d", "#e2e2e2", "#ec058e", "#02040f" };
        private static readonly List<string> CustomTheme = new();

        internal static ThemeType Type { get; set; } = ThemeType.BLACK;

        internal static Color BackgroundColor
        {
            get
            {
                return Type switch
                {
                    ThemeType.BLACK => ColorTranslator.FromHtml(BlackTheme[0]),
                    ThemeType.WHITE => ColorTranslator.FromHtml(WhiteTheme[0]),
                    _ => ColorTranslator.FromHtml(CustomTheme[0]),
                };
            }
        }

        internal static Color ForegroundColor
        {
            get
            {
                return Type switch
                {
                    ThemeType.BLACK => ColorTranslator.FromHtml(BlackTheme[1]),
                    ThemeType.WHITE => ColorTranslator.FromHtml(WhiteTheme[1]),
                    _ => ColorTranslator.FromHtml(CustomTheme[1]),
                };
            }
        }

        internal static Color PrimaryColor
        {
            get
            {
                return Type switch
                {
                    ThemeType.BLACK => ColorTranslator.FromHtml(BlackTheme[2]),
                    ThemeType.WHITE => ColorTranslator.FromHtml(WhiteTheme[2]),
                    _ => ColorTranslator.FromHtml(CustomTheme[2]),
                };
            }
        }

        internal static Color SecondaryColor
        {
            get
            {
                return Type switch
                {
                    ThemeType.BLACK => ColorTranslator.FromHtml(BlackTheme[3]),
                    ThemeType.WHITE => ColorTranslator.FromHtml(WhiteTheme[3]),
                    _ => ColorTranslator.FromHtml(CustomTheme[3]),
                };
            }
        }

        internal static Color TertiaryColor
        {
            get
            {
                return Type switch
                {
                    ThemeType.BLACK => ColorTranslator.FromHtml(BlackTheme[4]),
                    ThemeType.WHITE => ColorTranslator.FromHtml(WhiteTheme[4]),
                    _ => ColorTranslator.FromHtml(CustomTheme[4]),
                };
            }
        }
    }
}