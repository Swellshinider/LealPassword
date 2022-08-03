using LealPassword.Settings;
using LealPassword.View;
using System.Runtime.InteropServices;

namespace LealPassword
{
    internal static class Program
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect,
            int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [STAThread]
        internal static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new AccountView());
        }

        internal static void ControlMouseDown(IntPtr handle, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            ReleaseCapture();
            _ = SendMessage(handle, DefinitionsConstants.WM_NCLBUTTONDOWN, DefinitionsConstants.HT_CAPTION, 0);
        }

        internal static void CentralizeControl(Control control, Control controlReference)
        {
            var centerPoint = new Point(controlReference.Width / 2, controlReference.Height / 2);
            var xValue = centerPoint.X - (control.Width / 2);
            var yValue = centerPoint.Y - (control.Height / 2);
            control.Location = new Point(xValue, yValue);
        }

        internal static Region GenerateRoundRegion(int width, int height, int curve)
            => Region.FromHrgn(CreateRoundRectRgn(0, 0, width, height, curve, curve));

        internal static void HideConsole() => ShowWindow(GetConsoleWindow(), DefinitionsConstants.SW_HIDE);

        internal static void ShowConsole() => ShowWindow(GetConsoleWindow(), DefinitionsConstants.SW_SHOW);
    }
}