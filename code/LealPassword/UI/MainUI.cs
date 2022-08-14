using Bunifu.Framework.UI;
using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.Diagnostics;
using LealPassword.Themes;
using LealPassword.UI.Extension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LealPassword.UI
{
    internal sealed partial class MainUI : Form
    {
        private readonly Account _account;
        private readonly string _masterpass;
        private readonly DiagnosticList _diagnostic;
        private readonly List<Control> _sideControls;
        private readonly List<SidePanel> _sideButtons;

        private bool isRegisterList = true;

        internal MainUI(DiagnosticList diagnostic, Account account, string masterpass)
        {
            InitializeComponent();
            Text = "LealPassword";
            _diagnostic = diagnostic;
            _account = account;
            _masterpass = masterpass;
            _sideControls = new List<Control>();
            _sideButtons = new List<SidePanel>();
            Width = Constants.BaseUISize.Width;
            Height = Constants.BaseUISize.Height;
            BackColor = ThemeController.SuperLiteGray;
            Resize += MainUI_Resize;
            BaseDefinition();
            GenerateObjects();
        }

        private void BaseDefinition()
        {
            _diagnostic.Debug("Initialize base definition");
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);
            _diagnostic.Debug("Base definition loaded");
        }

        private void GenerateObjects()
        {
            _diagnostic.Debug("Generating objects from MainUI");
            #region Container 
            var container = new Panel()
            {
                Name = "container",
                Dock = DockStyle.Fill,
                BackColor = ThemeController.SuperLiteGray,
            };
            Controls.Add(container);
            #endregion

            #region Panel Top Side
            var topSeparator = new Bunifu.Framework.UI.BunifuSeparator()
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
            btnClose.Region = Program.GenerateRoundRegion(btnClose.Width, btnClose.Height);
            #endregion

            #region Panel Left Side
            var panelLeft = new GradientPanel(ThemeController.BlueMain,
                ThemeController.IceWhite)
            {
                Dock = DockStyle.Left,
                Width = (int)(Width * 0.25f),
            };
            panelLeft.MouseDown += ControlMouseDown;
            Controls.Add(panelLeft);

            var leftSeparator = new Bunifu.Framework.UI.BunifuSeparator()
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
            var addNewRegisterButton = new Button()
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
            addNewRegisterButton.Click += AddNewRegisterButton_Click;
            panelTop.Controls.Add(addNewRegisterButton);
            addNewRegisterButton.FlatAppearance.MouseOverBackColor = ThemeController.SligBlue;
            addNewRegisterButton.FlatAppearance.MouseDownBackColor = ThemeController.LiteBlue;
            Program.CentralizeControl(addNewRegisterButton, panelTop);
            addNewRegisterButton.Location = new Point(addNewRegisterButton.Location.X - 
                (panelTop.Width / 2) + (addNewRegisterButton.Width / 2) + 25,
                addNewRegisterButton.Location.Y);
            addNewRegisterButton.Region = Program.GenerateRoundRegion(addNewRegisterButton.Width, addNewRegisterButton.Height, 15);
            #endregion

            #region Side Buttons
            var buttonGeneral = new SidePanel("Geral");
            _sideControls.Add(buttonGeneral);
            
            var labelTag = new Label()
            {
                Height = 40,
                AutoSize = false,
                Dock = DockStyle.Top,
                Text = "            Categorias",
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = ThemeController.SuperLiteGray,
                Font = new Font("Arial", 11, FontStyle.Regular),
            };
            _sideControls.Add(labelTag);

            var buttonCards = new SidePanel("Cartões");
            _sideControls.Add(buttonCards);
            #endregion

            #region Search box
            var searchBox = new BunifuMaterialTextbox()
            {
                Text = "",
                Height = 50,
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
            panelTop.Controls.Add(searchBox);
            searchBox.Font = new Font("Arial", 14, FontStyle.Regular);
            searchBox.Region = Program.GenerateRoundRegion(searchBox.Width, searchBox.Height, 20);
            searchBox.KeyDown += SearchBox_KeyDown;
            Program.CentralizeControl(searchBox, panelTop);
            #endregion

            foreach(var btns in _sideControls)
            {
                panelLeft.Controls.Add(btns);
                btns.BringToFront();
            }

            _diagnostic.Debug("Objects generated");
            searchBox.Width = (int)(panelTop.Width * 0.5f);
            searchBox.Height = 50;
            searchBox.TextAlign = HorizontalAlignment.Left;
            Program.CentralizeControl(searchBox, panelTop);
            searchBox.Region = Program.GenerateRoundRegion(searchBox.Width, searchBox.Height, 20);
            LoadRegisters();
        }

        private void LoadRegisters()
        {
            _diagnostic.Debug("Loading registers");

            _diagnostic.Debug("registers loaded");
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            var text = ((Bunifu.Framework.UI.BunifuMaterialTextbox)sender).Text;

            if (isRegisterList)
            {
                // TODO: search register
                return;
            }

            // TODO: search cards
        }

        private void AddNewRegisterButton_Click(object sender, EventArgs e)
        {
            // TODO: insert new register
        }

        #region Form methods
        private Panel GetContainer()
        {
            foreach(var ctrl in Controls)
                if (ctrl is Panel pnl && pnl.Name == "container")
                    return pnl;

            return null;
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Program.Exit();

        private void MainUI_Resize(object sender, EventArgs e)
            => Region = Program.GenerateRoundRegion(Width, Height);

        private void ControlMouseDown(object sender, MouseEventArgs e)
            => Program.ControlMouseDown(Handle, e);
        #endregion
    }
}
