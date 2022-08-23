using Bunifu.Framework.UI;
using LealPassword.Database.Controllers;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using LealPassword.UI.Extension;
using LealPassword.UI.GeneralSub;
using LealPassword.UI.RegCardManageSub;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI
{
    internal sealed partial class MainUI : Form
    {
        private readonly Panel _container;
        private readonly DiagnosticList _diagnostic;
        private readonly List<Control> _sideControls;

        private Account _account;
        private Button _addNewButton;
        private Control _activeControl;
        private SidePanel _buttonCards;
        private SidePanel _buttonConfig;
        private SidePanel _buttonGeneral;
        private SidePanel _buttonRegister;
        private BunifuMaterialTextbox _searchBox;

        internal MainUI(DiagnosticList diagnostic, Account account)
        {
            Text = "LealPassword";
            _container = new Panel() 
            {
                Dock = DockStyle.Fill,
                BackColor = ThemeController.SuperLiteGray,
            };
            _diagnostic = diagnostic;
            _account = account;
            _sideControls = new List<Control>();
            Width = Constants.BaseUISize.Width;
            Height = Constants.BaseUISize.Height;
            BackColor = ThemeController.SuperLiteGray;
            Resize += MainUI_Resize;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);
            StartPosition = FormStartPosition.CenterScreen;
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            _diagnostic.Debug("Generating objects from MainUI");
            Controls.Add(_container);

            #region Panel Top Side
            var topSeparator = new BunifuSeparator()
            {
                Height = 1,
                Dock = DockStyle.Top,
                LineColor = ThemeController.IceWhite,
            };
            Controls.Add(topSeparator);

            var panelTop = new Panel()
            {
                Dock = DockStyle.Top,
                Height = (int)(Height * 0.1f),
                BackColor = ThemeController.SuperLiteGray,
            };
            panelTop.MouseDown += ControlMouseDown;
            Controls.Add(panelTop);

            var btnMinimize = new Button()
            {
                Text = "",
                Width = 32,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                Image = PRController.Images.Minimize16px,
                ImageAlign = ContentAlignment.MiddleCenter,
            };
            btnMinimize.MaximumSize = new Size(btnMinimize.Width, btnMinimize.Width);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            btnMinimize.FlatAppearance.MouseDownBackColor = ThemeController.BlueMain;
            btnMinimize.Click += BtnMinimize_Click;
            panelTop.Controls.Add(btnMinimize);
            Program.CentralizeControl(btnMinimize, panelTop);

            var btnClose = new Button()
            {
                Text = "",
                Width = 32,
                Cursor = Cursors.Hand,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                Image = PRController.Images.Close16px,
                ImageAlign = ContentAlignment.MiddleCenter,
            };
            btnClose.MaximumSize = new Size(btnClose.Width, btnClose.Width);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = ThemeController.MouseOverCloseButton;
            btnClose.FlatAppearance.MouseDownBackColor = ThemeController.MouseDownCloseButton;
            btnClose.Click += BtnClose_Click;
            panelTop.Controls.Add(btnClose);
            Program.CentralizeControl(btnClose, panelTop);
            #endregion

            #region Panel Left Side
            var panelLeft = new GradientPanel(ThemeController.BlueMain, ThemeController.IceWhite)
            {
                Dock = DockStyle.Left,
                Width = (int)(Width * 0.25f),
            };
            panelLeft.MouseDown += ControlMouseDown;
            Controls.Add(panelLeft);

            var leftSeparator = new BunifuSeparator()
            {
                Height = 1,
                Dock = DockStyle.Top,
                LineColor = ThemeController.LineDarkBlue,
            };
            panelLeft.Controls.Add(leftSeparator);

            var panelLogo = new Panel()
            {
                BackColor = Color.Transparent,
                Height = panelTop.Height,
                Dock = DockStyle.Top,
            };
            panelLogo.MouseDown += ControlMouseDown;
            panelLeft.Controls.Add(panelLogo);

            var descPrgram = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Text = "Gerenciador de senhas",
                TextAlign = ContentAlignment.TopLeft,
                ForeColor = ThemeController.SuperLiteGray,
                Font = new Font("Times new Roman", 12, FontStyle.Italic),
            };
            descPrgram.MouseDown += ControlMouseDown;
            panelLogo.Controls.Add(descPrgram);

            var programName = new Label()
            {
                Text = "LealPassword",
                AutoSize = false,
                Dock = DockStyle.Top,
                ForeColor = ThemeController.SuperLiteGray,
                TextAlign = ContentAlignment.BottomLeft,
                Height = (int)(panelLogo.Height * 0.54f),
                Font = new Font("Verdana", 14, FontStyle.Bold),
            };
            programName.MouseDown += ControlMouseDown;
            panelLogo.Controls.Add(programName);

            var imageIcon = new Label()
            {
                Text = "",
                AutoSize = false,
                Dock = DockStyle.Left,
                // TODO: add icon
                Width = (int)(panelLogo.Width * 0.2f),
                ImageAlign = ContentAlignment.MiddleRight,
            };
            imageIcon.MouseDown += ControlMouseDown;
            panelLogo.Controls.Add(imageIcon);
            #endregion

            #region Top Add Button
            _addNewButton = new Button()
            {
                Height = 50,
                Width = 125,
                Text = "Novo",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                ForeColor = ThemeController.White,
                BackColor = ThemeController.BlueMain,
                Font = new Font("Arial", 12, FontStyle.Regular),
            };
            _addNewButton.Click += AddNewButton_Click;
            panelTop.Controls.Add(_addNewButton);
            _addNewButton.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            _addNewButton.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;
            Program.CentralizeControl(_addNewButton, panelTop);
            _addNewButton.Location = new Point(_addNewButton.Location.X - 
                (panelTop.Width / 2) + (_addNewButton.Width / 2) + 25,
                _addNewButton.Location.Y);
            _addNewButton.Region = Program.GenerateRoundRegion(_addNewButton.Width, _addNewButton.Height, 15);
            #endregion

            #region Side Buttons
            var labelTag = new Label()
            {
                Height = 50,
                AutoSize = false,
                Dock = DockStyle.Top,
                Text = "        Menu",
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = ThemeController.SuperLiteGray,
                Font = new Font("Arial", 11, FontStyle.Regular),
            };
            _sideControls.Add(labelTag);

            _buttonGeneral = new SidePanel("Geral", PRController.Images.General127px);
            _buttonGeneral.Click += ButtonGeneral_Click;
            _sideControls.Add(_buttonGeneral);

            _buttonRegister = new SidePanel("Registros", PRController.Images.Registers127px);
            _buttonRegister.Click += ButtonRegisters_Click;
            _sideControls.Add(_buttonRegister);

            _buttonCards = new SidePanel("Cartões", PRController.Images.Cards127px);
            _buttonCards.Click += ButtonCards_Click;
            _sideControls.Add(_buttonCards);

            _buttonConfig = new SidePanel("Configurações", PRController.Images.Config127px_Black)
            {
                Dock = DockStyle.Bottom,
                Textcolor = ThemeController.Black
            };
            _buttonConfig.Click += ButtonConfig_Click;
            _sideControls.Add(_buttonConfig);
            #endregion

            #region Search box
            _searchBox = new BunifuMaterialTextbox()
            {
                Text = "",
                Height = 50,
                Visible = false,
                HintText = "Buscar",
                BorderStyle = BorderStyle.None,
                Width = (int)(panelTop.Width * 0.5f),
                ForeColor = ThemeController.LiteGray,
                BackColor = ThemeController.IceWhite,
                HintForeColor = ThemeController.LiteGray,
                LineIdleColor = ThemeController.IceWhite,
                LineFocusedColor = ThemeController.IceWhite,
                LineMouseHoverColor = ThemeController.IceWhite,
            };
            panelTop.Controls.Add(_searchBox);
            _searchBox.Font = new Font("Arial", 14, FontStyle.Regular);
            _searchBox.Region = Program.GenerateRoundRegion(_searchBox.Width, _searchBox.Height, 20);
            _searchBox.KeyDown += SearchBox_KeyDown;
            Program.CentralizeControl(_searchBox, panelTop);
            #endregion

            foreach(var btns in _sideControls)
            {
                panelLeft.Controls.Add(btns);
                btns.BringToFront();
            }

            _diagnostic.Debug("Objects generated");
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            var text = ((BunifuMaterialTextbox)sender).Text;

            if (_activeControl is RegistersViewUI regViewUI)
                regViewUI.Filter(text);
            else if (_activeControl is CardViewUI cardViewUI)
                cardViewUI.Filter(text);
        }

        #region Side Buttons
        private void ButtonGeneral_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("General button click");
            ButtonHighLight((SidePanel)sender);
            _searchBox.Visible = false;
            _activeControl = new GeneralInfosUI(_account, _container);
        }

        private void ButtonRegisters_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Register button click");
            ButtonHighLight((SidePanel)sender);
            _searchBox.Visible = true;
            _activeControl = new RegistersViewUI(_account.Registers, _container);
        }

        private void ButtonCards_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Cards button click");
            ButtonHighLight((SidePanel)sender);
            _searchBox.Visible = true;
            _activeControl = new CardViewUI(_account.Cards, _container);
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Config button click");
            ButtonHighLight((SidePanel)sender);
            _searchBox.Visible = false;
            // TODO: add configuration loaded
        }
        #endregion

        #region Button add new 
        private void AddNewButton_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Add button click");
            var chooseUI = new ChooseRegistersCardsUI(_container);
            chooseUI.OnChooseCards += ChooseUI_OnChooseCards;
            chooseUI.OnChooseRegister += ChooseUI_OnChooseRegister;
        }

        private void ChooseUI_OnChooseRegister()
        {
            _diagnostic.Debug("Button add registers click");
            var newRegUI = new RegistersAddViewUI(_account.Registers, _container);
            newRegUI.OnAddedRegisters += NewRegUI_OnAddedRegisters;
        }

        private void ChooseUI_OnChooseCards()
        {
            _diagnostic.Debug("Button add cards click");
            var newCardUI = new CardAddViewUI(_container);
            newCardUI.OnAddedCards += NewCardUI_OnAddedCards;
        }

        private void NewCardUI_OnAddedCards(Card card)
        {
            var cardController = new CardController(Constants.DEFAULT_DATABASE_PATH, Constants.DEFAULT_DATABASE_FILE);
            cardController.InsertCard(card);
            _diagnostic.Debug($"New card('{card.CardName}') inserted");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH, Constants.DEFAULT_DATABASE_FILE);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            ButtonHighLight();
            _container.Controls.Clear();
        }

        private void NewRegUI_OnAddedRegisters(Register register)
        {
            var regController = new RegisterController(Constants.DEFAULT_DATABASE_PATH, Constants.DEFAULT_DATABASE_FILE);
            regController.InsertRegister(register);
            _diagnostic.Debug($"New register('{register.Name}') inserted");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH, Constants.DEFAULT_DATABASE_FILE);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            ButtonHighLight();
            _container.Controls.Clear();
        }
        #endregion

        #region Form methods
        private void ButtonHighLight(SidePanel current = null)
        {
            _diagnostic.Debug("SidePanel clicked");

            _buttonGeneral.Normalcolor = Color.Transparent;
            _buttonRegister.Normalcolor = Color.Transparent;
            _buttonCards.Normalcolor = Color.Transparent;
            _buttonConfig.Normalcolor = Color.Transparent;

            if (current != null)
                current.Normalcolor = current.Activecolor;
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
            => WindowState = FormWindowState.Minimized;

        private void BtnClose_Click(object sender, EventArgs e)
            => Program.Exit();

        private void MainUI_Resize(object sender, EventArgs e)
            => Region = Program.GenerateRoundRegion(Width, Height);

        private void ControlMouseDown(object sender, MouseEventArgs e)
            => Program.ControlMouseDown(Handle, e);
        #endregion
    }
}