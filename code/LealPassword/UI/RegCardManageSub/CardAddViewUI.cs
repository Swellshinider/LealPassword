using Bunifu.Framework.UI;
using LealPassword.Database.Model;
using LealPassword.Themes;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LealPassword.UI.RegCardManageSub
{
    internal sealed partial class CardAddViewUI : UserControl
    {
        internal delegate void CardsAdded(Card card);
        internal event CardsAdded OnAddedCards;

        private BunifuMaterialTextbox _txtBoxName;
        private BunifuMaterialTextbox _txtBoxOwnName;
        private BunifuMaterialTextbox _txtBoxCvv;
        private MaskedTextBox _txtBoxCardNumber;
        private ComboBox _comboBoxMonth;
        private ComboBox _comboBoxYear;

        internal CardAddViewUI(Control parent)
        {
            Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            var labelName = new Label()
            {
                Height = 50,
                Width = 250,
                AutoSize = false,
                Text = "Novo cartão",
                Font = new Font("Verdana", 21, FontStyle.Regular)
            };
            _txtBoxName = new BunifuMaterialTextbox() { HintText = "Nome do cartão" };
            _txtBoxOwnName = new BunifuMaterialTextbox() { HintText = "Dono do cartão" };
            var labelCardNumber = new Label()
            {
                Width = 250,
                Height = 40,
                AutoSize = false,
                Text = "Número do Cartão",
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Verdana", 14, FontStyle.Regular)
            };
            _txtBoxCardNumber = new MaskedTextBox()
            {
                Text = "",
                Height = 40,
                Width = 250,
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
                Text = "Data de validade",
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
                "01) Janeiro", "02) Fevereiro", "03) Março", "04) Abril", "05) Maio", "06) Junho",
                "07) Julho", "08) Agosto", "09) Setembro", "10) Outubro", "11) Novembro", "12) Dezembro"
            });
            _comboBoxYear = new ComboBox()
            {
                Text = "",
                Height = 40,
                Width = 75,
                ForeColor = ThemeController.LiteGray,
                BackColor = ThemeController.IceWhite,
                Font = new Font("Consolas", 16, FontStyle.Regular)
            };
            _comboBoxYear.Items.AddRange(new string[]
            {
                "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030",
                "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039"
            });
            _txtBoxCvv = new BunifuMaterialTextbox() { HintText = "Código de segurança" };
            var buttonCreate = new Button()
            {
                Height = 40,
                Width = 500,
                Text = "Criar",
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
            };
            buttonCreate.Click += ButtonCreate_Click;
            buttonCreate.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            buttonCreate.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;

            #region Controls
            Controls.Add(labelName);
            Controls.Add(_txtBoxName);
            Controls.Add(_txtBoxOwnName);
            Controls.Add(labelCardNumber);
            Controls.Add(_txtBoxCardNumber);
            Controls.Add(labelDateCard);
            Controls.Add(_comboBoxMonth);
            Controls.Add(_comboBoxYear);
            Controls.Add(_txtBoxCvv);
            Controls.Add(buttonCreate);
            #endregion

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

            #region Layout Adjust
            Program.CentralizeControl(labelName, this);
            labelName.Location = new Point(labelName.Location.X, labelName.Location.Y - 285);
            Program.CentralizeControl(_txtBoxName, this);
            _txtBoxName.Location = new Point(_txtBoxName.Location.X, _txtBoxName.Location.Y - 210);
            Program.CentralizeControl(_txtBoxOwnName, this);
            _txtBoxOwnName.Location = new Point(_txtBoxOwnName.Location.X, _txtBoxOwnName.Location.Y - 155);
            Program.CentralizeControl(labelCardNumber, this);
            labelCardNumber.Location = new Point(labelCardNumber.Location.X - labelCardNumber.Width / 2, labelCardNumber.Location.Y - 100);
            Program.CentralizeControl(_txtBoxCardNumber, this);
            _txtBoxCardNumber.Location = new Point(_txtBoxCardNumber.Location.X + _txtBoxCardNumber.Width / 2, _txtBoxCardNumber.Location.Y - 100);
            Program.CentralizeControl(labelDateCard, this);
            labelDateCard.Location = new Point(labelDateCard.Location.X - labelDateCard.Width / 2,
                labelDateCard.Location.Y - 45);
            Program.CentralizeControl(_comboBoxMonth, this);
            _comboBoxMonth.Location = new Point(_comboBoxMonth.Location.X + _comboBoxMonth.Width / 2,
                _comboBoxMonth.Location.Y - 45); 
            Program.CentralizeControl(_comboBoxYear, this);
            _comboBoxYear.Location = new Point(_comboBoxYear.Location.X + (_txtBoxOwnName.Width / 2)
                - (_comboBoxYear.Width / 2), _comboBoxYear.Location.Y - 45);
            Program.CentralizeControl(_txtBoxCvv, this);
            _txtBoxCvv.Location = new Point(_txtBoxCvv.Location.X, _txtBoxCvv.Location.Y + 10);
            Program.CentralizeControl(buttonCreate, this);
            buttonCreate.Location = new Point(buttonCreate.Location.X, buttonCreate.Location.Y + 65);
            #endregion
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var cardName = _txtBoxName.Text;
            var ownName = _txtBoxOwnName.Text;
            var cardNum = _txtBoxCardNumber.Text;
            var comboBoxMonth = _comboBoxMonth.Text;
            var comboBoxYear = _comboBoxYear.Text;
            var securityCode = _txtBoxCvv.Text;

            if (IsNotValid(cardName) || 
                IsNotValid(ownName) || 
                IsNotValid(cardNum) ||
                IsNotValid(comboBoxMonth) || 
                IsNotValid(comboBoxYear) || 
                IsNotValid(securityCode))
            {
                MessageBox.Show("Todos os valores devem ser preenchidos " +
                    "para adicionar um novo cartão", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!ValidateCardNum(cardNum, out var newCardNum))
            {
                MessageBox.Show("Número do cartão está inválido, verifique e tente novamente",
                    "Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OnAddedCards?.Invoke(new Card()
            {
                CardName = cardName,
                OwnrName = ownName,
                Number = newCardNum,
                DueDate = GetDateFromData(comboBoxMonth, comboBoxYear),
                SecurityNumber = short.Parse(securityCode),
            });
        }

        private bool ValidateCardNum(string cardNum, out string newCardNum)
        {
            newCardNum = string.Empty;

            foreach (var c in cardNum.Where(c => char.IsDigit(c)))
                newCardNum += c;

            return newCardNum.Length == 16;
        }

        private static DateTime GetDateFromData(string comboBoxMonth, string comboBoxYear)
        {
            var month = int.Parse(comboBoxMonth.Split(')')[0]);
            var year = int.Parse(comboBoxYear);

            return new DateTime(year, month, 1);
        }

        private static bool IsNotValid(string text)
            => string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text);
    }
}