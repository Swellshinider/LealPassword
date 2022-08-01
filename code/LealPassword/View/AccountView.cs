using LealPassword.Settings;
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
    internal sealed partial class AccountView : Form
    {
        internal AccountView()
        {
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            Region = GetRegion();
        }

        #region Internal Forms
        private void MainView_Resize(object sender, EventArgs e) => Region = GetRegion();

        private Region GetRegion() => Program.GenerateRoundRegion(Width, Height, DefinitionsConstants.ELIPSE_CURVE);

        private void MouseDownControl(object sender, MouseEventArgs e) => Program.ControlMouseDown(Handle, e);
        #endregion

        #region Override
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x84)
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);

                if (pos.Y < DefinitionsConstants.SELECTABLE_AREA)
                    m.Result = (IntPtr)2;

                if (pos.X >= ClientSize.Width - DefinitionsConstants.SIZE_GRIP && 
                    pos.Y >= ClientSize.Height - DefinitionsConstants.SIZE_GRIP)
                    m.Result = (IntPtr)17;
            }
        }
        #endregion
    }
}
