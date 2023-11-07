using System;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed partial class NoteCardPanel : UserControl
    {
        internal NoteCardPanel()
        {
            InitializeComponent();
            Resize += NoteCardPanel_Resize;
        }

        internal void LoadObjects(string title, (Color valueColor, int val) value, Image imageIcon)
        {
            labelText.Text = title;
            labelText.Font = new Font("Nunito Sans", 16, FontStyle.Regular);
            labelValue.Text = value.val.ToString();
            labelValue.Font = new Font("Verdana", 18, FontStyle.Regular);
            labelValue.ForeColor = value.valueColor;

            panelIcon.BackgroundImage = imageIcon;
            panelIcon.BackgroundImageLayout = ImageLayout.Zoom;

            NoteCardPanel_Resize(null, null);
        }

        private void NoteCardPanel_Resize(object sender, EventArgs e)
        {
            panelRight.Width = Height;
            panelIcon.Height = panelRight.Height / 2;
            panelIcon.Width = panelRight.Width / 2;
            Program.CentralizeControl(panelIcon, panelRight);
            
            var offset = (panelRight.Width - panelIcon.Width) / 4;
            Program.UpdateControlX(panelIcon, -offset);

            panelTop.Height = Program.RoundValue(Height * 0.4);
            labelText.Width = panelTop.Width - 20;
            labelValue.Width = panelValue.Width - 20;

            Region = Program.GenerateRoundRegion(Width, Height);
        }
    }
}