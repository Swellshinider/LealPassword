using LealPassword.Themes;
using System;
using System.Windows.Forms;

namespace LealPassword.UI.Extension
{
    internal sealed partial class ConfigPanel : UserControl
    {
        internal delegate void TurnOnOff(bool value);
        internal event TurnOnOff OnSwitch;

        internal ConfigPanel()
        {
            InitializeComponent();
        }

        internal void LoadObjects(string title, string description, bool started)
        {
            labelTitle.Text = title;
            labelDescription.Text = description;
            lineSeparator.Width = labelTitle.Text.Length * (labelTitle.Font.Height - (labelTitle.Font.Height / 2));
            switchButton.Value = started;

            switchButton.BackColor = ThemeController.IceWhite;
            switchButton.ForeColor = ThemeController.LineDarkBlue;
            switchButton.Oncolor = ThemeController.SligBlue;
            switchButton.Onoffcolor = ThemeController.BlueMain;

            Program.HorizontalCentralize(switchButton, panelRight);

            Region = Program.GenerateRoundRegion(Width, Height);
        }

        internal void SetValue(bool value)
        {
            switchButton.Value = value;
            SwitchButton_Click(null, null);
        }

        private void SwitchButton_Click(object sender, EventArgs e) => OnSwitch?.Invoke(switchButton.Value);
    }
}