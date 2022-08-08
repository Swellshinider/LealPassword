using LealPassword.Diagnostics;
using System;
using System.Windows.Forms;

namespace LealPassword.UI
{
    internal abstract partial class BaseUI : Form
    {
        protected readonly DiagnosticList _diagnostic;

        internal BaseUI(string title, DiagnosticList diagnostic)
        {
            _diagnostic = diagnostic;
            Resize += BaseUI_Resize;
            StartPosition = FormStartPosition.CenterScreen;
            BaseDefinition(title);
            InitializeComponent();
        }

        private void BaseDefinition(string title)
        {
            _diagnostic.Debug("Initialize base definition");
            Text = title;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);
            _diagnostic.Debug("Base definition loaded");
        }

        private void BaseUI_Resize(object sender, EventArgs e)
            => Region = Program.GenerateRoundRegion(Width, Height);
    }
}