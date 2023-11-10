using LealPassword.Database.Model;
using LealPassword.Themes;
using System.Collections.Generic;
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
        }

        internal void LoadObjects(Font font, List<Register> registers)
        {
            var averagePower = CalculateAveragePasswordPower(registers);
            var colorStrenght = GetColorByStrength(averagePower);
            var progressValue = Program.RoundValue(averagePower);

            labelTitle.Font = font;
            gaugeGraph.Value = progressValue;
            gaugeGraph.ForeColor = colorStrenght;
            gaugeGraph.ProgressColor1 = colorStrenght;
            gaugeGraph.ProgressColor2 = colorStrenght;
            gaugeGraph.ProgressBgColor = Color.GhostWhite;

            var labelValue = new Label()
            {
                Height = 50,
                Width = 100,
                AutoSize = false,
                BackColor = Color.White,
                Text = $"{progressValue}",
                ForeColor = colorStrenght,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(gaugeGraph.Font.FontFamily, gaugeGraph.Font.Height + 5, FontStyle.Regular),
            };
            Controls.Add(labelValue);

            #region Definition os legend
            panelColor1.BackColor = ThemeController.PoorPassword;
            panelColor2.BackColor = ThemeController.FairPassword;
            panelColor3.BackColor = ThemeController.GoodPassword;
            panelColor4.BackColor = ThemeController.ExcelentPassword;

            Program.VerticalCentralize(panelColor1, panelBottom);
            Program.VerticalCentralize(panelColor2, panelBottom);
            Program.VerticalCentralize(panelColor3, panelBottom);
            Program.VerticalCentralize(panelColor4, panelBottom);
            Program.VerticalCentralize(labelPoor, panelBottom);
            Program.VerticalCentralize(labelFair, panelBottom);
            Program.VerticalCentralize(labelGood, panelBottom);
            Program.VerticalCentralize(labelSuperb, panelBottom);

            Program.CentralizeControl(gaugeGraph, this);
            Program.CentralizeControl(labelValue, this);

            Program.UpdateControlY(labelValue, 50);
            labelValue.BringToFront();

            Region = Program.GenerateRoundRegion(Width, Height);
            #endregion
        }

        internal Color GetColorByStrength(double strength)
        {
            if (strength >= 95)
                return ThemeController.ExcelentPassword;

            if (strength >= 80)
                return ThemeController.GoodPassword;

            if (strength >= 50)
                return ThemeController.FairPassword;

            return ThemeController.PoorPassword;
        }

        internal double CalculateAveragePasswordPower(List<Register> registers)
        {
            if (registers.Count <= 0)
                return 0;

            var total = 0;

            foreach (var register in registers)
                total += Security.Security.GetPasswordStrength(register.Password);

            return total / registers.Count;
        }

        private void PasswordStrPanel_Resize(object sender, System.EventArgs e)
        {
            Program.CentralizeControl(gaugeGraph, this);
            Region = Program.GenerateRoundRegion(Width, Height);
        }
    }
}