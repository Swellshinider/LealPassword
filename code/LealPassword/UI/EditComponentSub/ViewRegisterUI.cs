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

namespace LealPassword.UI.EditComponentSub
{
    internal partial class ViewRegisterUI : UserControl
    {
        private readonly Register _register;

        internal ViewRegisterUI(Register register, Control parent)
        {
            _register = register;
            Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            BackColor = parent.BackColor;
            GenerateObjects();
        }

        internal void GenerateObjects()
        {
            var labelTest = new Label()
            {
                AutoSize = false,
                Text = "Test register",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            #region Add Controls
            Controls.Add(labelTest);
            #endregion
        }
    }
}