﻿using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Exceptions;
using LealPassword.UI;
using LealPassword.UI.Extension;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LealPassword
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private static readonly DiagnosticList _diagnostics = DiagnosticList.Instance;

        [STAThread]
        internal static void Main(string[] argv)
        {
            HideConsole();
            _diagnostics.DiagnosticGenerated += DiagnosticsList_DiagnosticGenerated;

            ArgvLoad(argv);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _diagnostics.Debug("App configuration started");
            Application.Run(new LoginCreateAccountUI(_diagnostics));
            Application.ApplicationExit += Application_ApplicationExit;
        }

        private static void ArgvLoad(string[] args)
        {
            if (args.Length == 0)
                return;

            foreach (var arg in args)
            {
                if (!arg.StartsWith("-"))
                {
                    _diagnostics.Warn("Invalid argument format", new InvalidArgumentFormatException(arg));
                    continue;
                }
                
                var argument = arg.Replace("-", "").ToLower();

                switch (argument)
                {
                    case "a":
                        ShowConsole();
                        _diagnostics.Debug("ADM mode activate");
                        break;
                    default:
                        _diagnostics.Warn("Invalid argument handled", new InvalidArgumentHandledException(arg));
                        break;
                }
            }
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

        internal static void UpdateControlY(Control control, int offset)
        {
            var pos = control.Location;
            control.Location = new Point(pos.X, pos.Y + offset);
        }

        internal static void UpdateControlYAbsolute(Control control, int y)
        {
            var pos = control.Location;
            control.Location = new Point(pos.X, y);
        }

        internal static void UpdateControlX(Control control, int offset)
        {
            var pos = control.Location;
            control.Location = new Point(pos.X + offset, pos.Y);
        }

        internal static void UpdateControlXAbsolute(Control control, int x)
        {
            var pos = control.Location;
            control.Location = new Point(x, pos.Y);
        }

        internal static void UpdateControlYOffSetNext(Control control, Control controlReference, int offsetbetween)
        {
            var newXPos = controlReference.Location.Y + controlReference.Height + offsetbetween;
            UpdateControlYAbsolute(control, newXPos);
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

        internal static bool IsNullString(this string s) => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);

        internal static int RoundValue(double value) => (int)Math.Round(value);

        internal static void Exit() => Application.Exit();

        internal static void Restart() => Application.Restart();

        internal static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var targetImage = new Bitmap(width, height);

            targetImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var g = Graphics.FromImage(targetImage))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return targetImage;
        }

        internal static Region GenerateRoundRegion(int width, int height) => GenerateRoundRegion(width, height, Constants.ELIPSE_CURVE);

        internal static Region GenerateRoundRegion(int width, int height, int curve) => Region.FromHrgn(CreateRoundRectRgn(0, 0, width, height, curve, curve));

        private static void DiagnosticsList_DiagnosticGenerated(Diagnostic diagnostic)
        {
            Console.ForegroundColor = _diagnostics.GetColor(diagnostic.Type);
            Console.WriteLine(diagnostic);
            Console.ResetColor();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (!PRController.AutoLogin)
            {
                PRController.LastUser = null;
                PRController.LastPassword = null;
            }
        }
    }
}