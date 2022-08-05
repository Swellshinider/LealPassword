using LealPassword.DataBase.AutoMapper;
using LealPassword.Diagnostics;
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

        internal static readonly DiagnosticList _diagnosticsList = DiagnosticList.Instance;

        [STAThread]
        internal static void Main(string[] argv)
        {
            _diagnosticsList.DiagnosticGenerated += DiagnosticsList_DiagnosticGenerated;
            HideConsole();
            if ((argv.Length >= 1 && argv[0].ToLower() == "-adm") || DefinitionsConstants.DEBUG == true)
            {
                ShowConsole();
                _diagnosticsList.Debug("ADM mode activate");
            }
            AutoMapperConfig.RegisterMappings();
            ApplicationConfiguration.Initialize();
            _diagnosticsList.Debug("App configuration started");
            Application.Run(new LoginView(_diagnosticsList));
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
            _diagnosticsList.Debug($"Control: {control.Name} centralized");
        }

        internal static Region GenerateRoundRegion(int width, int height, int curve)
            => Region.FromHrgn(CreateRoundRectRgn(0, 0, width, height, curve, curve));

        internal static void HideConsole() => ShowWindow(GetConsoleWindow(), DefinitionsConstants.SW_HIDE);

        internal static void ShowConsole() => ShowWindow(GetConsoleWindow(), DefinitionsConstants.SW_SHOW);

        private static void DiagnosticsList_DiagnosticGenerated(Diagnostic diagnostic)
        {
            Console.ForegroundColor = _diagnosticsList.GetColor(diagnostic.Type);
            Console.WriteLine(diagnostic);
            Console.ResetColor();
        }
    }
}