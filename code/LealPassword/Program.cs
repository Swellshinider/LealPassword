using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.UI;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

        private static readonly DiagnosticList _diagnostics = DiagnosticList.Instance;

        [STAThread]
        internal static void Main(string[] argv)
        {
            _diagnostics.DiagnosticGenerated += DiagnosticsList_DiagnosticGenerated;
            HideConsole();
            if ((argv.Length >= 1 && argv[0].ToLower() == "-adm") || Constants.DEBUG == true)
            {
                ShowConsole();
                _diagnostics.Debug("ADM mode activate");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _diagnostics.Debug("App configuration started");
            Application.Run(new LoginCreateAccountUI(_diagnostics));
        }

        internal static void ControlMouseDown(IntPtr handle, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            ReleaseCapture();
            _ = SendMessage(handle, Constants.WM_NCLBUTTONDOWN, Constants.HT_CAPTION, 0);
        }

        internal static void CentralizeControl(Control control, Control controlReference)
        {
            HorizontalCentralize(control, controlReference);
            VerticalCentralize(control, controlReference);
        }

        internal static void HorizontalCentralize(Control control, Control controlReference)
        {
            var centerPoint = new Point(controlReference.Width / 2, controlReference.Height / 2);
            var xValue = centerPoint.X - (control.Width / 2);
            control.Location = new Point(xValue, control.Location.Y);
        }

        internal static void VerticalCentralize(Control control, Control controlReference)
        {
            var centerPoint = new Point(controlReference.Width / 2, controlReference.Height / 2);
            var yValue = centerPoint.Y - (control.Height / 2);
            control.Location = new Point(control.Location.X, yValue);
        }
 
        internal static void HideConsole() => ShowWindow(GetConsoleWindow(), Constants.SW_HIDE);

        internal static void ShowConsole() => ShowWindow(GetConsoleWindow(), Constants.SW_SHOW);

        internal static void Switch(Form current, Form target)
        {
            current.Hide();
            current.Enabled = false;
            current.Visible = false;
            current.ShowInTaskbar = false;
            
            target.Show();
            target.Enabled = true;
            target.Visible = true;
            target.ShowInTaskbar = true;
            target.Closed += (s, e) => current.Close();
        }

        internal static void UpdateGripFormRef(ref Message m, Form form)
        {
            if (m.Msg == 0x84)
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = form.PointToClient(pos);

                if (pos.X >= form.ClientSize.Width - Constants.SIZE_GRIP &&
                    pos.Y >= form.ClientSize.Height - Constants.SIZE_GRIP)
                    m.Result = (IntPtr)17;
            }
        }

        internal static void Exit() => Application.Exit();

        internal static void Restart() => Application.Restart();

        internal static Region GenerateRoundRegion(int width, int height)
            => GenerateRoundRegion(width, height, Constants.ELIPSE_CURVE);

        internal static Region GenerateRoundRegion(int width, int height, int curve)
            => Region.FromHrgn(CreateRoundRectRgn(0, 0, width, height, curve, curve));

        private static void DiagnosticsList_DiagnosticGenerated(Diagnostic diagnostic)
        {
            Console.ForegroundColor = _diagnostics.GetColor(diagnostic.Type);
            Console.WriteLine(diagnostic);
            Console.ResetColor();
        }
    }
}