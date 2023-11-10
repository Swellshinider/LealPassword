namespace LealPassword.UI.Extension
{
    internal sealed partial class ConfigPanel
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
            this.components = new System.ComponentModel.Container();
            this.panelRight = new System.Windows.Forms.Panel();
            this.switchButton = new Bunifu.Framework.UI.BunifuSwitch();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.lineSeparator = new Bunifu.Framework.UI.BunifuSeparator();
            this.panelTopSeparator = new System.Windows.Forms.Panel();
            this.panelBottomSeparator = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.labelDescription = new System.Windows.Forms.Label();
            this.panelRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.switchButton);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(525, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(75, 100);
            this.panelRight.TabIndex = 0;
            // 
            // switchButton
            // 
            this.switchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.switchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.switchButton.BorderRadius = 15;
            this.switchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.switchButton.Location = new System.Drawing.Point(11, 14);
            this.switchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.switchButton.Name = "switchButton";
            this.switchButton.Oncolor = System.Drawing.Color.Blue;
            this.switchButton.Onoffcolor = System.Drawing.Color.Gainsboro;
            this.switchButton.Size = new System.Drawing.Size(51, 19);
            this.switchButton.TabIndex = 1;
            this.switchButton.Textcolor = System.Drawing.Color.White;
            this.switchButton.Value = true;
            this.switchButton.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.lineSeparator);
            this.panel1.Controls.Add(this.panelTopSeparator);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 44);
            this.panel1.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(44, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(481, 28);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Configuration";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lineSeparator
            // 
            this.lineSeparator.BackColor = System.Drawing.Color.Transparent;
            this.lineSeparator.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.lineSeparator.LineThickness = 1;
            this.lineSeparator.Location = new System.Drawing.Point(44, 31);
            this.lineSeparator.Name = "lineSeparator";
            this.lineSeparator.Size = new System.Drawing.Size(175, 10);
            this.lineSeparator.TabIndex = 0;
            this.lineSeparator.Transparency = 255;
            this.lineSeparator.Vertical = false;
            // 
            // panelTopSeparator
            // 
            this.panelTopSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTopSeparator.Location = new System.Drawing.Point(0, 0);
            this.panelTopSeparator.Name = "panelTopSeparator";
            this.panelTopSeparator.Size = new System.Drawing.Size(44, 44);
            this.panelTopSeparator.TabIndex = 3;
            // 
            // panelBottomSeparator
            // 
            this.panelBottomSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomSeparator.Location = new System.Drawing.Point(0, 44);
            this.panelBottomSeparator.Name = "panelBottomSeparator";
            this.panelBottomSeparator.Size = new System.Drawing.Size(44, 56);
            this.panelBottomSeparator.TabIndex = 2;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // labelDescription
            // 
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(44, 44);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(481, 56);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Configuration description text";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.panelBottomSeparator);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRight);
            this.Name = "ConfigPanel";
            this.Size = new System.Drawing.Size(600, 100);
            this.panelRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private Bunifu.Framework.UI.BunifuSwitch switchButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTopSeparator;
        private System.Windows.Forms.Panel panelBottomSeparator;
        private Bunifu.Framework.UI.BunifuSeparator lineSeparator;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription;
    }
}