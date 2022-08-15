﻿using LealPassword.Database.Model;
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

namespace LealPassword.UI.MainPartsSub
{
    internal sealed partial class RegistersViewUI : UserControl
    {
        private readonly List<Register> _registers;

        internal RegistersViewUI(List<Register> registers, Control parent)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            _registers = registers;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            BackColor = Color.Transparent;
        }

        internal void GenerateObjects()
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
                Controls.Add(new Label()
                {
                    Text = reg.Name,
                    Dock = DockStyle.Top,
                    Height = 100,
                    ForeColor = ThemeController.Black,
                    BorderStyle = BorderStyle.FixedSingle,
                });
            }

            Controls.Add(new Panel()
            {
                Dock = DockStyle.Top,
                BorderStyle = BorderStyle.FixedSingle,
            });
        }
    }
}