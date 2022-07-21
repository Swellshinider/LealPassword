using LealPassword.View;

namespace LealPassword
{
    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoadingView());
        }
    }
}