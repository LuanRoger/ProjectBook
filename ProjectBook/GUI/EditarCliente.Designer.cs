﻿
namespace ProjectBook.GUI
{
    partial class EditarCliente
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
            this.gpbBuscarCliente = new System.Windows.Forms.GroupBox();
            this.btnBucarCliente = new System.Windows.Forms.Button();
            this.txtBuscarClienteEditar = new System.Windows.Forms.TextBox();
            this.rabBuscarClienteNome = new System.Windows.Forms.RadioButton();
            this.rabBuscarClienteId = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNovoNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNovoEndereco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNovoCidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNovoUf = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNovoEmail = new System.Windows.Forms.TextBox();
            this.btnSalvarEditarCliente = new System.Windows.Forms.Button();
            this.btnLimparEditarCliente = new System.Windows.Forms.Button();
            this.btnCancelarEditarCliente = new System.Windows.Forms.Button();
            this.txtNovoCep = new System.Windows.Forms.MaskedTextBox();
            this.txtNovoTelefone1 = new System.Windows.Forms.MaskedTextBox();
            this.txtNovoTelefone2 = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVerClientes = new System.Windows.Forms.ToolStripButton();
            this.btnPesquisarCliente = new System.Windows.Forms.ToolStripButton();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpNovaDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNovoProfissao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNovoEmpressa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNovoObservacoes = new System.Windows.Forms.RichTextBox();
            this.gpbBuscarCliente.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbBuscarCliente
            // 
            this.gpbBuscarCliente.Controls.Add(this.btnBucarCliente);
            this.gpbBuscarCliente.Controls.Add(this.txtBuscarClienteEditar);
            this.gpbBuscarCliente.Controls.Add(this.rabBuscarClienteNome);
            this.gpbBuscarCliente.Controls.Add(this.rabBuscarClienteId);
            this.gpbBuscarCliente.Location = new System.Drawing.Point(13, 28);
            this.gpbBuscarCliente.Name = "gpbBuscarCliente";
            this.gpbBuscarCliente.Size = new System.Drawing.Size(326, 83);
            this.gpbBuscarCliente.TabIndex = 0;
            this.gpbBuscarCliente.TabStop = false;
            this.gpbBuscarCliente.Text = "Buscar cliente";
            // 
            // btnBucarCliente
            // 
            this.btnBucarCliente.FlatAppearance.BorderSize = 0;
            this.btnBucarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBucarCliente.Image = global::ProjectBook.Properties.Resources.search;
            this.btnBucarCliente.Location = new System.Drawing.Point(293, 48);
            this.btnBucarCliente.Name = "btnBucarCliente";
            this.btnBucarCliente.Size = new System.Drawing.Size(27, 23);
            this.btnBucarCliente.TabIndex = 3;
            this.btnBucarCliente.UseVisualStyleBackColor = true;
            this.btnBucarCliente.Click += new System.EventHandler(this.btnBucarCliente_Click);
            // 
            // txtBuscarClienteEditar
            // 
            this.txtBuscarClienteEditar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarClienteEditar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarClienteEditar.Location = new System.Drawing.Point(7, 48);
            this.txtBuscarClienteEditar.Name = "txtBuscarClienteEditar";
            this.txtBuscarClienteEditar.Size = new System.Drawing.Size(280, 23);
            this.txtBuscarClienteEditar.TabIndex = 1;
            // 
            // rabBuscarClienteNome
            // 
            this.rabBuscarClienteNome.AutoSize = true;
            this.rabBuscarClienteNome.Location = new System.Drawing.Point(229, 23);
            this.rabBuscarClienteNome.Name = "rabBuscarClienteNome";
            this.rabBuscarClienteNome.Size = new System.Drawing.Size(58, 19);
            this.rabBuscarClienteNome.TabIndex = 1;
            this.rabBuscarClienteNome.TabStop = true;
            this.rabBuscarClienteNome.Text = "Nome";
            this.rabBuscarClienteNome.UseVisualStyleBackColor = true;
            this.rabBuscarClienteNome.CheckedChanged += new System.EventHandler(this.rabBuscarClienteNome_CheckedChanged);
            // 
            // rabBuscarClienteId
            // 
            this.rabBuscarClienteId.AutoSize = true;
            this.rabBuscarClienteId.Checked = true;
            this.rabBuscarClienteId.Location = new System.Drawing.Point(7, 23);
            this.rabBuscarClienteId.Name = "rabBuscarClienteId";
            this.rabBuscarClienteId.Size = new System.Drawing.Size(64, 19);
            this.rabBuscarClienteId.TabIndex = 0;
            this.rabBuscarClienteId.TabStop = true;
            this.rabBuscarClienteId.Text = "Código";
            this.rabBuscarClienteId.UseVisualStyleBackColor = true;
            this.rabBuscarClienteId.CheckedChanged += new System.EventHandler(this.rabBuscarClienteId_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "*Nome:";
            // 
            // txtNovoNome
            // 
            this.txtNovoNome.Location = new System.Drawing.Point(12, 133);
            this.txtNovoNome.Name = "txtNovoNome";
            this.txtNovoNome.Size = new System.Drawing.Size(327, 23);
            this.txtNovoNome.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "*Endereço:";
            // 
            // txtNovoEndereco
            // 
            this.txtNovoEndereco.Location = new System.Drawing.Point(12, 181);
            this.txtNovoEndereco.Name = "txtNovoEndereco";
            this.txtNovoEndereco.Size = new System.Drawing.Size(252, 23);
            this.txtNovoEndereco.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "*Cidade:";
            // 
            // txtNovoCidade
            // 
            this.txtNovoCidade.Location = new System.Drawing.Point(12, 230);
            this.txtNovoCidade.Name = "txtNovoCidade";
            this.txtNovoCidade.Size = new System.Drawing.Size(252, 23);
            this.txtNovoCidade.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "UF:";
            // 
            // cmbNovoUf
            // 
            this.cmbNovoUf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovoUf.FormattingEnabled = true;
            this.cmbNovoUf.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO",
            "DF"});
            this.cmbNovoUf.Location = new System.Drawing.Point(270, 182);
            this.cmbNovoUf.Name = "cmbNovoUf";
            this.cmbNovoUf.Size = new System.Drawing.Size(69, 23);
            this.cmbNovoUf.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "CEP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "*Telefone 1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 309);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefone 2:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "E-mail:";
            // 
            // txtNovoEmail
            // 
            this.txtNovoEmail.Location = new System.Drawing.Point(199, 326);
            this.txtNovoEmail.Name = "txtNovoEmail";
            this.txtNovoEmail.Size = new System.Drawing.Size(140, 23);
            this.txtNovoEmail.TabIndex = 12;
            // 
            // btnSalvarEditarCliente
            // 
            this.btnSalvarEditarCliente.Image = global::ProjectBook.Properties.Resources.save;
            this.btnSalvarEditarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarEditarCliente.Location = new System.Drawing.Point(12, 445);
            this.btnSalvarEditarCliente.Name = "btnSalvarEditarCliente";
            this.btnSalvarEditarCliente.Size = new System.Drawing.Size(64, 23);
            this.btnSalvarEditarCliente.TabIndex = 14;
            this.btnSalvarEditarCliente.Text = "Salvar";
            this.btnSalvarEditarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarEditarCliente.UseVisualStyleBackColor = true;
            this.btnSalvarEditarCliente.Click += new System.EventHandler(this.btnSalvarEditarCliente_Click);
            // 
            // btnLimparEditarCliente
            // 
            this.btnLimparEditarCliente.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparEditarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparEditarCliente.Location = new System.Drawing.Point(189, 445);
            this.btnLimparEditarCliente.Name = "btnLimparEditarCliente";
            this.btnLimparEditarCliente.Size = new System.Drawing.Size(69, 23);
            this.btnLimparEditarCliente.TabIndex = 15;
            this.btnLimparEditarCliente.Text = "Limpar";
            this.btnLimparEditarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparEditarCliente.UseVisualStyleBackColor = true;
            this.btnLimparEditarCliente.Click += new System.EventHandler(this.btnLimparEditarCliente_Click);
            // 
            // btnCancelarEditarCliente
            // 
            this.btnCancelarEditarCliente.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarEditarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarEditarCliente.Location = new System.Drawing.Point(264, 445);
            this.btnCancelarEditarCliente.Name = "btnCancelarEditarCliente";
            this.btnCancelarEditarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarEditarCliente.TabIndex = 16;
            this.btnCancelarEditarCliente.Text = "Cancelar";
            this.btnCancelarEditarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarEditarCliente.UseVisualStyleBackColor = true;
            this.btnCancelarEditarCliente.Click += new System.EventHandler(this.btnCancelarEditarCliente_Click);
            // 
            // txtNovoCep
            // 
            this.txtNovoCep.Location = new System.Drawing.Point(270, 230);
            this.txtNovoCep.Mask = "00000-000";
            this.txtNovoCep.Name = "txtNovoCep";
            this.txtNovoCep.Size = new System.Drawing.Size(69, 23);
            this.txtNovoCep.TabIndex = 6;
            // 
            // txtNovoTelefone1
            // 
            this.txtNovoTelefone1.Location = new System.Drawing.Point(13, 326);
            this.txtNovoTelefone1.Mask = "(99) 00000-0000";
            this.txtNovoTelefone1.Name = "txtNovoTelefone1";
            this.txtNovoTelefone1.Size = new System.Drawing.Size(87, 23);
            this.txtNovoTelefone1.TabIndex = 10;
            // 
            // txtNovoTelefone2
            // 
            this.txtNovoTelefone2.Location = new System.Drawing.Point(106, 326);
            this.txtNovoTelefone2.Mask = "(99) 00000-0000";
            this.txtNovoTelefone2.Name = "txtNovoTelefone2";
            this.txtNovoTelefone2.Size = new System.Drawing.Size(87, 23);
            this.txtNovoTelefone2.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerClientes,
            this.btnPesquisarCliente});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(351, 25);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnVerClientes
            // 
            this.btnVerClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVerClientes.Image = global::ProjectBook.Properties.Resources.client_go;
            this.btnVerClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerClientes.Name = "btnVerClientes";
            this.btnVerClientes.Size = new System.Drawing.Size(23, 22);
            this.btnVerClientes.Text = "Ver todos os clientes";
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPesquisarCliente.Image = global::ProjectBook.Properties.Resources.search;
            this.btnPesquisarCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(23, 22);
            this.btnPesquisarCliente.Text = "Pesquisar cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "*Data de Nascimento:";
            // 
            // dtpNovaDataNascimento
            // 
            this.dtpNovaDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNovaDataNascimento.Location = new System.Drawing.Point(12, 278);
            this.dtpNovaDataNascimento.Name = "dtpNovaDataNascimento";
            this.dtpNovaDataNascimento.Size = new System.Drawing.Size(123, 23);
            this.dtpNovaDataNascimento.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(141, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Profissão:";
            // 
            // txtNovoProfissao
            // 
            this.txtNovoProfissao.Location = new System.Drawing.Point(141, 278);
            this.txtNovoProfissao.Name = "txtNovoProfissao";
            this.txtNovoProfissao.Size = new System.Drawing.Size(103, 23);
            this.txtNovoProfissao.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Empressa:";
            // 
            // txtNovoEmpressa
            // 
            this.txtNovoEmpressa.Location = new System.Drawing.Point(250, 278);
            this.txtNovoEmpressa.Name = "txtNovoEmpressa";
            this.txtNovoEmpressa.Size = new System.Drawing.Size(89, 23);
            this.txtNovoEmpressa.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "Observações:";
            // 
            // txtNovoObservacoes
            // 
            this.txtNovoObservacoes.Location = new System.Drawing.Point(13, 370);
            this.txtNovoObservacoes.Name = "txtNovoObservacoes";
            this.txtNovoObservacoes.Size = new System.Drawing.Size(326, 69);
            this.txtNovoObservacoes.TabIndex = 13;
            this.txtNovoObservacoes.Text = "";
            // 
            // EditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 480);
            this.Controls.Add(this.txtNovoObservacoes);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNovoEmpressa);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNovoProfissao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpNovaDataNascimento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNovoTelefone2);
            this.Controls.Add(this.txtNovoTelefone1);
            this.Controls.Add(this.txtNovoCep);
            this.Controls.Add(this.btnCancelarEditarCliente);
            this.Controls.Add(this.btnLimparEditarCliente);
            this.Controls.Add(this.btnSalvarEditarCliente);
            this.Controls.Add(this.txtNovoEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbNovoUf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNovoCidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNovoEndereco);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNovoNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gpbBuscarCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditarCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar cliente";
            this.gpbBuscarCliente.ResumeLayout(false);
            this.gpbBuscarCliente.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbBuscarCliente;
        private System.Windows.Forms.Button btnBucarCliente;
        private System.Windows.Forms.TextBox txtBuscarClienteEditar;
        private System.Windows.Forms.RadioButton rabBuscarClienteNome;
        private System.Windows.Forms.RadioButton rabBuscarClienteId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNovoNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNovoEndereco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNovoCidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNovoUf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNovoEmail;
        private System.Windows.Forms.Button btnSalvarEditarCliente;
        private System.Windows.Forms.Button btnLimparEditarCliente;
        private System.Windows.Forms.Button btnCancelarEditarCliente;
        private System.Windows.Forms.MaskedTextBox txtNovoCep;
        private System.Windows.Forms.MaskedTextBox txtNovoTelefone1;
        private System.Windows.Forms.MaskedTextBox txtNovoTelefone2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnVerClientes;
        private System.Windows.Forms.ToolStripButton btnPesquisarCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpNovaDataNascimento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNovoProfissao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNovoEmpressa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox txtNovoObservacoes;
    }
}