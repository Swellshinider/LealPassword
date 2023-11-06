using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed partial class PasswordStrPanel : UserControl
    {
        internal PasswordStrPanel()
        {
            InitializeComponent();
            Resize += PasswordStrPanel_Resize;
            PasswordStrPanel_Resize(null, null);
        }

        internal Color ProgressBackColor
        {
            get => circularProgressBarr.ProgressBackColor;
            set => circularProgressBarr.ProgressBackColor = value;
        }

        internal Color ProgressColor
        {
            get => circularProgressBarr.ProgressColor;
            set
            {
                circularProgressBarr.ForeColor = value;
                circularProgressBarr.ProgressColor = value;
            }
        }

        internal new Font Font
        {
            get => labelTitle.Font;
            set => labelTitle.Font = value;
        }

        internal void SetValue(int value) => circularProgressBarr.Value = value;

        private void PasswordStrPanel_Resize(object sender, System.EventArgs e)
        {
            Program.CentralizeControl(circularProgressBarr, this);
            Region = Program.GenerateRoundRegion(Width, Height);
        }
    }
}