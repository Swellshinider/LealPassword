using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.UI.Extension;
using System.Drawing;
using System.Windows.Forms;

namespace LealPassword.UI.GeneralSub
{
    internal sealed partial class GeneralInfosUI : UserControl
    {
        private readonly Account _account;

        internal GeneralInfosUI(Account account, Control parent)
        {
            _account = account;
            Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            #region Total Cards
            var panelNoteTotal = new NoteCardPanel
            {
                Width = 300,
                Height = 80
            };
            panelNoteTotal.LoadObjects("Total", (Color.SlateGray, _account.Registers.Count + _account.Cards.Count), PRController.Images.CubeBlack127px);

            var panelNoteRegister = new NoteCardPanel
            {
                Width = 280,
                Height = 80
            };
            panelNoteRegister.LoadObjects("Registers", (Color.CornflowerBlue, _account.Registers.Count), PRController.Images.RegisterBlack256px);

            var panelNoteCard = new NoteCardPanel
            {
                Width = 280,
                Height = 80
            };
            panelNoteCard.LoadObjects("Cards", (Color.LawnGreen, _account.Cards.Count), PRController.Images.CardsBlack256px);
            #endregion

            #region Chart
            var categoryChart = new CategoryDistPanel();
            categoryChart.LoadObjects(new Font("Nunito Sans", 14, FontStyle.Regular), _account.Registers);

            var passwordPanel = new PasswordStrPanel();
            passwordPanel.LoadObjects(new Font("Nunito Sans", 14, FontStyle.Regular), _account.Registers);
            #endregion

            #region Add Controls
            Controls.Add(panelNoteTotal);
            Controls.Add(panelNoteRegister);
            Controls.Add(panelNoteCard);

            Controls.Add(categoryChart);
            Controls.Add(passwordPanel);
            #endregion

            #region Adjust Position
            var spacing = 25;
            Program.UpdateControlYAbsolute(panelNoteTotal, spacing);
            Program.UpdateControlXAbsolute(panelNoteTotal, spacing);

            Program.UpdateControlYAbsolute(panelNoteRegister, spacing);
            Program.UpdateControlXAbsolute(panelNoteRegister, panelNoteTotal.Location.X + panelNoteTotal.Width + spacing);

            Program.UpdateControlYAbsolute(panelNoteCard, spacing);
            Program.UpdateControlXAbsolute(panelNoteCard, panelNoteRegister.Location.X + panelNoteRegister.Width + spacing);

            Program.UpdateControlYAbsolute(categoryChart, panelNoteTotal.Location.Y + panelNoteTotal.Height + spacing);
            Program.UpdateControlXAbsolute(categoryChart, spacing);

            Program.UpdateControlYAbsolute(passwordPanel, panelNoteCard.Location.Y + panelNoteCard.Height + spacing);
            Program.UpdateControlXAbsolute(passwordPanel, categoryChart.Location.X + categoryChart.Width + spacing);
            #endregion
        }
    }
}