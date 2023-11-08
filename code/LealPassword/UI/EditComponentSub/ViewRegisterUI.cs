using Bunifu.Framework.UI;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Themes;
using LealPassword.UI.Popup;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.EditComponentSub
{
    internal partial class ViewRegisterUI : UserControl
    {
        internal delegate void UpdateRegister(Register register);
        internal event UpdateRegister OnCardUpdated;

        internal delegate void DeleteRegister(Register register);
        internal event DeleteRegister OnCardDeleted;

        private ComboBox _comboBoxTag;
        private BunifuMaterialTextbox _txtBoxCat;
        private BunifuMaterialTextbox _txtBoxMail;
        private BunifuMaterialTextbox _txtBoxName;
        private BunifuMaterialTextbox _txtBoxPassword;
        private BunifuMaterialTextbox _txtBoxDescription;

        private Button _buttonNewTag;
        private Button _buttonGeneratePass;

        private readonly Register _original;
        private readonly Register _register;
        private readonly List<Register> _registers;

        internal IconChooserPopup Popup;

        private Label _labelIcon;
        private Label _buttonObserve;
        private Button _buttonSave;
        private string _iconKey;

        internal ViewRegisterUI(List<Register> registers, Register register, Control parent)
        {
            _original = new Register()
            {
                Id = register.Id,
                Name = register.Name,
                Description = register.Description,
                Email = register.Email,
                ImageKey = register.ImageKey,
                Password = register.Password,
                Tag = register.Tag
            };
            _iconKey = register.ImageKey;
            _register = register;
            _registers = registers;
            Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            BackColor = parent.BackColor;
            GenerateObjects();
        }

        internal void GenerateObjects()
        {
            #region Top Panel
            var panelTop = new Panel()
            {
                Height = 96,
                Dock = DockStyle.Top,
                BackColor = BackColor,
            };
            var nameLabel = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Text = $"    {_register.Name}",
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Verdana", 20, FontStyle.Italic)
            };
            var panelOberserve = new Panel()
            {
                Width = 96,
                Dock = DockStyle.Right,
                BackColor = Color.Transparent
            };
            _buttonObserve = new Label()
            {
                Text = "",
                Width = 32,
                Height = 32,
                AutoSize = false,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = PRController.Images.Trash_64px,
            };
            Program.CentralizeControl(_buttonObserve, panelOberserve);
            _buttonObserve.Click += ButtonDelete_Click;
            _buttonObserve.MouseEnter += ButtonDelete_MouseEnter;
            _buttonObserve.MouseLeave += ButtonDelete_MouseLeave;
            #endregion

            _txtBoxName = new BunifuMaterialTextbox() 
            { 
                HintText = "Name*",
                Text = _register.Name,
            };
            _txtBoxCat = new BunifuMaterialTextbox() 
            { 
                Visible = false,
                Text = _register.Tag,
                HintText = "Category",
            };
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
                Text = "New",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Verdana", 11, FontStyle.Regular)
            };
            _buttonNewTag.Click += ButtonNewTag_Click;

            _txtBoxMail = new BunifuMaterialTextbox() 
            { 
                HintText = "Email*",
                Text = _register.Email
            };
            _txtBoxPassword = new BunifuMaterialTextbox() 
            { 
                HintText = "Password*",
                Text = _register.Password
            };
            _buttonGeneratePass = new Button()
            {
                Width = 95,
                Height = 30,
                Text = "Generate",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Verdana", 11, FontStyle.Regular)
            };
            _buttonGeneratePass.Click += ButtonGeneratePass_Click;
            _txtBoxDescription = new BunifuMaterialTextbox() 
            { 
                HintText = "Description",
                Text = _register.Description
            };

            _buttonSave = new Button()
            {
                Height = 40,
                Width = 500,
                Text = "Save and Exit",
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
            };
            _buttonSave.Click += ButtonSave_Click;
            _buttonSave.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            _buttonSave.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;

            Controls.Add(_txtBoxName);
            Controls.Add(_txtBoxCat);
            Controls.Add(_comboBoxTag);
            Controls.Add(_buttonNewTag);
            Controls.Add(_txtBoxMail);
            Controls.Add(_txtBoxPassword);
            Controls.Add(_buttonGeneratePass);
            Controls.Add(_txtBoxDescription);
            Controls.Add(_buttonSave);

            foreach (var ctrls in Controls)
            {
                if (ctrls is BunifuMaterialTextbox txtbox)
                {
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
            Program.CentralizeControl(_buttonSave, this);
            _buttonSave.Location = new Point(_buttonSave.Location.X, _buttonSave.Location.Y + 150);
            #endregion

            #region Icons
            _labelIcon = new Label()
            {
                Width = 96,
                Height = 96,
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Image = PRController.dictIdImages[_register.ImageKey],
            };
            Program.HorizontalCentralize(_labelIcon, this);
            _labelIcon.Location = new Point(32, _txtBoxName.Location.Y);
            Controls.Add(_labelIcon);

            var buttonIcon = new Button
            {
                Width = 96,
                Height = 30,
                Text = "Icon",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Verdana", 11, FontStyle.Regular),
            };
            Program.HorizontalCentralize(buttonIcon, this);
            buttonIcon.Location = new Point(32, _labelIcon.Location.Y + _labelIcon.Width + 5);
            buttonIcon.Click += ButtonIcon_Click;
            Controls.Add(buttonIcon);
            #endregion

            #region Add Controls
            Controls.Add(panelTop);

            panelOberserve.Controls.Add(_buttonObserve);
            panelTop.Controls.Add(panelOberserve);
            panelTop.Controls.Add(nameLabel);
            #endregion

            ButtonNewTag_Click(null, null);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var regName = _txtBoxName.Text;
            var milName = _txtBoxMail.Text;
            var tagName = _comboBoxTag.Visible ? _comboBoxTag.Text : _txtBoxCat.Text;
            var passwrd = _txtBoxPassword.Text;
            var descrpt = _txtBoxDescription.Text;

            if (regName.IsNullString() || tagName.IsNullString() || milName.IsNullString() || passwrd.IsNullString())
            {
                MessageBox.Show("Please fill in the required fields:\n" +
                    "Name, category, email and password.", "Please fill in the required fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _register.Name = regName;
            _register.Email = milName;
            _register.Tag = tagName;
            _register.ImageKey = _iconKey;
            _register.Password = passwrd;
            _register.Description = descrpt;

            if (_original.CheckEqual(_register))
            {
                Dispose();
                return;
            }

            var dialog = MessageBox.Show("Are you sure that you want to update this register?", "Confirm register", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (!dialog.Equals(DialogResult.Yes))
                return;

            OnCardUpdated?.Invoke(_register);
        }

        private void ButtonGeneratePass_Click(object sender, EventArgs e)
        {
            var passGenerated = Security.Security.GeneratePassword(15);
            _txtBoxPassword.Text = passGenerated;
        }

        private void HideValues(bool hide)
        {
            _txtBoxCat.Visible = !hide;
            _txtBoxMail.Visible = !hide;
            _txtBoxName.Visible = !hide;
            _buttonSave.Visible = !hide;
            _comboBoxTag.Visible = !hide;
            _buttonNewTag.Visible = !hide;
            _txtBoxPassword.Visible = !hide;
            _txtBoxDescription.Visible = !hide;
            _buttonGeneratePass.Visible = !hide;

            if (!hide)
            {
                _comboBoxTag.Visible = _buttonNewTag.Text == "New";
                _txtBoxCat.Visible = _buttonNewTag.Text == "Existing";
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure that you want to delete this register?", $"Deleting {_register.Name}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (!dialog.Equals(DialogResult.Yes))
                return;

            OnCardDeleted?.Invoke(_register);
        }

        private void ButtonDelete_MouseEnter(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.Trash_Openning_64px;

        private void ButtonDelete_MouseLeave(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.Trash_64px;

        private void ButtonIcon_Click(object sender, EventArgs e)
        {
            Popup?.Dispose();
            Popup = new IconChooserPopup(this);
            Program.UpdateControlY(Popup, 30);
            Popup.OnIconChosen += IconsPopup_OnIconChosen;
            Popup.Show();
            HideValues(true);
        }

        private void ButtonNewTag_Click(object sender, EventArgs e)
        {
            _txtBoxCat.Visible = !_txtBoxCat.Visible;
            _comboBoxTag.Visible = !_comboBoxTag.Visible;
            _buttonNewTag.Text = _buttonNewTag.Text == "New" ? "Existing" : "New";
        }

        private void IconsPopup_OnIconChosen(string imageKey)
        {
            _iconKey = imageKey;
            _labelIcon.Image = PRController.dictIdImages[imageKey];
            _labelIcon.ImageAlign = ContentAlignment.MiddleCenter;
            Popup.Dispose();
            HideValues(false);
        }
    }
}