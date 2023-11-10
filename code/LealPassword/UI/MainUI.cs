using Bunifu.Framework.UI;
using LealPassword.Database.Controllers;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using LealPassword.UI.EditComponentSub;
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

        private SidePanel _buttonBackup;
        private SidePanel _buttonCrypto;
        private SidePanel _buttonAbout;

        private BunifuMaterialTextbox _searchBox;

        internal MainUI(DiagnosticList diagnostic, Account account)
        {
            InitializeComponent();
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
            Icon = PRController.LealPassword_Icon;
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
                Dock = DockStyle.Top,
                Height = panelTop.Height,
                BackColor = Color.Transparent
            };
            panelLogo.MouseDown += ControlMouseDown;
            panelLeft.Controls.Add(panelLogo);

            var descPrgram = new Label()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Text = "Password management",
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

            var panelSpacing1 = new Panel()
            {
                Dock = DockStyle.Left,
                Width = 15,
            };
            panelSpacing1.MouseDown += ControlMouseDown;
            panelLogo.Controls.Add(panelSpacing1);

            var imageIcon = new Panel()
            {
                Dock = DockStyle.Left,
                Width = (int)(panelLogo.Width * 0.2f),
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = PRController.Images.LealPasswordLogo128px
            };
            imageIcon.MouseDown += ControlMouseDown;
            panelLogo.Controls.Add(imageIcon);

            var panelSpacing2 = new Panel()
            {
                Dock = DockStyle.Left,
                Width = 15,
            };
            panelSpacing2.MouseDown += ControlMouseDown;
            panelLogo.Controls.Add(panelSpacing2);
            #endregion

            #region Top Add Button
            _addNewButton = new Button()
            {
                Height = 50,
                Width = 125,
                Text = "Add New",
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
            // Menu
            var labelTagMenu = new Label()
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
            _sideControls.Add(labelTagMenu);

            _buttonGeneral = new SidePanel("Menu", PRController.Images.General127px);
            _buttonGeneral.Click += ButtonGeneral_Click;
            _sideControls.Add(_buttonGeneral);

            _buttonRegister = new SidePanel("Registers", PRController.Images.Registers127px);
            _buttonRegister.Click += ButtonRegisters_Click;
            _sideControls.Add(_buttonRegister);

            _buttonCards = new SidePanel("Cards", PRController.Images.Cards127px);
            _buttonCards.Click += ButtonCards_Click;
            _sideControls.Add(_buttonCards);

            _buttonConfig = new SidePanel("Configurations", PRController.Images.Config127px_Black)
            {
                Dock = DockStyle.Bottom,
                Textcolor = ThemeController.Black
            };
            _buttonConfig.Click += ButtonConfig_Click;
            _sideControls.Add(_buttonConfig);

            // Extra
            var labelTagExtra = new Label()
            {
                Height = 50,
                AutoSize = false,
                Dock = DockStyle.Top,
                Text = "        Extra",
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = ThemeController.SuperLiteGray,
                Font = new Font("Arial", 11, FontStyle.Regular),
            };
            //_sideControls.Add(labelTagExtra);

            _buttonBackup = new SidePanel("Backup", PRController.Images.DataBaseBackup_127px);
            _buttonBackup.Click += ButtonBackup_Click;
            //_sideControls.Add(_buttonBackup);

            _buttonCrypto = new SidePanel("Cryptography", PRController.Images.ScriptKey_127px);
            _buttonCrypto.Click += ButtonCrypto_Click;
            //_sideControls.Add(_buttonCrypto);

            _buttonAbout = new SidePanel("About", PRController.Images.About127px);
            _buttonAbout.Click += ButtonAbout_Click;
            //_sideControls.Add(_buttonAbout);
            #endregion

            #region Search box
            _searchBox = new BunifuMaterialTextbox()
            {
                Text = "",
                Height = 50,
                Visible = false,
                HintText = "Search",
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
            _searchBox.OnValueChanged += SearchBox_ValueChanged;
            Program.CentralizeControl(_searchBox, panelTop);
            #endregion

            #region Notify Icon
            _notifyIcon.Text = Text;
            _notifyIcon.Icon = Icon;
            _notifyIcon.Visible = true;
            _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            _notifyIcon.BalloonTipTitle = Text;
            _notifyIcon.BalloonTipText = "Heyy, I'll keep it open in the system tray!!";

            var contextMenu = new ContextMenu();
            var openMenu = new MenuItem("Open", Notify_Open);
            var closeMenu = new MenuItem("Close", Notify_Close);

            contextMenu.MenuItems.Add(openMenu);
            contextMenu.MenuItems.Add(closeMenu);

            _notifyIcon.ContextMenu = contextMenu;
            #endregion

            foreach (var btns in _sideControls)
            {
                panelLeft.Controls.Add(btns);
                btns.BringToFront();
            }

            _diagnostic.Debug("Objects generated");
            Clear();
        }

        private void Clear()
        {
            _diagnostic.Debug("Controls cleared");
            _container.Controls.Clear();
            ButtonGeneral_Click(_buttonGeneral, new EventArgs());
        }

        private void SearchBox_ValueChanged(object sender, EventArgs e)
        {
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
            _searchBox.Visible = true;
            ButtonHighLight((SidePanel)sender);
            var regUI = new RegistersViewUI(_account.Registers, _container);
            regUI.OnSeeMe += RegisterUI_OnSeeMe;
            _activeControl = regUI;
        }

        private void ButtonCards_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Cards button click");
            _searchBox.Visible = true;
            ButtonHighLight((SidePanel)sender);
            var cardUI = new CardViewUI(_account.Cards, _container);
            cardUI.OnSeeMe += CardUI_OnSeeMe;
            _activeControl = cardUI;
        }

        private void ButtonBackup_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Backup button click");
            _searchBox.Visible = false;
            ButtonHighLight((SidePanel)sender);
            // TODO: add backup loaded
        }

        private void ButtonCrypto_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Cripto button click");
            _searchBox.Visible = false;
            ButtonHighLight((SidePanel)sender);
            // TODO: add cripto loaded
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("About button click");
            _searchBox.Visible = false;
            ButtonHighLight((SidePanel)sender);
            // TODO: add about loaded
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            _diagnostic.Debug("Config button click");
            _searchBox.Visible = false;
            ButtonHighLight((SidePanel)sender);
            _activeControl = new ConfigurationUI(_account, _container);
        }
        #endregion

        #region Cards/Register methods
        private void CardUI_OnSeeMe(Card card)
        {
            _diagnostic.Debug("CardUI_OnSeeMe");
            ButtonHighLight(_buttonCards);
            _searchBox.Visible = false;
            var viewCardUI = new ViewCardUI(card, _container);
            viewCardUI.Disposed += ViewCard_Disposed;
            viewCardUI.OnCardUpdated += ViewCardUI_OnCardUpdated;
            viewCardUI.OnCardDeleted += ViewCardUI_OnCardDeleted;

            _activeControl = viewCardUI;
        }

        private void ViewCardUI_OnCardUpdated(Card card)
        {
            var cardController = new CardController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            cardController.UpdateCard(card);
            _diagnostic.Debug($"Updating card('{card.CardName}')");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            Clear();
            ButtonCards_Click(_buttonCards, null);
        }

        private void ViewCardUI_OnCardDeleted(Card card)
        {
            var cardController = new CardController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            cardController.DeleteCard(card);
            _diagnostic.Debug($"Deleting card('{card.CardName}')");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            Clear();
            ButtonCards_Click(_buttonCards, null);
        }

        private void RegisterUI_OnSeeMe(Register register)
        {
            _diagnostic.Debug("RegisterUI_OnSeeMe");
            ButtonHighLight(_buttonRegister);
            _searchBox.Visible = false;
            var viewRegisterUI = new ViewRegisterUI(_account.Registers, register, _container);
            viewRegisterUI.Disposed += ViewRegister_Disposed;
            viewRegisterUI.OnCardUpdated += ViewRegisterUI_OnRegisterUpdated;
            viewRegisterUI.OnCardDeleted += ViewRegisterUI_OnRegisterDeleted;

            _activeControl = viewRegisterUI;
        }

        private void ViewRegisterUI_OnRegisterUpdated(Register register)
        {
            var regController = new RegisterController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            regController.UpdateRegister(register);
            _diagnostic.Debug($"Updating register('{register.Name}')");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            Clear();
            ButtonRegisters_Click(_buttonRegister, null);
        }

        private void ViewRegisterUI_OnRegisterDeleted(Register register)
        {
            var regController = new RegisterController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            regController.DeleteRegister(register);
            _diagnostic.Debug($"Deleting register('{register.Name}')");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH,
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            Clear();
            ButtonRegisters_Click(_buttonRegister, null);
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
            var cardController = new CardController(Constants.DEFAULT_DATABASE_PATH, 
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            cardController.InsertCard(card);
            _diagnostic.Debug($"New card('{card.CardName}') inserted");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH, 
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            Clear();
        }

        private void NewRegUI_OnAddedRegisters(Register register)
        {
            var regController = new RegisterController(Constants.DEFAULT_DATABASE_PATH, 
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            regController.InsertRegister(register);
            _diagnostic.Debug($"New register('{register.Name}') inserted");

            var accountController = new AccountController(Constants.DEFAULT_DATABASE_PATH, 
                Constants.DEFAULT_DATABASE_FILE, _account.Password);
            _account = accountController.GetAccount(_account.Username);
            _diagnostic.Debug("New account pushed");

            Clear();
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
            _buttonBackup.Normalcolor = Color.Transparent;
            _buttonCrypto.Normalcolor = Color.Transparent;
            _buttonAbout.Normalcolor = Color.Transparent;

            if (current != null)
                current.Normalcolor = current.Activecolor;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (!PRController.CloseToSystemTray)
            {
                Program.Exit();
                return;
            }
            _notifyIcon.Visible = true;
            _notifyIcon.ShowBalloonTip(1000);
            Hide();
        }

        private void BtnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void ControlMouseDown(object sender, MouseEventArgs e) => Program.ControlMouseDown(Handle, e);

        private void MainUI_Resize(object sender, EventArgs e) => Region = Program.GenerateRoundRegion(Width, Height);

        private void ViewCard_Disposed(object sender, EventArgs e) => ButtonCards_Click(_buttonCards, null);

        private void ViewRegister_Disposed(object sender, EventArgs e) => ButtonRegisters_Click(_buttonRegister, null);
        #endregion

        #region Notify methods
        private void Notify_Open(object sender, EventArgs e)
        {
            Show();
            _notifyIcon.Visible = false;
        }

        private void Notify_Close(object sender, EventArgs e) => Program.Exit();
        #endregion
    }
}