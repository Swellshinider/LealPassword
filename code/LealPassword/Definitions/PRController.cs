using System.Drawing;

namespace LealPassword.Definitions
{
    internal static class PRController
    {
        internal static class Images
        {
            internal static Image Close16px => Properties.Resources.close_16px;
            internal static Image General127px => Properties.Resources.four_squares_127px;
            internal static Image Config127px => Properties.Resources.gear_127px;
            internal static Image Config127px_Black => Properties.Resources.gear_black_127px;
        }

        internal static string LastUser 
        { 
            get
            {
                return Properties.Settings.Default.LastUser;
            }
            
            set
            {
                Properties.Settings.Default.LastUser = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}