using Bunifu.Framework.UI;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Themes;
using LealPassword.UI.Popup;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.MainPartsSub
{
    internal sealed partial class RegistersAddViewUI : UserControl
    {
        private readonly List<Register> _registers;

        internal delegate void RegistersAdded(Register register);
        internal event RegistersAdded OnAddedRegisters;

        internal IconChooserPopup Popup;

        private ComboBox _comboBoxTag;
        private BunifuMaterialTextbox _txtBoxCat;
        private BunifuMaterialTextbox _txtBoxMail;
        private BunifuMaterialTextbox _txtBoxName;
        private BunifuMaterialTextbox _txtBoxPassword;
        private BunifuMaterialTextbox _txtBoxDescription;
        private Label _labelName;
        private Label _labelIcon;
        private string _imageKey;

        private Button _buttonLogin;
        private Button _buttonNewTag;
        private Button _buttonGeneratePass;

        internal RegistersAddViewUI(List<Register> registers, Control parent)
        {
            Dock = DockStyle.Fill;
            _registers = registers;
            parent.Controls.Clear();
            parent.Controls.Add(this);
        }

        internal void GenerateObjects()
        {
            _labelName = new Label()
            {
                Height = 50,
                Width = 250,
                AutoSize = false,
                Text = "Novo registro",
                Font = new Font("Verdana", 21, FontStyle.Regular)
            };
            _txtBoxName = new BunifuMaterialTextbox() { HintText = "Nome*" };
            _txtBoxCat = new BunifuMaterialTextbox() { HintText = "Categoria", Visible = false };
            _comboBoxTag = new ComboBox()
            {
                Width = 500,
                Height = 40,
                Font = new Font("Consolas", 16, FontStyle.Regular),
            };

            foreach (var item in _registers)
            {
                if (!_comboBoxTag.Items.Contains(item.Tag))
                    _comboBoxTag.Items.Add(item.Tag);
            }
             
            _buttonNewTag = new Button()
            {
                Width = 95,
                Height = 30,
                Text = "Nova",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Verdana", 11, FontStyle.Regular)
            };
            _buttonNewTag.Click += ButtonNewTag_Click;

            _txtBoxMail = new BunifuMaterialTextbox() { HintText = "Email*" };
            _txtBoxPassword = new BunifuMaterialTextbox() { HintText = "Senha*" };
            _buttonGeneratePass = new Button()
            {
                Width = 95,
                Height = 30,
                Text = "Gerar",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Verdana", 11, FontStyle.Regular)
            };
            _buttonGeneratePass.Click += ButtonGeneratePass_Click;
            _txtBoxDescription = new BunifuMaterialTextbox() { HintText = "Descrição" };

            _buttonLogin = new Button()
            {
                Height = 40,
                Width = 500,
                Text = "Criar",
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
            };
            _buttonLogin.Click += ButtonLogin_Click;
            _buttonLogin.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            _buttonLogin.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;
            
            Controls.Add(_labelName);
            Controls.Add(_txtBoxName);
            Controls.Add(_txtBoxCat);
            Controls.Add(_comboBoxTag);
            Controls.Add(_buttonNewTag);
            Controls.Add(_txtBoxMail);
            Controls.Add(_txtBoxPassword);
            Controls.Add(_buttonGeneratePass);
            Controls.Add(_txtBoxDescription); 
            Controls.Add(_buttonLogin);

            foreach (var ctrls in Controls)
            {
                if (ctrls is BunifuMaterialTextbox txtbox)
                {
                    txtbox.Text = "";
                    txtbox.Height = 40;
                    txtbox.Width = 500;
                    txtbox.ForeColor = ThemeController.LiteGray;
                    txtbox.BackColor = ThemeController.IceWhite;
                    txtbox.HintForeColor = ThemeController.LiteGray;
                    txtbox.LineIdleColor = ThemeController.IceWhite;
                    txtbox.LineFocusedColor = ThemeController.IceWhite;
                    txtbox.LineMouseHoverColor = ThemeController.IceWhite;
                    txtbox.Font = new Font("Consolas", 16, FontStyle.Regular);
                }
            }

            #region Layout adjust
            Program.CentralizeControl(_labelName, this);
            _labelName.Location = new Point(_labelName.Location.X, _labelName.Location.Y - 285);
            Program.CentralizeControl(_txtBoxName, this);
            _txtBoxName.Location = new Point(_txtBoxName.Location.X, _txtBoxName.Location.Y - 210);
            Program.CentralizeControl(_txtBoxCat, this);
            _txtBoxCat.Location = new Point(_txtBoxCat.Location.X, _txtBoxCat.Location.Y - 155);
            Program.CentralizeControl(_comboBoxTag, this);
            _comboBoxTag.Location = new Point(_comboBoxTag.Location.X, _comboBoxTag.Location.Y - 155);
            Program.CentralizeControl(_buttonNewTag, this);
            _buttonNewTag.Location = new Point(_buttonNewTag.Location.X - (_buttonNewTag.Width / 2) 
                + (_txtBoxCat.Width / 2), _buttonNewTag.Location.Y - 115);
            Program.CentralizeControl(_txtBoxMail, this);
            _txtBoxMail.Location = new Point(_txtBoxMail.Location.X, _txtBoxMail.Location.Y - 70);
            Program.CentralizeControl(_txtBoxPassword, this);
            _txtBoxPassword.Location = new Point(_txtBoxPassword.Location.X, _txtBoxPassword.Location.Y - 15);
            Program.CentralizeControl(_buttonGeneratePass, this);
            _buttonGeneratePass.Location = new Point(_buttonGeneratePass.Location.X - (_buttonGeneratePass.Width / 2)
                + (_txtBoxCat.Width / 2), _buttonGeneratePass.Location.Y + 30);
            Program.CentralizeControl(_txtBoxDescription, this);
            _txtBoxDescription.Location = new Point(_txtBoxDescription.Location.X, _txtBoxDescription.Location.Y + 75);
            Program.CentralizeControl(_buttonLogin, this);
            _buttonLogin.Location = new Point(_buttonLogin.Location.X, _buttonLogin.Location.Y + 150);
            #endregion

            #region Icons
            _labelIcon = new Label()
            {
                Width = 96,
                Height = 96,
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
            };
            Program.HorizontalCentralize(_labelIcon, this);
            _labelIcon.Location = new Point(32, _txtBoxName.Location.Y);
            Controls.Add(_labelIcon);

            var buttonIcon = new Button
            {
                Width = 96,
                Height = 30,
                Text = "Ícone",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Verdana", 11, FontStyle.Regular),
            };
            Program.HorizontalCentralize(buttonIcon, this);
            buttonIcon.Location = new Point(32, _labelIcon.Location.Y + _labelIcon.Width + 5);
            buttonIcon.Click += ButtonIcon_Click;
            Controls.Add(buttonIcon);
            #endregion
        }

        private void ButtonGeneratePass_Click(object sender, EventArgs e)
        {
            var passGenerated = Security.Security.GeneratePassword("221221234341221");
            _txtBoxPassword.Text = passGenerated;
        }

        private void ButtonIcon_Click(object sender, EventArgs e)
        {
            if (Popup != null)
                Popup.Dispose();

            Popup = new IconChooserPopup(this);
            Popup.OnIconChosen += IconsPopup_OnIconChosen;
            Popup.Show();
            HideValues(true);
        }

        private void IconsPopup_OnIconChosen(string imageKey)
        {
            _imageKey = imageKey;
            _labelIcon.Image = PRController.dictIdImages[imageKey];
            _labelIcon.ImageAlign = ContentAlignment.MiddleCenter;
            Popup.Dispose();
            HideValues(false);
        }

        private void HideValues(bool hide)
        {
            _labelName.Visible = !hide;
            _txtBoxCat.Visible = !hide;
            _txtBoxMail.Visible = !hide;
            _txtBoxName.Visible = !hide;
            _buttonLogin.Visible = !hide;
            _comboBoxTag.Visible = !hide;
            _buttonNewTag.Visible = !hide;
            _txtBoxPassword.Visible = !hide;
            _txtBoxDescription.Visible = !hide;
            _buttonGeneratePass.Visible = !hide;

            if (!hide)
            {
                _comboBoxTag.Visible = _buttonNewTag.Text == "Nova";
                _txtBoxCat.Visible = _buttonNewTag.Text == "Existente";
            }
        }

        private void ButtonNewTag_Click(object sender, EventArgs e)
        {
            _txtBoxCat.Visible = !_txtBoxCat.Visible;
            _comboBoxTag.Visible = !_comboBoxTag.Visible;
            _buttonNewTag.Text = _buttonNewTag.Text == "Nova" 
                ? "Existente" 
                : "Nova";
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            var regName = _txtBoxName.Text;
            var milName = _txtBoxMail.Text;
            var tagName = _comboBoxTag.Visible
                ? _comboBoxTag.Text
                : _txtBoxCat.Text;
            var passwrd = _txtBoxPassword.Text;
            var descrpt = _txtBoxDescription.Text;

            if (string.IsNullOrEmpty(regName) || string.IsNullOrWhiteSpace(regName) ||
                string.IsNullOrEmpty(tagName) || string.IsNullOrWhiteSpace(tagName) ||
                string.IsNullOrEmpty(milName) || string.IsNullOrWhiteSpace(milName) ||
                string.IsNullOrEmpty(passwrd) || string.IsNullOrWhiteSpace(passwrd))
            {
                MessageBox.Show("Preencha os campos obrigatórios:\n" +
                    "Nome, Categoria, Email e Senha.", "Preencha os campos obrigatórios", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnAddedRegisters?.Invoke(new Register()
            {
                Tag = tagName,
                Name = regName,
                Email = milName,
                Password = passwrd,
                ImageKey = _imageKey,
                Description = descrpt,
            });
        }
    }
}