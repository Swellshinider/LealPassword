using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using LealPassword.UI.Extension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LealPassword.UI.MainScreen
{
    internal sealed class MainUI : BaseUI
    {
        private readonly Account _account;
        private readonly string _masterpass;

        internal MainUI(DiagnosticList diagnostic, Account account, string masterpass) 
            : base(diagnostic)
        {
            _account = account;
            _masterpass = masterpass;
            Width = Constants.BaseUISize.Width;
            Height = Constants.BaseUISize.Height;
            BackColor = ThemeController.IceWhite;
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            #region Panel Top Side
            var panelTop = new Panel()
            {
                Dock = DockStyle.Top,
                Height = (int)(Height * 0.1f),
                BackColor = ThemeController.IceWhite,
            };
            panelTop.MouseDown += ControlMouseDown;
            Controls.Add(panelTop);
            #endregion

            #region Panel Left Side
            var panelLeft = new GradientPanel(ThemeController.MainUILeftPanelTopColor, 
                ThemeController.MainUIRightPanelBottomColor)
            {
                Dock = DockStyle.Left,
                Width = (int)(Width * 0.25f),
            };
            panelLeft.MouseDown += ControlMouseDown;
            Controls.Add(panelLeft);
            #endregion

            #region Search Box
            var searchBox = new Bunifu.Framework.UI.BunifuTextbox()
            {
                Height = 50,
                Width = (int)(panelTop.Width * 0.5f),
            };
            panelTop.Controls.Add(searchBox);
            Program.CentralizeControl(searchBox, panelTop);
            #endregion
        }

        private void ControlMouseDown(object sender, MouseEventArgs e)
            => Program.ControlMouseDown(Handle, e);
    }
}
