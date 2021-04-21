using System.ComponentModel;

namespace ProjectBook.GUI
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txtLoginUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLoginSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEntrarLogin = new System.Windows.Forms.Button();
            this.btnFecharLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoginCodigo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLoginUsuario
            // 
            this.txtLoginUsuario.Location = new System.Drawing.Point(70, 27);
            this.txtLoginUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLoginUsuario.Name = "txtLoginUsuario";
            this.txtLoginUsuario.Size = new System.Drawing.Size(175, 23);
            this.txtLoginUsuario.TabIndex = 2;
            this.txtLoginUsuario.Leave += new System.EventHandler(this.txtLoginUsuario_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário:";
            // 
            // txtLoginSenha
            // 
            this.txtLoginSenha.Location = new System.Drawing.Point(14, 73);
            this.txtLoginSenha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLoginSenha.Name = "txtLoginSenha";
            this.txtLoginSenha.PasswordChar = '*';
            this.txtLoginSenha.Size = new System.Drawing.Size(233, 23);
            this.txtLoginSenha.TabIndex = 3;
            this.txtLoginSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginSenha_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha:";
            // 
            // btnEntrarLogin
            // 
            this.btnEntrarLogin.Image = global::ProjectBook.Properties.Images.Images.enter_account;
            this.btnEntrarLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrarLogin.Location = new System.Drawing.Point(14, 102);
            this.btnEntrarLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEntrarLogin.Name = "btnEntrarLogin";
            this.btnEntrarLogin.Size = new System.Drawing.Size(62, 22);
            this.btnEntrarLogin.TabIndex = 6;
            this.btnEntrarLogin.Text = "Entrar";
            this.btnEntrarLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEntrarLogin.UseVisualStyleBackColor = true;
            this.btnEntrarLogin.Click += new System.EventHandler(this.btnEntrarLogin_Click);
            // 
            // btnFecharLogin
            // 
            this.btnFecharLogin.Location = new System.Drawing.Point(196, 102);
            this.btnFecharLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFecharLogin.Name = "btnFecharLogin";
            this.btnFecharLogin.Size = new System.Drawing.Size(51, 22);
            this.btnFecharLogin.TabIndex = 7;
            this.btnFecharLogin.Text = "Fechar";
            this.btnFecharLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFecharLogin.UseVisualStyleBackColor = true;
            this.btnFecharLogin.Click += new System.EventHandler(this.btnFecharLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Código:";
            // 
            // txtLoginCodigo
            // 
            this.txtLoginCodigo.Location = new System.Drawing.Point(14, 27);
            this.txtLoginCodigo.Name = "txtLoginCodigo";
            this.txtLoginCodigo.Size = new System.Drawing.Size(49, 23);
            this.txtLoginCodigo.TabIndex = 1;
            this.txtLoginCodigo.Leave += new System.EventHandler(this.txtLoginCodigo_Leave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(258, 135);
            this.Controls.Add(this.txtLoginCodigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFecharLogin);
            this.Controls.Add(this.btnEntrarLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLoginSenha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLoginUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnFecharLogin;

        private System.Windows.Forms.Button btnEntrarLogin;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoginUsuario;
        private System.Windows.Forms.TextBox txtLoginSenha;

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoginCodigo;
    }
}