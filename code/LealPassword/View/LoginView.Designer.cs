using System.Windows.Forms;

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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeftContainer
            // 
            this.panelLeftContainer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelLeftContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftContainer.Location = new System.Drawing.Point(0, 0);
            this.panelLeftContainer.Name = "panelLeftContainer";
            this.panelLeftContainer.Size = new System.Drawing.Size(619, 741);
            this.panelLeftContainer.TabIndex = 0;
            this.panelLeftContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownControl);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(619, 32);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(645, 709);
            this.panelContainer.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(619, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(645, 32);
            this.panelTop.TabIndex = 2;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownControl);
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.Location = new System.Drawing.Point(570, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 32);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 741);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeftContainer);
            this.MaximumSize = new System.Drawing.Size(1280, 780);
            this.MinimumSize = new System.Drawing.Size(1280, 780);
            this.Name = "LoginView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LealPassword";
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelLeftContainer;
        private Panel panelContainer;
        private Panel panelTop;
        private Button buttonClose;
    }
}