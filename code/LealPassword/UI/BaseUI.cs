using LealPassword.Definitions;
using LealPassword.Diagnostics;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LealPassword.UI
{
    internal abstract partial class BaseUI : Form
    {
        protected readonly DiagnosticList _diagnostic;

        internal BaseUI() { }

        internal BaseUI(DiagnosticList diagnostic)
        {
            _diagnostic = diagnostic;
            Resize += BaseUI_Resize;
            StartPosition = FormStartPosition.CenterScreen;
            BaseDefinition();
            InitializeComponent();
        }

        private void BaseDefinition()
        {
            _diagnostic.Debug("Initialize base definition");
            Icon = PRController.LealPassword_Icon;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);
            _diagnostic.Debug("Base definition loaded");
        }

        private void BaseUI_Resize(object sender, EventArgs e)
            => Region = Program.GenerateRoundRegion(Width, Height);
    }
}