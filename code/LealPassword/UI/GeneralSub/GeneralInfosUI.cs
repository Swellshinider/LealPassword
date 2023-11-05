using LealPassword.Database.Model;
using LealPassword.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LealPassword.UI.GeneralSub
{
    internal sealed partial class GeneralInfosUI : UserControl
    {
        private readonly Account _account;

        internal GeneralInfosUI(Account account, Control parent)
        {
            _account = account;
            Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            #region Add Controls

            #endregion
        }

        internal double AveragePasswordStrength()
        {
            if (_account.Registers.Count <= 0)
                return 0;

            var total = 0;

            foreach(var register in _account.Registers)
                total += Security.Security.GetPasswordStrength(register.Password);

            return total / _account.Registers.Count;
        }
    }
}