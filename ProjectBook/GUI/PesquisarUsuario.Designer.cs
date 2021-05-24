
namespace ProjectBook.GUI
{
    partial class PesquisarUsuario
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuRelatorioUsuairo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerAdm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.bntBuscarUsuario = new System.Windows.Forms.Button();
            this.btnCancelarBuscaUsuario = new System.Windows.Forms.Button();
            this.txtNomeUsuarioBusca = new System.Windows.Forms.TextBox();
            this.rabUsuarioNome = new System.Windows.Forms.RadioButton();
            this.rabCodigoUsuario = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRelatorioUsuairo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuRelatorioUsuairo
            // 
            this.mnuRelatorioUsuairo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerAdm,
            this.mnuVerUsuarios});
            this.mnuRelatorioUsuairo.Name = "mnuRelatorioUsuairo";
            this.mnuRelatorioUsuairo.Size = new System.Drawing.Size(66, 20);
            this.mnuRelatorioUsuairo.Text = "Relatorio";
            // 
            // mnuVerAdm
            // 
            this.mnuVerAdm.Name = "mnuVerAdm";
            this.mnuVerAdm.Size = new System.Drawing.Size(226, 22);
            this.mnuVerAdm.Text = "Ver todos os administradores";
            // 
            // mnuVerUsuarios
            // 
            this.mnuVerUsuarios.Name = "mnuVerUsuarios";
            this.mnuVerUsuarios.Size = new System.Drawing.Size(226, 22);
            this.mnuVerUsuarios.Text = "Ver todos os usuários";
            // 
            // bntBuscarUsuario
            // 
            this.bntBuscarUsuario.FlatAppearance.BorderSize = 0;
            this.bntBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntBuscarUsuario.Image = global::ProjectBook.Properties.Resources.zoom;
            this.bntBuscarUsuario.Location = new System.Drawing.Point(222, 85);
            this.bntBuscarUsuario.Name = "bntBuscarUsuario";
            this.bntBuscarUsuario.Size = new System.Drawing.Size(25, 23);
            this.bntBuscarUsuario.TabIndex = 2;
            this.bntBuscarUsuario.UseVisualStyleBackColor = true;
            this.bntBuscarUsuario.Click += new System.EventHandler(this.bntBuscarUsuario_Click);
            // 
            // btnCancelarBuscaUsuario
            // 
            this.btnCancelarBuscaUsuario.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarBuscaUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarBuscaUsuario.Location = new System.Drawing.Point(172, 125);
            this.btnCancelarBuscaUsuario.Name = "btnCancelarBuscaUsuario";
            this.btnCancelarBuscaUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarBuscaUsuario.TabIndex = 3;
            this.btnCancelarBuscaUsuario.Text = "Cancelar";
            this.btnCancelarBuscaUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarBuscaUsuario.UseVisualStyleBackColor = true;
            this.btnCancelarBuscaUsuario.Click += new System.EventHandler(this.btnCancelarBuscaUsuario_Click);
            // 
            // txtNomeUsuarioBusca
            // 
            this.txtNomeUsuarioBusca.Location = new System.Drawing.Point(12, 86);
            this.txtNomeUsuarioBusca.Name = "txtNomeUsuarioBusca";
            this.txtNomeUsuarioBusca.Size = new System.Drawing.Size(204, 23);
            this.txtNomeUsuarioBusca.TabIndex = 4;
            // 
            // rabUsuarioNome
            // 
            this.rabUsuarioNome.AutoSize = true;
            this.rabUsuarioNome.Location = new System.Drawing.Point(171, 22);
            this.rabUsuarioNome.Name = "rabUsuarioNome";
            this.rabUsuarioNome.Size = new System.Drawing.Size(58, 19);
            this.rabUsuarioNome.TabIndex = 5;
            this.rabUsuarioNome.TabStop = true;
            this.rabUsuarioNome.Text = "Nome";
            this.rabUsuarioNome.UseVisualStyleBackColor = true;
            // 
            // rabCodigoUsuario
            // 
            this.rabCodigoUsuario.AutoSize = true;
            this.rabCodigoUsuario.Location = new System.Drawing.Point(6, 22);
            this.rabCodigoUsuario.Name = "rabCodigoUsuario";
            this.rabCodigoUsuario.Size = new System.Drawing.Size(64, 19);
            this.rabCodigoUsuario.TabIndex = 6;
            this.rabCodigoUsuario.TabStop = true;
            this.rabCodigoUsuario.Text = "Código";
            this.rabCodigoUsuario.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rabCodigoUsuario);
            this.groupBox1.Controls.Add(this.rabUsuarioNome);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 54);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar por:";
            // 
            // PesquisarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 161);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNomeUsuarioBusca);
            this.Controls.Add(this.btnCancelarBuscaUsuario);
            this.Controls.Add(this.bntBuscarUsuario);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PesquisarUsuario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar usuário";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorioUsuairo;
        private System.Windows.Forms.ToolStripMenuItem mnuVerAdm;
        private System.Windows.Forms.ToolStripMenuItem mnuVerUsuarios;
        private System.Windows.Forms.Button bntBuscarUsuario;
        private System.Windows.Forms.Button btnCancelarBuscaUsuario;
        private System.Windows.Forms.TextBox txtNomeUsuarioBusca;
        private System.Windows.Forms.RadioButton rabUsuarioNome;
        private System.Windows.Forms.RadioButton rabCodigoUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}