using System.ComponentModel;
using ProjectBook.Model.Enums;

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.btnLimparCadastrarUsuario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenhaCadastrar = new System.Windows.Forms.TextBox();
            this.txtUsuarioCadastrar = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLimparEditarUsuario = new System.Windows.Forms.Button();
            this.cmbNovoStatus = new System.Windows.Forms.ComboBox();
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
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTipoUsuarioCadastrar = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(290, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbTipoUsuarioCadastrar);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.btnCadastrarUsuario);
            this.tabPage1.Controls.Add(this.btnLimparCadastrarUsuario);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtSenhaCadastrar);
            this.tabPage1.Controls.Add(this.txtUsuarioCadastrar);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(282, 258);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastrar usuário";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.Image = global::ProjectBook.Properties.Resources.save;
            this.btnCadastrarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(9, 229);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(64, 23);
            this.btnCadastrarUsuario.TabIndex = 4;
            this.btnCadastrarUsuario.Text = "Salvar";
            this.btnCadastrarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click);
            // 
            // btnLimparCadastrarUsuario
            // 
            this.btnLimparCadastrarUsuario.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparCadastrarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCadastrarUsuario.Location = new System.Drawing.Point(80, 229);
            this.btnLimparCadastrarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimparCadastrarUsuario.Name = "btnLimparCadastrarUsuario";
            this.btnLimparCadastrarUsuario.Size = new System.Drawing.Size(68, 23);
            this.btnLimparCadastrarUsuario.TabIndex = 3;
            this.btnLimparCadastrarUsuario.Text = "Limpar";
            this.btnLimparCadastrarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparCadastrarUsuario.UseVisualStyleBackColor = true;
            this.btnLimparCadastrarUsuario.Click += new System.EventHandler(this.btnLimparCadastrarUsuario_Click);
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
            this.txtSenhaCadastrar.Size = new System.Drawing.Size(267, 23);
            this.txtSenhaCadastrar.TabIndex = 1;
            // 
            // txtUsuarioCadastrar
            // 
            this.txtUsuarioCadastrar.Location = new System.Drawing.Point(7, 24);
            this.txtUsuarioCadastrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuarioCadastrar.Name = "txtUsuarioCadastrar";
            this.txtUsuarioCadastrar.Size = new System.Drawing.Size(267, 23);
            this.txtUsuarioCadastrar.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLimparEditarUsuario);
            this.tabPage2.Controls.Add(this.cmbNovoStatus);
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
            this.tabPage2.Size = new System.Drawing.Size(282, 258);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Editar usuário";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLimparEditarUsuario
            // 
            this.btnLimparEditarUsuario.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparEditarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparEditarUsuario.Location = new System.Drawing.Point(81, 227);
            this.btnLimparEditarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimparEditarUsuario.Name = "btnLimparEditarUsuario";
            this.btnLimparEditarUsuario.Size = new System.Drawing.Size(68, 23);
            this.btnLimparEditarUsuario.TabIndex = 7;
            this.btnLimparEditarUsuario.Text = "Limpar";
            this.btnLimparEditarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparEditarUsuario.UseVisualStyleBackColor = true;
            this.btnLimparEditarUsuario.Click += new System.EventHandler(this.btnLimparEditarUsuario_Click);
            // 
            // cmbNovoStatus
            // 
            this.cmbNovoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovoStatus.FormattingEnabled = true;
            this.cmbNovoStatus.Items.AddRange(new object[] {
            TipoUsuario.USU, 
            TipoUsuario.ADM});
            this.cmbNovoStatus.Location = new System.Drawing.Point(9, 195);
            this.cmbNovoStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbNovoStatus.Name = "cmbNovoStatus";
            this.cmbNovoStatus.Size = new System.Drawing.Size(265, 23);
            this.cmbNovoStatus.TabIndex = 5;
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
            this.groupBox1.Size = new System.Drawing.Size(267, 69);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.FlatAppearance.BorderSize = 0;
            this.btnBuscarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarUsuario.Image = global::ProjectBook.Properties.Resources.search;
            this.btnBuscarUsuario.Location = new System.Drawing.Point(238, 38);
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
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Código:";
            // 
            // txtIdBuscarUsuario
            // 
            this.txtIdBuscarUsuario.Location = new System.Drawing.Point(7, 38);
            this.txtIdBuscarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdBuscarUsuario.Name = "txtIdBuscarUsuario";
            this.txtIdBuscarUsuario.Size = new System.Drawing.Size(223, 23);
            this.txtIdBuscarUsuario.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 175);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tipo:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Senha:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Usuário:";
            // 
            // txtNovoSenhaUsuario
            // 
            this.txtNovoSenhaUsuario.Location = new System.Drawing.Point(9, 149);
            this.txtNovoSenhaUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNovoSenhaUsuario.Name = "txtNovoSenhaUsuario";
            this.txtNovoSenhaUsuario.Size = new System.Drawing.Size(265, 23);
            this.txtNovoSenhaUsuario.TabIndex = 4;
            // 
            // btnSalvarEditarUsuario
            // 
            this.btnSalvarEditarUsuario.Image = global::ProjectBook.Properties.Resources.save;
            this.btnSalvarEditarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarEditarUsuario.Location = new System.Drawing.Point(9, 227);
            this.btnSalvarEditarUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalvarEditarUsuario.Name = "btnSalvarEditarUsuario";
            this.btnSalvarEditarUsuario.Size = new System.Drawing.Size(64, 23);
            this.btnSalvarEditarUsuario.TabIndex = 6;
            this.btnSalvarEditarUsuario.Text = "Salvar";
            this.btnSalvarEditarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarEditarUsuario.UseVisualStyleBackColor = true;
            this.btnSalvarEditarUsuario.Click += new System.EventHandler(this.btnSalvarEditarUsuario_Click);
            // 
            // txtNovoUsuario
            // 
            this.txtNovoUsuario.Location = new System.Drawing.Point(9, 99);
            this.txtNovoUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNovoUsuario.Name = "txtNovoUsuario";
            this.txtNovoUsuario.Size = new System.Drawing.Size(265, 23);
            this.txtNovoUsuario.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tipo:";
            // 
            // cmbTipoUsuarioCadastrar
            // 
            this.cmbTipoUsuarioCadastrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoUsuarioCadastrar.Enabled = false;
            this.cmbTipoUsuarioCadastrar.FormattingEnabled = true;
            this.cmbTipoUsuarioCadastrar.Location = new System.Drawing.Point(7, 121);
            this.cmbTipoUsuarioCadastrar.Name = "cmbTipoUsuarioCadastrar";
            this.cmbTipoUsuarioCadastrar.Size = new System.Drawing.Size(267, 23);
            this.cmbTipoUsuarioCadastrar.TabIndex = 6;
            this.cmbTipoUsuarioCadastrar.Items.Add("USU");
            this.cmbTipoUsuarioCadastrar.SelectedIndex = 0;
            // 
            // GerenciarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 283);
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
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnLimparCadastrarUsuario;

        private System.Windows.Forms.Button btnLimparEditarUsuario;

        private System.Windows.Forms.ComboBox cmbNovoStatus;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioCadastrar;
        private System.Windows.Forms.TextBox txtSenhaCadastrar;

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCadastrarUsuario;
        private System.Windows.Forms.ComboBox cmbTipoUsuarioCadastrar;
        private System.Windows.Forms.Label label8;
    }
}