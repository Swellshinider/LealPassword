namespace LealPassword.UI.LoginCreateSub
{
    internal sealed partial class LoginUI
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.textBoxPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxEmail.HintForeColor = System.Drawing.Color.Empty;
            this.textBoxEmail.HintText = "";
            this.textBoxEmail.isPassword = false;
            this.textBoxEmail.LineFocusedColor = System.Drawing.Color.Blue;
            this.textBoxEmail.LineIdleColor = System.Drawing.Color.Gray;
            this.textBoxEmail.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.textBoxEmail.LineThickness = 3;
            this.textBoxEmail.Location = new System.Drawing.Point(0, 0);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(379, 33);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.Text = "bunifuMaterialTextbox1";
            this.textBoxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxPass.HintForeColor = System.Drawing.Color.Empty;
            this.textBoxPass.HintText = "";
            this.textBoxPass.isPassword = false;
            this.textBoxPass.LineFocusedColor = System.Drawing.Color.Blue;
            this.textBoxPass.LineIdleColor = System.Drawing.Color.Gray;
            this.textBoxPass.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.textBoxPass.LineThickness = 3;
            this.textBoxPass.Location = new System.Drawing.Point(0, 0);
            this.textBoxPass.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(379, 33);
            this.textBoxPass.TabIndex = 3;
            this.textBoxPass.Text = "bunifuMaterialTextbox1";
            this.textBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // LoginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxEmail);
            this.Name = "LoginUI";
            this.Size = new System.Drawing.Size(425, 211);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBoxEmail;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBoxPass;
    }
}