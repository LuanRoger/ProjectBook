using System.ComponentModel;

namespace ProjectBook.GUI
{
    partial class GerenciarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GerenciarUsuario));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLimparCadastrarUsuario = new System.Windows.Forms.Button();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenhaCadastrar = new System.Windows.Forms.TextBox();
            this.txtUsuarioCadastrar = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLimparEditarUsuario = new System.Windows.Forms.Button();
            this.cmdNovoStatus = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdBuscarUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNovoSenhaUsuario = new System.Windows.Forms.TextBox();
            this.btnSalvarEditarUsuario = new System.Windows.Forms.Button();
            this.txtNovoUsuario = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDeletarUsuario = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdDeletarUsuario = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 265);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLimparCadastrarUsuario);
            this.tabPage1.Controls.Add(this.btnCadastrarUsuario);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtSenhaCadastrar);
            this.tabPage1.Controls.Add(this.txtUsuarioCadastrar);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(426, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastrar usuário";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLimparCadastrarUsuario
            // 
            this.btnLimparCadastrarUsuario.Location = new System.Drawing.Point(327, 202);
            this.btnLimparCadastrarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimparCadastrarUsuario.Name = "btnLimparCadastrarUsuario";
            this.btnLimparCadastrarUsuario.Size = new System.Drawing.Size(88, 27);
            this.btnLimparCadastrarUsuario.TabIndex = 3;
            this.btnLimparCadastrarUsuario.Text = "Limpar";
            this.btnLimparCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnLimparCadastrarUsuario.Click += new System.EventHandler(this.btnLimparCadastrarUsuario_Click);
            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(231, 202);
            this.btnCadastrarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(88, 27);
            this.btnCadastrarUsuario.TabIndex = 2;
            this.btnCadastrarUsuario.Text = "Cadastrar";
            this.btnCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário:";
            // 
            // txtSenhaCadastrar
            // 
            this.txtSenhaCadastrar.Location = new System.Drawing.Point(7, 72);
            this.txtSenhaCadastrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSenhaCadastrar.Name = "txtSenhaCadastrar";
            this.txtSenhaCadastrar.Size = new System.Drawing.Size(408, 23);
            this.txtSenhaCadastrar.TabIndex = 1;
            // 
            // txtUsuarioCadastrar
            // 
            this.txtUsuarioCadastrar.Location = new System.Drawing.Point(7, 24);
            this.txtUsuarioCadastrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuarioCadastrar.Name = "txtUsuarioCadastrar";
            this.txtUsuarioCadastrar.Size = new System.Drawing.Size(408, 23);
            this.txtUsuarioCadastrar.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLimparEditarUsuario);
            this.tabPage2.Controls.Add(this.cmdNovoStatus);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtNovoSenhaUsuario);
            this.tabPage2.Controls.Add(this.btnSalvarEditarUsuario);
            this.tabPage2.Controls.Add(this.txtNovoUsuario);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(426, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Editar usuário";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLimparEditarUsuario
            // 
            this.btnLimparEditarUsuario.Location = new System.Drawing.Point(327, 202);
            this.btnLimparEditarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimparEditarUsuario.Name = "btnLimparEditarUsuario";
            this.btnLimparEditarUsuario.Size = new System.Drawing.Size(88, 27);
            this.btnLimparEditarUsuario.TabIndex = 7;
            this.btnLimparEditarUsuario.Text = "Limpar";
            this.btnLimparEditarUsuario.UseVisualStyleBackColor = true;
            this.btnLimparEditarUsuario.Click += new System.EventHandler(this.btnLimparEditarUsuario_Click);
            // 
            // cmdNovoStatus
            // 
            this.cmdNovoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdNovoStatus.FormattingEnabled = true;
            this.cmdNovoStatus.Items.AddRange(new object[] {
            "ADM",
            "USU"});
            this.cmdNovoStatus.Location = new System.Drawing.Point(156, 119);
            this.cmdNovoStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmdNovoStatus.Name = "cmdNovoStatus";
            this.cmdNovoStatus.Size = new System.Drawing.Size(259, 23);
            this.cmdNovoStatus.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarUsuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIdBuscarUsuario);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(141, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.FlatAppearance.BorderSize = 0;
            this.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarUsuario.Image")));
            this.btnBuscarUsuario.Location = new System.Drawing.Point(112, 37);
            this.btnBuscarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(21, 25);
            this.btnBuscarUsuario.TabIndex = 2;
            this.btnBuscarUsuario.UseVisualStyleBackColor = true;
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID:";
            // 
            // txtIdBuscarUsuario
            // 
            this.txtIdBuscarUsuario.Location = new System.Drawing.Point(7, 38);
            this.txtIdBuscarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdBuscarUsuario.Name = "txtIdBuscarUsuario";
            this.txtIdBuscarUsuario.Size = new System.Drawing.Size(97, 23);
            this.txtIdBuscarUsuario.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(156, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tipo:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(156, 53);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Senha:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(156, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuário:";
            // 
            // txtNovoSenhaUsuario
            // 
            this.txtNovoSenhaUsuario.Location = new System.Drawing.Point(156, 73);
            this.txtNovoSenhaUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNovoSenhaUsuario.Name = "txtNovoSenhaUsuario";
            this.txtNovoSenhaUsuario.Size = new System.Drawing.Size(259, 23);
            this.txtNovoSenhaUsuario.TabIndex = 4;
            // 
            // btnSalvarEditarUsuario
            // 
            this.btnSalvarEditarUsuario.Location = new System.Drawing.Point(231, 202);
            this.btnSalvarEditarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalvarEditarUsuario.Name = "btnSalvarEditarUsuario";
            this.btnSalvarEditarUsuario.Size = new System.Drawing.Size(88, 27);
            this.btnSalvarEditarUsuario.TabIndex = 6;
            this.btnSalvarEditarUsuario.Text = "Salvar";
            this.btnSalvarEditarUsuario.UseVisualStyleBackColor = true;
            this.btnSalvarEditarUsuario.Click += new System.EventHandler(this.btnSalvarEditarUsuario_Click);
            // 
            // txtNovoUsuario
            // 
            this.txtNovoUsuario.Location = new System.Drawing.Point(156, 23);
            this.txtNovoUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNovoUsuario.Name = "txtNovoUsuario";
            this.txtNovoUsuario.Size = new System.Drawing.Size(259, 23);
            this.txtNovoUsuario.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDeletarUsuario);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Size = new System.Drawing.Size(426, 237);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Deletar usuário";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDeletarUsuario
            // 
            this.btnDeletarUsuario.Location = new System.Drawing.Point(327, 202);
            this.btnDeletarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeletarUsuario.Name = "btnDeletarUsuario";
            this.btnDeletarUsuario.Size = new System.Drawing.Size(88, 27);
            this.btnDeletarUsuario.TabIndex = 2;
            this.btnDeletarUsuario.Text = "Deletar";
            this.btnDeletarUsuario.UseVisualStyleBackColor = true;
            this.btnDeletarUsuario.Click += new System.EventHandler(this.btnDeletarUsuario_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtIdDeletarUsuario);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(408, 70);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "ID:";
            // 
            // txtIdDeletarUsuario
            // 
            this.txtIdDeletarUsuario.Location = new System.Drawing.Point(7, 39);
            this.txtIdDeletarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdDeletarUsuario.Name = "txtIdDeletarUsuario";
            this.txtIdDeletarUsuario.Size = new System.Drawing.Size(393, 23);
            this.txtIdDeletarUsuario.TabIndex = 1;
            // 
            // GerenciarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 265);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "GerenciarUsuario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar usuário";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnLimparCadastrarUsuario;

        private System.Windows.Forms.Button btnLimparEditarUsuario;

        private System.Windows.Forms.Button btnDeletarUsuario;

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIdDeletarUsuario;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.ComboBox cmdNovoStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNovoUsuario;
        private System.Windows.Forms.TextBox txtNovoSenhaUsuario;

        private System.Windows.Forms.Button btnSalvarEditarUsuario;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdBuscarUsuario;

        private System.Windows.Forms.Button btnCadastrarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtUsuarioCadastrar;
        private System.Windows.Forms.TextBox txtSenhaCadastrar;

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}