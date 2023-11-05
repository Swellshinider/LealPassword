namespace LealPassword.UI.Extension
{
    internal sealed partial class NoteCardPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelValue = new System.Windows.Forms.Panel();
            this.labelText = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.panelIcon = new System.Windows.Forms.Panel();
            this.panelRight.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelIcon);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(250, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(100, 80);
            this.panelRight.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelText);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(250, 32);
            this.panelTop.TabIndex = 1;
            // 
            // panelValue
            // 
            this.panelValue.Controls.Add(this.labelValue);
            this.panelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelValue.Location = new System.Drawing.Point(0, 32);
            this.panelValue.Name = "panelValue";
            this.panelValue.Size = new System.Drawing.Size(250, 48);
            this.panelValue.TabIndex = 2;
            // 
            // labelText
            // 
            this.labelText.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelText.Location = new System.Drawing.Point(20, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(230, 32);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "TITLE";
            this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelValue
            // 
            this.labelValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelValue.Location = new System.Drawing.Point(20, 0);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(230, 48);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "VALUE";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelIcon
            // 
            this.panelIcon.Location = new System.Drawing.Point(30, 18);
            this.panelIcon.Name = "panelIcon";
            this.panelIcon.Size = new System.Drawing.Size(40, 40);
            this.panelIcon.TabIndex = 0;
            // 
            // NoteCardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelValue);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelRight);
            this.Name = "NoteCardPanel";
            this.Size = new System.Drawing.Size(350, 80);
            this.panelRight.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelValue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelValue;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Panel panelIcon;
    }
}
