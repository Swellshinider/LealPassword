namespace LealPassword.UI.LoginCreateSub
{
    internal sealed partial class CreateUI
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
            this.textBoxUser = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.textBoxPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.textBoxPass2 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.SuspendLayout();
            // 
            // textBoxUser
            // 
            this.textBoxUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxUser.HintForeColor = System.Drawing.Color.Empty;
            this.textBoxUser.HintText = "";
            this.textBoxUser.isPassword = false;
            this.textBoxUser.LineFocusedColor = System.Drawing.Color.Blue;
            this.textBoxUser.LineIdleColor = System.Drawing.Color.Gray;
            this.textBoxUser.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.textBoxUser.LineThickness = 3;
            this.textBoxUser.Location = new System.Drawing.Point(0, 0);
            this.textBoxUser.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(379, 33);
            this.textBoxUser.TabIndex = 0;
            this.textBoxUser.Text = "bunifuMaterialTextbox1";
            this.textBoxUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.textBoxPass.TabIndex = 1;
            this.textBoxPass.Text = "bunifuMaterialTextbox1";
            this.textBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // textBoxPass2
            // 
            this.textBoxPass2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxPass2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxPass2.HintForeColor = System.Drawing.Color.Empty;
            this.textBoxPass2.HintText = "";
            this.textBoxPass2.isPassword = false;
            this.textBoxPass2.LineFocusedColor = System.Drawing.Color.Blue;
            this.textBoxPass2.LineIdleColor = System.Drawing.Color.Gray;
            this.textBoxPass2.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.textBoxPass2.LineThickness = 3;
            this.textBoxPass2.Location = new System.Drawing.Point(0, 0);
            this.textBoxPass2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPass2.Name = "textBoxPass2";
            this.textBoxPass2.Size = new System.Drawing.Size(379, 33);
            this.textBoxPass2.TabIndex = 2;
            this.textBoxPass2.Text = "bunifuMaterialTextbox1";
            this.textBoxPass2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // CreateUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxPass2);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxUser);
            this.Name = "CreateUI";
            this.Size = new System.Drawing.Size(389, 106);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMaterialTextbox textBoxUser;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBoxPass;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBoxPass2;
    }
}