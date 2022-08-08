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
    internal sealed partial class CreateUI : UserControl
    {
        internal delegate void AccountCreated();
        internal event AccountCreated OnAccountCreated;

        public CreateUI()
        {
            InitializeComponent();
        }
    }
}