using LealPassword.Database.Model;
using LealPassword.Themes;
using LealPassword.UI.Extension;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.RegCardManageSub
{
    internal sealed partial class RegistersViewUI : UserControl
    {
        internal delegate void SeeMe(Register card);
        internal event SeeMe OnSeeMe;

        private readonly List<Register> _registers;

        internal RegistersViewUI(List<Register> registers, Control parent)
        {
            InitializeComponent();
            AutoScroll = true;
            Dock = DockStyle.Fill;
            _registers = registers;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            BackColor = Color.Transparent;
            GenerateObjects();
        }

        internal void Filter(string filter)
        {
            Controls.Clear();
            filter = filter.ToLower();

            if (filter == "" || filter == null)
            {
                GenerateObjects();
                return;
            }

            foreach (var reg in _registers)
            {
                if (!reg.Name.ToLower().Contains(filter) && !reg.Name.ToLower().Equals(filter) &&
                    !reg.Tag.ToLower().Contains(filter) && !reg.Tag.ToLower().Equals(filter))
                    continue;

                var regPanel = new RegisterPanel(reg);
                regPanel.OnSeeMe += RegPanel_OnSeeMe;
                regPanel.OnClickMe += RegPanel_OnClickMe;
                Controls.Add(regPanel);
                Update();
            }
        }

        private void GenerateObjects()
        {
            if (_registers.Count <= 0)
            {
                var image = new Label()
                {
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = ThemeController.LiteGray,
                    Font = new Font("Arial", 32, FontStyle.Regular),
                    Text = "You don't have any register registered.\nAdd a new one on the blue button in the top panel.",
                };
                Controls.Add(image);
                return;
            }

            foreach (var reg in _registers)
            {
                var regPanel = new RegisterPanel(reg);
                regPanel.OnSeeMe += RegPanel_OnSeeMe;
                regPanel.OnClickMe += RegPanel_OnClickMe;
                Controls.Add(regPanel);
                Update();
            }
        }

        #region Register panel
        private void RegPanel_OnSeeMe(Register register) => OnSeeMe?.Invoke(register);

        private void RegPanel_OnClickMe(RegisterPanel registerPanel)
        {
            foreach(var reg in Controls)
                if (reg is RegisterPanel regPanel)
                    regPanel.HideOptions();

            registerPanel.HideOptions(false);
        }
        #endregion
    }
}