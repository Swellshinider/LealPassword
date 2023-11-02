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
    internal sealed partial class ViewCardUI : UserControl
    {
        private readonly Card _card;

        internal ViewCardUI(Card card, Control parent)
        {
            _card = card;
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
                Text = "Test card",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            #region Add Controls
            Controls.Add(labelTest);
            #endregion
        }
    }
}