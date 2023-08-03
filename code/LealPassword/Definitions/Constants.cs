using System;
using System.Drawing;

namespace LealPassword.Definitions
{
    internal static class Constants
    {
        private static readonly string[] NiceMessages = new string[]
        {
            "It doesn't matter how slowly you go as long as you do not stop.",
            "For every problem, there is a challenge; for every challenge, there is a solution.",
            "Do the best you can, be the best you can be. The result will come in proportion to your effort.",
            "We are what we repeatedly do. Excellence, then, is not an act but a habit.",
            "Stones on the path? Keep them all. One day, you may build a castle.",
            "People often say that motivation doesn't last. Well, neither does the effect of a bath; that's why it is recommended daily.",
            "Motivation is the art of getting people to do what you want them to do because they want to do it.",
            "Fight. Believe. Conquer. Lose. Desire. Wait. Achieve. Fall. Be everything, but above all, always be yourself.",
            "Failure is just an opportunity to start again with more intelligence.",
            "Only through being true to ourselves can we achieve great success."
        };
        
        internal static readonly char[] InvalidChar = new char[]
        {
            '{', '}', '[', ']', '(', ')', '%', '/', '\\', '<', '>'
        };
        internal static string DEFAULT_DATABASE_PATH => $"{Environment.GetLogicalDrives()[0]}Users\\Public\\LealPassword";
        internal static string DEFAULT_DATABASE_FILE => $"LealPassword.sqlite3";

        internal static readonly bool DEBUG = true;

        internal static readonly int SW_HIDE = 0;
        internal static readonly int SW_SHOW = 5;
        internal static readonly int WM_NCLBUTTONDOWN = 0xA1;
        internal static readonly int HT_CAPTION = 0x2;
        internal static readonly int ELIPSE_CURVE = 25;
        internal static readonly int SIZE_GRIP = 16; 
        
        internal static readonly Size BaseUISize = new Size(1280, 780);

        internal static string RandomNiceMessage
            => NiceMessages[new Random().Next(0, NiceMessages.Length - 1)];
    }
}