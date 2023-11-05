using Bunifu.Framework.UI;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Themes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LealPassword.UI.EditComponentSub
{
    internal sealed partial class ViewCardUI : UserControl
    {
        internal delegate void UpdateCard(Card card);
        internal event UpdateCard OnCardUpdated;

        internal delegate void DeleteCard(Card card);
        internal event DeleteCard OnCardDeleted;

        private readonly Card _card;
        private readonly Card _original;

        private ComboBox _comboBoxMonth;
        private ComboBox _comboBoxYear;
        private MaskedTextBox _txtBoxCardNumber;
        private BunifuMaterialTextbox _txtBoxName;
        private BunifuMaterialTextbox _txtBoxOwnName;
        private BunifuMaterialTextbox _txtBoxCvv;

        private Label _buttonObserve;

        internal ViewCardUI(Card card, Control parent)
        {
            _card = card;
            _original = card;
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
                Text = $"    {_card.CardName}",
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
                HintText = "Name of card",
                Text = _card.CardName
            };
            _txtBoxOwnName = new BunifuMaterialTextbox() 
            { 
                HintText = "Owner name",
                Text = _card.OwnrName,
            };
            var labelCardNumber = new Label()
            {
                Width = 250,
                Height = 40,
                AutoSize = false,
                Text = "Card number",
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Verdana", 14, FontStyle.Regular)
            };
            _txtBoxCardNumber = new MaskedTextBox()
            {
                Height = 40,
                Width = 250,
                Text = _card.Number,
                Mask = "####.####.####.####",
                ForeColor = ThemeController.LiteGray,
                BackColor = ThemeController.IceWhite,
                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Consolas", 16, FontStyle.Regular)
            };
            var labelDateCard = new Label()
            {
                Width = 250,
                Height = 40,
                AutoSize = false,
                Text = "Due Date",
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Verdana", 14, FontStyle.Regular)
            };
            _comboBoxMonth = new ComboBox()
            {
                Text = "",
                Height = 40,
                Width = 175,
                ForeColor = ThemeController.LiteGray,
                BackColor = ThemeController.IceWhite,
                Font = new Font("Consolas", 16, FontStyle.Regular)
            };
            _comboBoxMonth.Items.AddRange(new string[]
            {
                "01) January", "02) February", "03) March", "04) April", "05) May", "06) June",
                "07) July", "08) August", "09) September", "10) October", "11) November", "12) December"
            });
            _comboBoxMonth.SelectedIndex = _card.DueDate.Month - 1;
            _comboBoxYear = new ComboBox()
            {
                Text = "",
                Height = 40,
                Width = 75,
                ForeColor = ThemeController.LiteGray,
                BackColor = ThemeController.IceWhite,
                Font = new Font("Consolas", 16, FontStyle.Regular)
            };
            _comboBoxYear.Items.AddRange(GenerateYearsOfCard(15));
            _comboBoxYear.SelectedText = _card.DueDate.Year.ToString();
            _txtBoxCvv = new BunifuMaterialTextbox() 
            { 
                HintText = "Security code",
                Text = _card.SecurityNumber.ToString()
            };
            var buttonSaveAndExit = new Button()
            {
                Height = 40,
                Width = 500,
                Text = "Save and Exit",
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
            };
            buttonSaveAndExit.Click += ButtonSaveAndExit_Click;
            buttonSaveAndExit.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            buttonSaveAndExit.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;

            #region Controls
            Controls.Add(_txtBoxName);
            Controls.Add(_txtBoxOwnName);
            Controls.Add(labelCardNumber);
            Controls.Add(_txtBoxCardNumber);
            Controls.Add(labelDateCard);
            Controls.Add(_comboBoxMonth);
            Controls.Add(_comboBoxYear);
            Controls.Add(_txtBoxCvv);
            Controls.Add(buttonSaveAndExit);
            #endregion

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

            #region Layout Adjust
            Program.CentralizeControl(_txtBoxName, this);
            _txtBoxName.Location = new Point(_txtBoxName.Location.X, _txtBoxName.Location.Y - 150);
            Program.CentralizeControl(_txtBoxOwnName, this);
            _txtBoxOwnName.Location = new Point(_txtBoxOwnName.Location.X, _txtBoxOwnName.Location.Y - 95);
            Program.CentralizeControl(labelCardNumber, this);
            labelCardNumber.Location = new Point(labelCardNumber.Location.X - labelCardNumber.Width / 2, labelCardNumber.Location.Y - 40);
            Program.CentralizeControl(_txtBoxCardNumber, this);
            _txtBoxCardNumber.Location = new Point(_txtBoxCardNumber.Location.X + _txtBoxCardNumber.Width / 2, _txtBoxCardNumber.Location.Y - 40);
            Program.CentralizeControl(labelDateCard, this);
            labelDateCard.Location = new Point(labelDateCard.Location.X - labelDateCard.Width / 2,
                labelDateCard.Location.Y + 15);
            Program.CentralizeControl(_comboBoxMonth, this);
            _comboBoxMonth.Location = new Point(_comboBoxMonth.Location.X + _comboBoxMonth.Width / 2,
                _comboBoxMonth.Location.Y + 15);
            Program.CentralizeControl(_comboBoxYear, this);
            _comboBoxYear.Location = new Point(_comboBoxYear.Location.X + (_txtBoxOwnName.Width / 2)
                - (_comboBoxYear.Width / 2), _comboBoxYear.Location.Y + 15);
            Program.CentralizeControl(_txtBoxCvv, this);
            _txtBoxCvv.Location = new Point(_txtBoxCvv.Location.X, _txtBoxCvv.Location.Y + 70);
            Program.CentralizeControl(buttonSaveAndExit, this);
            buttonSaveAndExit.Location = new Point(buttonSaveAndExit.Location.X, buttonSaveAndExit.Location.Y + 125);
            #endregion

            #region Add Controls
            Controls.Add(panelTop);

            panelOberserve.Controls.Add(_buttonObserve);
            panelTop.Controls.Add(panelOberserve);
            panelTop.Controls.Add(nameLabel);
            #endregion
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Are you sure that you want to delete this card?", $"Deleting {_card.CardName}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (!dialog.Equals(DialogResult.Yes))
                return;

            OnCardDeleted?.Invoke(_card);
        }

        private void ButtonSaveAndExit_Click(object sender, EventArgs e)
        {
            var cardName = _txtBoxName.Text;
            var ownName = _txtBoxOwnName.Text;
            var cardNum = _txtBoxCardNumber.Text;
            var comboBoxMonth = _comboBoxMonth.Text;
            var comboBoxYear = _comboBoxYear.Text;
            var securityCode = _txtBoxCvv.Text;

            if (cardName.IsNullString() ||
                ownName.IsNullString() ||
                cardNum.IsNullString() ||
                comboBoxMonth.IsNullString() ||
                comboBoxYear.IsNullString() ||
                securityCode.IsNullString())
            {
                MessageBox.Show("All fields must be filled in to add a new card", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!ValidateCardNum(cardNum, out var newCardNum))
            {
                MessageBox.Show("The card number is invalid, please check and try again", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!ValidadeSecurityCode(securityCode) || !short.TryParse(securityCode, out var secNumber))
            {
                MessageBox.Show("The card's security code is invalid, check it and try again", "Invalid Security Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _card.CardName = cardName;
            _card.OwnrName = ownName;
            _card.Number = newCardNum;
            _card.DueDate = GetDateFromData(comboBoxMonth, comboBoxYear);
            _card.SecurityNumber = secNumber;

            if (_original.Equals(_card))
            {
                Dispose();
                return;
            }

            OnCardUpdated?.Invoke(_card);
        }

        private static bool ValidadeSecurityCode(string securityCode)
        {
            if (securityCode.Length > 4)
                return false;

            if (securityCode.Length < 3)
                return false;

            foreach (var c in securityCode)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        private static bool ValidateCardNum(string cardNum, out string newCardNum)
        {
            newCardNum = string.Empty;

            foreach (var c in cardNum.Where(c => char.IsDigit(c)))
                newCardNum += c;

            return newCardNum.Length == 16;
        }

        private static string[] GenerateYearsOfCard(int nextYears)
        {
            var result = new string[nextYears];
            var current = DateTime.Now.Year;

            for (var i = 0; i < nextYears; i++)
                result[i] = $"{current + i}";

            return result;
        }

        private static DateTime GetDateFromData(string comboBoxMonth, string comboBoxYear)
        {
            var month = int.Parse(comboBoxMonth.Split(')')[0]);
            var year = int.Parse(comboBoxYear);

            return new DateTime(year, month, 1);
        }

        private void ButtonDelete_MouseEnter(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.Trash_Openning_64px;

        private void ButtonDelete_MouseLeave(object sender, EventArgs e) => _buttonObserve.BackgroundImage = PRController.Images.Trash_64px;
    }
}