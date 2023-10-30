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
            var image = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Text = "This screen was not created yet",
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Themes.ThemeController.LiteGray,
                Font = new Font("Arial", 32, FontStyle.Regular),
            };
            Controls.Add(image);    
        }

        internal static bool IsSecure(string password)
            => Security.Security.GetPasswordStrengh(password) >= 4;
    }
}