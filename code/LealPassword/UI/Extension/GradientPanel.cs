using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed class GradientPanel : Panel
    {
        internal GradientPanel(Color topColor, Color bottomColor)
        {
            TopColor = topColor;
            BottomColor = bottomColor;
        }

        internal Color TopColor { get; set; }
        internal Color BottomColor { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ClientRectangle.Height == 0 || ClientRectangle.Width == 0) return;

            var lgb = new LinearGradientBrush(ClientRectangle, TopColor, BottomColor, 90f);
            var g = e.Graphics;

            g.FillRectangle(lgb, ClientRectangle);

            base.OnPaint(e);
        }
    }
}