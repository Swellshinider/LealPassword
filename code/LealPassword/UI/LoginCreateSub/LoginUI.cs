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

namespace LealPassword.UI.LoginCreateSub
{
    internal sealed partial class LoginUI : UserControl
    {
        internal delegate void CreatingAccountUI();
        internal event CreatingAccountUI OnCreatingAccount;

        internal LoginUI()
        {
            Dock = DockStyle.Fill;
            BackColor = ThemeController.SuperLiteGray;
            InitializeComponent();
            GenerateObjects();
        }

        internal void GenerateObjects()
        {
            
        }
    }
}