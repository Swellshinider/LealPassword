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

            var averagePower = AveragePasswordStrength();
            var passwordPanel = new PasswordStrPanel
            {
                ProgressBackColor = Color.GhostWhite,
                ProgressColor = GetColorByStrength(averagePower),
                Font = new Font("Nunito Sans", 14, FontStyle.Regular)
            };
            passwordPanel.SetValue(Program.RoundValue(averagePower));
            #endregion

            #region Add Controls
            Controls.Add(panelNoteTotal);
            Controls.Add(panelNoteRegister);
            Controls.Add(panelNoteCard);

            if (_account.Registers.Count > 0)
            {
                Controls.Add(categoryChart);
                Controls.Add(passwordPanel);
            }
            #endregion

            #region Adjust Position
            var yOffSet = 25;
            var xOffset = 25;
            Program.UpdateControlYAbsolute(panelNoteTotal, yOffSet);
            Program.UpdateControlXAbsolute(panelNoteTotal, xOffset);

            Program.UpdateControlYAbsolute(panelNoteRegister, yOffSet);
            Program.UpdateControlXAbsolute(panelNoteRegister, panelNoteTotal.Location.X + panelNoteTotal.Width + xOffset);

            Program.UpdateControlYAbsolute(panelNoteCard, yOffSet);
            Program.UpdateControlXAbsolute(panelNoteCard, panelNoteRegister.Location.X + panelNoteRegister.Width + xOffset);

            Program.UpdateControlYAbsolute(categoryChart, panelNoteTotal.Location.Y + panelNoteTotal.Height + yOffSet);
            Program.UpdateControlXAbsolute(categoryChart, xOffset);

            Program.UpdateControlYAbsolute(passwordPanel, panelNoteCard.Location.Y + panelNoteCard.Height + yOffSet);
            Program.UpdateControlXAbsolute(passwordPanel, categoryChart.Location.X + categoryChart.Width + xOffset);
            #endregion
        }

        internal Color GetColorByStrength(double strength)
        {
            if (strength >= 95)
                return Color.Blue;

            if (strength >= 80)
                return Color.Green;

            if (strength >= 50)
                return Color.Yellow;

            if (strength >= 30)
                return Color.Orange;

            return Color.Red;
        }

        internal double AveragePasswordStrength()
        {
            if (_account.Registers.Count <= 0)
                return 0;

            var total = 0;

            foreach(var register in _account.Registers)
                total += Security.Security.GetPasswordStrength(register.Password);

            return total / _account.Registers.Count;
        }
    }
}