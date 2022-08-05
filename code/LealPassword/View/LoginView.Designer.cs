namespace LealPassword.View
{
    internal sealed partial class LoginView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeftContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelLeftContainer
            // 
            this.panelLeftContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftContainer.Location = new System.Drawing.Point(0, 0);
            this.panelLeftContainer.Name = "panelLeftContainer";
            this.panelLeftContainer.Size = new System.Drawing.Size(262, 681);
            this.panelLeftContainer.TabIndex = 0;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelLeftContainer);
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LealPassword";
            this.Resize += new System.EventHandler(this.MainView_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelLeftContainer;
    }
}