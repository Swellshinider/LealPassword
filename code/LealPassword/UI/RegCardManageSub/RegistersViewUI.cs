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
                regPanel.OnEditMe += RegPanel_OnEditMe;
                regPanel.OnSeeMe += RegPanel_OnSeeMe;
                regPanel.OnClickMe += RegPanel_OnClickMe;
                regPanel.OnDiscardMe += RegPanel_OnDiscartMe;
                Controls.Add(regPanel);
                Update();
            }
        }

        private void GenerateObjects()
        {
            if (_registers.Count <= 0)
            {
                var lblRegisters = new Label()
                {
                    Height = 100,
                    Dock = DockStyle.Top,
                    ForeColor = ThemeController.Black,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Verdana", 18, FontStyle.Regular),
                    Text = "Você não tem nenhum registro cadastrado.\n" +
                    "Adicione um novo no botão azul do painel superior.",
                };

                Controls.Add(lblRegisters);
                return;
            }

            foreach (var reg in _registers)
            {
                var regPanel = new RegisterPanel(reg);
                regPanel.OnEditMe += RegPanel_OnEditMe;
                regPanel.OnSeeMe += RegPanel_OnSeeMe;
                regPanel.OnClickMe += RegPanel_OnClickMe;
                Controls.Add(regPanel);
                Update();
            }
        }

        #region Register panel
        private void RegPanel_OnSeeMe(Register register)
        {
            // TODO: seepanel
        }

        private void RegPanel_OnEditMe(Register register)
        {
            // TODO: editpanel
        }

        private void RegPanel_OnDiscartMe(Register register)
        {
            // TODO: discartpanel
        }

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