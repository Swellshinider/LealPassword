using LealPassword.Diagnostics;
using LealPassword.Settings;
using LealPassword.Theme;
using LealPassword.View.LoginViewSub;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.View
{
    internal sealed partial class LoginView : Form
    {
        private readonly DiagnosticList _diagnostic;
       
        internal LoginView(DiagnosticList diagnostic)
        {
            _diagnostic = diagnostic;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            Region = GetRegion();
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            panelLeftContainer.Width = (int)(Width - (Width * 0.5f));
            buttonClose.AutoSize = false;
            buttonClose.Text = "";
            buttonClose.Width = 32;
            buttonClose.Cursor = Cursors.Hand;
            buttonClose.Dock = DockStyle.Right;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.Region = Program.GenerateRoundRegion(buttonClose.Width, buttonClose.Height, 20);
            buttonClose.Click += ButtonClose_Click;

            UpdateTheme();
            LoadLogin();
        }

        private void UpdateTheme()
        {
            BackColor = ThemeController.SuperLiteGray;
            panelLeftContainer.BackColor = ThemeController.BlueMain;
            panelTop.BackColor = ThemeController.SuperLiteGray;
            panelContainer.BackColor = ThemeController.SuperLiteGray;
            buttonClose.BackColor = ThemeController.SuperLiteGray;
            buttonClose.FlatAppearance.MouseOverBackColor = ThemeController.MouseOverCloseButton;
            buttonClose.FlatAppearance.MouseDownBackColor = ThemeController.MouseDownCloseButton;
        }

        private void LoadLogin()
        {
            panelContainer.Controls.Clear();
            var subLoginView = new LoginViewS(panelContainer);
        }

        private void LoadCreateAccount()
        {
            panelContainer.Controls.Clear();

        }

        private void ButtonClose_Click(object? sender, EventArgs e)
        {
            if (sender == null) return;

            Program.Exit();
        }

        #region Internal Forms
        private Region GetRegion() 
            => Program.GenerateRoundRegion(Width, Height);

        private void MouseDownControl(object sender, MouseEventArgs e) 
            => Program.ControlMouseDown(Handle, e);
        #endregion
    }
}