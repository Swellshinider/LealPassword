using LealPassword.Database.Model;
using LealPassword.Definitions;
using LealPassword.UI.Extension;
using System.Windows.Forms;

namespace LealPassword.UI.GeneralSub
{
    internal sealed partial class ConfigurationUI : UserControl
    {
        private readonly Account _account;

        private ConfigPanel _panelSaveUser;
        private ConfigPanel _panelSavePassword;
        private ConfigPanel _panelAutoLogin;
        private ConfigPanel _panelCloseAction;

        internal ConfigurationUI(Account account, Control parent)
        {
            _account = account;
            Dock = DockStyle.Fill;
            parent.Controls.Clear();
            parent.Controls.Add(this);
            GenerateObjects();
        }

        private void GenerateObjects()
        {
            _panelSaveUser = new ConfigPanel();
            _panelSaveUser.OnSwitch += PanelSaveUser_OnSwitch;
            _panelSaveUser.LoadObjects("Username Autocompletion", "By enabling this option, " +
                "your username will be automatically populated the next time you enter.", PRController.AutoCompleteUser);

            _panelSavePassword = new ConfigPanel();
            _panelSavePassword.OnSwitch += PanelSavePassword_OnSwitch;
            _panelSavePassword.LoadObjects("Password Autocompletion", "By enabling this option, " +
                "your password will be automatically populated the next time you enter.", PRController.AutoCompletePassword);

            _panelAutoLogin = new ConfigPanel();
            _panelAutoLogin.OnSwitch += PanelAutoLogin_OnSwitch;
            _panelAutoLogin.LoadObjects("Automatic Login", "When you activate this option, the next time you enter the LealPassword, " +
                "you won't need to manually enter your credentials; the login will occur automatically.", PRController.AutoLogin);

            _panelCloseAction = new ConfigPanel();
            _panelCloseAction.OnSwitch += PanelCloseAction_OnSwitch;
            _panelCloseAction.LoadObjects("Close to System Tray", "By enabling this option, to transfer the application to the system tray upon closure. This configuration ensures that when you close the application, it discreetly resides in the system tray, allowing for quick access and convenient background operation.", PRController.CloseToSystemTray);

            #region Add Controls
            Controls.Add(_panelSaveUser);
            Controls.Add(_panelSavePassword);
            Controls.Add(_panelAutoLogin);
            Controls.Add(_panelCloseAction);
            #endregion

            #region Ajust Time And Position
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is ConfigPanel configPanel)
                {
                    configPanel.Width = Program.RoundValue(Width - (Width * 0.1));
                    Program.HorizontalCentralize(configPanel, this);

                    if (i == 0)
                        Program.UpdateControlYAbsolute(configPanel, Program.RoundValue(Height * 0.05));
                    else 
                        Program.UpdateControlYOffSetNext(configPanel, Controls[i - 1], Program.RoundValue(Height * 0.05));
                }
            }
            #endregion
        }

        private void PanelSaveUser_OnSwitch(bool value)
        {
            if (!value && PRController.AutoLogin)
            {
                _panelSaveUser.SetValue(PRController.AutoLogin);
                MessageBox.Show("You cannot disable 'Username Autocompletion' while 'Automatic Login' is active", "Invalid Action", MessageBoxButtons.OK);
                return;
            }
            PRController.AutoCompleteUser = value;
            PRController.LastUser = value ? _account.Username : "";
        }

        private void PanelSavePassword_OnSwitch(bool value)
        {
            if (!value && PRController.AutoLogin)
            {
                _panelSavePassword.SetValue(PRController.AutoLogin);
                MessageBox.Show("You cannot disable 'Password Autocompletion' while 'Automatic Login' is active", "Invalid Action", MessageBoxButtons.OK);
                return;
            }
            PRController.AutoCompletePassword = value;
            PRController.LastPassword = value ? _account.Password : "";
        }

        private void PanelAutoLogin_OnSwitch(bool value)
        {
            PRController.AutoLogin = value;

            if (value)
            {
                _panelSaveUser.SetValue(value);
                _panelSavePassword.SetValue(value);
            }
        }

        private void PanelCloseAction_OnSwitch(bool value)
        {
            PRController.CloseToSystemTray = value;
        }
    }
}