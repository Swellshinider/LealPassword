using LealPassword.Definitions;
using LealPassword.Themes;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.Popup
{
    internal sealed partial class IconChooserPopup : Form
    {
        internal delegate void IconChosen(Image image, IconChooserPopup popup);
        internal event IconChosen OnIconChosen;

        internal IconChooserPopup(Control parent)
        {
            TopLevel = false;
            TopMost = false;
            Parent = parent;
            ShowInTaskbar = false;
            InitializeComponent();
            GenerateObjectsAndImages();
            BackColor = ThemeController.SuperLiteGray;
            Program.CentralizeControl(this, parent);
        }

        private void GenerateObjectsAndImages()
        {
            var panelContainers = new Panel()
            {
                Width = Width,
                Height = 512,
                AutoScroll = true,
                Dock = DockStyle.Left,
            };
            panelContainers.HorizontalScroll.Visible = false;
            Controls.Add(panelContainers);

            var images = PRController.IconsList;
            var counter = 0;
            var line = 0;

            for (var i = 0; i < images.Count; i++)
            {
                var image = images[i];
                line = i % 8 == 0 ? line + 1 : line;

                if (counter > 7) counter = 0;

                var x = counter * 64;
                var y = (line - 1) * 64;

                counter++;

                var buttons = new Button()
                {
                    Text = "",
                    Width = 64,
                    Height = 64,
                    BackgroundImage = image,
                    BackgroundImageLayout = ImageLayout.Center,
                    Location = new Point(x, y),
                    FlatStyle = FlatStyle.Flat,
                    MinimumSize = new Size(64, 64),
                    ImageAlign = ContentAlignment.MiddleCenter,
                };
                buttons.FlatAppearance.BorderSize = 0;
                buttons.Click += (s, e) => OnIconChosen?.Invoke(image, this);
                panelContainers.Controls.Add(buttons);
            }
        }
    }
}