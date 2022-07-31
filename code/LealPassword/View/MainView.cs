using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LealPassword.View
{
    internal sealed partial class MainView : Form
    {
        private Region GetRegion() => Program.GenerateRoundRegion(Width, Height, 20);

        internal MainView()
        {
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            Region = GetRegion();
        }

        private void MainView_Resize(object sender, EventArgs e) => Region = GetRegion();

        #region Override
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x84)
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                if (pos.Y < 32)
                    m.Result = (IntPtr)2;

                if (pos.X >= ClientSize.Width - 16 && pos.Y >= ClientSize.Height - 16)
                    m.Result = (IntPtr)17;
            }
        }
        #endregion
    }
}
