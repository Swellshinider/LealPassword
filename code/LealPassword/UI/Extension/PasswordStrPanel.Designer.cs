﻿namespace LealPassword.UI.Extension
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.labelTitle = new System.Windows.Forms.Label();
            this.circularProgressBarr = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 58);
            this.panel1.TabIndex = 1;
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
            this.labelTitle.Size = new System.Drawing.Size(308, 32);
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
            this.circularProgressBarr.Location = new System.Drawing.Point(0, 72);
            this.circularProgressBarr.Margin = new System.Windows.Forms.Padding(0);
            this.circularProgressBarr.MaxValue = 100;
            this.circularProgressBarr.Name = "circularProgressBarr";
            this.circularProgressBarr.ProgressBackColor = System.Drawing.Color.WhiteSmoke;
            this.circularProgressBarr.ProgressColor = System.Drawing.Color.SeaGreen;
            this.circularProgressBarr.Size = new System.Drawing.Size(250, 250);
            this.circularProgressBarr.TabIndex = 2;
            this.circularProgressBarr.Value = 50;
            // 
            // PasswordStrPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.circularProgressBarr);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PasswordStrPanel";
            this.Size = new System.Drawing.Size(311, 433);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label labelTitle;
        private Bunifu.Framework.UI.BunifuCircleProgressbar circularProgressBarr;
    }
}