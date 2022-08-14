using System.Drawing;

namespace LealPassword.Definitions
{
    internal static class PRController
    {
        internal static class Images
        {
            internal static Image Close16px => Properties.Resources.close_16px;
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