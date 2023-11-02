using LealPassword.Database.Model;
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
            var upperPanel = new Panel()
            {
                Height = Height / 2,
                Dock = DockStyle.Top,
            };
            var lowerPanel = new Panel()
            {
                Height = Height / 2,
                Dock = DockStyle.Top,
                BackColor = Color.AliceBlue
            };

            #region Upper
            #endregion

            #region Add Controls
            Controls.Add(lowerPanel);
            Controls.Add(upperPanel);
            #endregion
        }

        internal double AveragePasswordStrength()
        {
            var total = 0;

            foreach(var register in _account.Registers)
                total += Security.Security.GetPasswordStrength(register.Password);

            return total / _account.Registers.Count;
        }
    }
}