namespace LealPassword.UI.Extension
{
    internal sealed partial class PasswordStrPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordStrPanel));
            this.panelTop = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.labelTitle = new System.Windows.Forms.Label();
            this.circularProgressBarr = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.labelSuperb = new System.Windows.Forms.Label();
            this.labelFair = new System.Windows.Forms.Label();
            this.panelColor4 = new System.Windows.Forms.Panel();
            this.labelGood = new System.Windows.Forms.Label();
            this.panelColor2 = new System.Windows.Forms.Panel();
            this.panelColor3 = new System.Windows.Forms.Panel();
            this.labelPoor = new System.Windows.Forms.Label();
            this.panelColor1 = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.bunifuSeparator1);
            this.panelTop.Controls.Add(this.labelTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(345, 58);
            this.panelTop.TabIndex = 1;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(45, 44);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(140, 11);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // labelTitle
            // 
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(42, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Password Score";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // circularProgressBarr
            // 
            this.circularProgressBarr.animated = false;
            this.circularProgressBarr.animationIterval = 1;
            this.circularProgressBarr.animationSpeed = 50;
            this.circularProgressBarr.BackColor = System.Drawing.Color.White;
            this.circularProgressBarr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circularProgressBarr.BackgroundImage")));
            this.circularProgressBarr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.circularProgressBarr.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBarr.ForeColor = System.Drawing.Color.SeaGreen;
            this.circularProgressBarr.LabelVisible = true;
            this.circularProgressBarr.LineProgressThickness = 15;
            this.circularProgressBarr.LineThickness = 15;
            this.circularProgressBarr.Location = new System.Drawing.Point(45, 74);
            this.circularProgressBarr.Margin = new System.Windows.Forms.Padding(0);
            this.circularProgressBarr.MaxValue = 100;
            this.circularProgressBarr.Name = "circularProgressBarr";
            this.circularProgressBarr.ProgressBackColor = System.Drawing.Color.WhiteSmoke;
            this.circularProgressBarr.ProgressColor = System.Drawing.Color.SeaGreen;
            this.circularProgressBarr.Size = new System.Drawing.Size(250, 250);
            this.circularProgressBarr.TabIndex = 2;
            this.circularProgressBarr.Value = 50;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.labelSuperb);
            this.panelBottom.Controls.Add(this.labelFair);
            this.panelBottom.Controls.Add(this.panelColor4);
            this.panelBottom.Controls.Add(this.labelGood);
            this.panelBottom.Controls.Add(this.panelColor2);
            this.panelBottom.Controls.Add(this.panelColor3);
            this.panelBottom.Controls.Add(this.labelPoor);
            this.panelBottom.Controls.Add(this.panelColor1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 358);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(345, 75);
            this.panelBottom.TabIndex = 3;
            // 
            // labelSuperb
            // 
            this.labelSuperb.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSuperb.Location = new System.Drawing.Point(287, 21);
            this.labelSuperb.Name = "labelSuperb";
            this.labelSuperb.Size = new System.Drawing.Size(55, 37);
            this.labelSuperb.TabIndex = 9;
            this.labelSuperb.Text = "Superb";
            this.labelSuperb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFair
            // 
            this.labelFair.BackColor = System.Drawing.Color.Transparent;
            this.labelFair.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFair.Location = new System.Drawing.Point(132, 21);
            this.labelFair.Name = "labelFair";
            this.labelFair.Size = new System.Drawing.Size(29, 37);
            this.labelFair.TabIndex = 5;
            this.labelFair.Text = "Fair";
            this.labelFair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelColor4
            // 
            this.panelColor4.Location = new System.Drawing.Point(251, 33);
            this.panelColor4.Name = "panelColor4";
            this.panelColor4.Size = new System.Drawing.Size(30, 15);
            this.panelColor4.TabIndex = 10;
            // 
            // labelGood
            // 
            this.labelGood.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGood.Location = new System.Drawing.Point(203, 21);
            this.labelGood.Name = "labelGood";
            this.labelGood.Size = new System.Drawing.Size(42, 37);
            this.labelGood.TabIndex = 7;
            this.labelGood.Text = "Good";
            this.labelGood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelColor2
            // 
            this.panelColor2.Location = new System.Drawing.Point(96, 33);
            this.panelColor2.Name = "panelColor2";
            this.panelColor2.Size = new System.Drawing.Size(30, 15);
            this.panelColor2.TabIndex = 6;
            // 
            // panelColor3
            // 
            this.panelColor3.Location = new System.Drawing.Point(167, 33);
            this.panelColor3.Name = "panelColor3";
            this.panelColor3.Size = new System.Drawing.Size(30, 15);
            this.panelColor3.TabIndex = 8;
            // 
            // labelPoor
            // 
            this.labelPoor.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoor.Location = new System.Drawing.Point(53, 21);
            this.labelPoor.Name = "labelPoor";
            this.labelPoor.Size = new System.Drawing.Size(37, 37);
            this.labelPoor.TabIndex = 0;
            this.labelPoor.Text = "Poor";
            this.labelPoor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelColor1
            // 
            this.panelColor1.Location = new System.Drawing.Point(17, 33);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(30, 15);
            this.panelColor1.TabIndex = 4;
            // 
            // PasswordStrPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.circularProgressBarr);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PasswordStrPanel";
            this.Size = new System.Drawing.Size(345, 433);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label labelTitle;
        private Bunifu.Framework.UI.BunifuCircleProgressbar circularProgressBarr;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label labelFair;
        private System.Windows.Forms.Panel panelColor2;
        private System.Windows.Forms.Label labelPoor;
        private System.Windows.Forms.Panel panelColor1;
        private System.Windows.Forms.Label labelSuperb;
        private System.Windows.Forms.Panel panelColor4;
        private System.Windows.Forms.Label labelGood;
        private System.Windows.Forms.Panel panelColor3;
    }
}