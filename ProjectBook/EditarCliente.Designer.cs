
namespace ProjectBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarCliente));
            this.gpbBuscarCliente = new System.Windows.Forms.GroupBox();
            this.btnBucarCliente = new System.Windows.Forms.Button();
            this.txtBuscarClienteEditar = new System.Windows.Forms.TextBox();
            this.rabBsucarClienteNome = new System.Windows.Forms.RadioButton();
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
            this.gpbBuscarCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbBuscarCliente
            // 
            this.gpbBuscarCliente.Controls.Add(this.btnBucarCliente);
            this.gpbBuscarCliente.Controls.Add(this.txtBuscarClienteEditar);
            this.gpbBuscarCliente.Controls.Add(this.rabBsucarClienteNome);
            this.gpbBuscarCliente.Controls.Add(this.rabBuscarClienteId);
            this.gpbBuscarCliente.Location = new System.Drawing.Point(13, 13);
            this.gpbBuscarCliente.Name = "gpbBuscarCliente";
            this.gpbBuscarCliente.Size = new System.Drawing.Size(299, 83);
            this.gpbBuscarCliente.TabIndex = 0;
            this.gpbBuscarCliente.TabStop = false;
            this.gpbBuscarCliente.Text = "Buscar cliente";
            // 
            // btnBucarCliente
            // 
            this.btnBucarCliente.FlatAppearance.BorderSize = 0;
            this.btnBucarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBucarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBucarCliente.Image")));
            this.btnBucarCliente.Location = new System.Drawing.Point(266, 48);
            this.btnBucarCliente.Name = "btnBucarCliente";
            this.btnBucarCliente.Size = new System.Drawing.Size(27, 23);
            this.btnBucarCliente.TabIndex = 3;
            this.btnBucarCliente.UseVisualStyleBackColor = true;
            this.btnBucarCliente.Click += new System.EventHandler(this.btnBucarCliente_Click);
            // 
            // txtBuscarClienteEditar
            // 
            this.txtBuscarClienteEditar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuscarClienteEditar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarClienteEditar.Location = new System.Drawing.Point(7, 48);
            this.txtBuscarClienteEditar.Name = "txtBuscarClienteEditar";
            this.txtBuscarClienteEditar.Size = new System.Drawing.Size(253, 23);
            this.txtBuscarClienteEditar.TabIndex = 2;
            // 
            // rabBsucarClienteNome
            // 
            this.rabBsucarClienteNome.AutoSize = true;
            this.rabBsucarClienteNome.Location = new System.Drawing.Point(203, 23);
            this.rabBsucarClienteNome.Name = "rabBsucarClienteNome";
            this.rabBsucarClienteNome.Size = new System.Drawing.Size(58, 19);
            this.rabBsucarClienteNome.TabIndex = 1;
            this.rabBsucarClienteNome.TabStop = true;
            this.rabBsucarClienteNome.Text = "Nome";
            this.rabBsucarClienteNome.UseVisualStyleBackColor = true;
            this.rabBsucarClienteNome.CheckedChanged += new System.EventHandler(this.rabBsucarClienteNome_CheckedChanged);
            // 
            // rabBuscarClienteId
            // 
            this.rabBuscarClienteId.AutoSize = true;
            this.rabBuscarClienteId.Location = new System.Drawing.Point(7, 23);
            this.rabBuscarClienteId.Name = "rabBuscarClienteId";
            this.rabBuscarClienteId.Size = new System.Drawing.Size(36, 19);
            this.rabBuscarClienteId.TabIndex = 0;
            this.rabBuscarClienteId.TabStop = true;
            this.rabBuscarClienteId.Text = "ID";
            this.rabBuscarClienteId.UseVisualStyleBackColor = true;
            this.rabBuscarClienteId.CheckedChanged += new System.EventHandler(this.rabBuscarClienteId_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "*Nome:";
            // 
            // txtNovoNome
            // 
            this.txtNovoNome.Location = new System.Drawing.Point(12, 118);
            this.txtNovoNome.Name = "txtNovoNome";
            this.txtNovoNome.Size = new System.Drawing.Size(300, 23);
            this.txtNovoNome.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "*Endereço:";
            // 
            // txtNovoEndereco
            // 
            this.txtNovoEndereco.Location = new System.Drawing.Point(12, 166);
            this.txtNovoEndereco.Name = "txtNovoEndereco";
            this.txtNovoEndereco.Size = new System.Drawing.Size(225, 23);
            this.txtNovoEndereco.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "*Cidade:";
            // 
            // txtNovoCidade
            // 
            this.txtNovoCidade.Location = new System.Drawing.Point(12, 215);
            this.txtNovoCidade.Name = "txtNovoCidade";
            this.txtNovoCidade.Size = new System.Drawing.Size(225, 23);
            this.txtNovoCidade.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 148);
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
            this.cmbNovoUf.Location = new System.Drawing.Point(243, 166);
            this.cmbNovoUf.Name = "cmbNovoUf";
            this.cmbNovoUf.Size = new System.Drawing.Size(69, 23);
            this.cmbNovoUf.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "CEP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "*Telefone 1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Telefone 2:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(200, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "E-mail:";
            // 
            // txtNovoEmail
            // 
            this.txtNovoEmail.Location = new System.Drawing.Point(198, 262);
            this.txtNovoEmail.Name = "txtNovoEmail";
            this.txtNovoEmail.Size = new System.Drawing.Size(114, 23);
            this.txtNovoEmail.TabIndex = 16;
            // 
            // btnSalvarEditarCliente
            // 
            this.btnSalvarEditarCliente.Location = new System.Drawing.Point(12, 310);
            this.btnSalvarEditarCliente.Name = "btnSalvarEditarCliente";
            this.btnSalvarEditarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarEditarCliente.TabIndex = 17;
            this.btnSalvarEditarCliente.Text = "Salvar";
            this.btnSalvarEditarCliente.UseVisualStyleBackColor = true;
            this.btnSalvarEditarCliente.Click += new System.EventHandler(this.btnSalvarEditarCliente_Click);
            // 
            // btnLimparEditarCliente
            // 
            this.btnLimparEditarCliente.Location = new System.Drawing.Point(129, 310);
            this.btnLimparEditarCliente.Name = "btnLimparEditarCliente";
            this.btnLimparEditarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnLimparEditarCliente.TabIndex = 18;
            this.btnLimparEditarCliente.Text = "Limpar";
            this.btnLimparEditarCliente.UseVisualStyleBackColor = true;
            this.btnLimparEditarCliente.Click += new System.EventHandler(this.btnLimparEditarCliente_Click);
            // 
            // btnCancelarEditarCliente
            // 
            this.btnCancelarEditarCliente.Location = new System.Drawing.Point(237, 310);
            this.btnCancelarEditarCliente.Name = "btnCancelarEditarCliente";
            this.btnCancelarEditarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarEditarCliente.TabIndex = 19;
            this.btnCancelarEditarCliente.Text = "Cancelar";
            this.btnCancelarEditarCliente.UseVisualStyleBackColor = true;
            this.btnCancelarEditarCliente.Click += new System.EventHandler(this.btnCancelarEditarCliente_Click);
            // 
            // txtNovoCep
            // 
            this.txtNovoCep.Location = new System.Drawing.Point(243, 214);
            this.txtNovoCep.Mask = "00000-000";
            this.txtNovoCep.Name = "txtNovoCep";
            this.txtNovoCep.Size = new System.Drawing.Size(69, 23);
            this.txtNovoCep.TabIndex = 20;
            // 
            // txtNovoTelefone1
            // 
            this.txtNovoTelefone1.Location = new System.Drawing.Point(13, 262);
            this.txtNovoTelefone1.Mask = "(99) 00000-0000";
            this.txtNovoTelefone1.Name = "txtNovoTelefone1";
            this.txtNovoTelefone1.Size = new System.Drawing.Size(87, 23);
            this.txtNovoTelefone1.TabIndex = 21;
            // 
            // txtNovoTelefone2
            // 
            this.txtNovoTelefone2.Location = new System.Drawing.Point(106, 262);
            this.txtNovoTelefone2.Mask = "(99) 00000-0000";
            this.txtNovoTelefone2.Name = "txtNovoTelefone2";
            this.txtNovoTelefone2.Size = new System.Drawing.Size(87, 23);
            this.txtNovoTelefone2.TabIndex = 22;
            // 
            // EditarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 345);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbBuscarCliente;
        private System.Windows.Forms.Button btnBucarCliente;
        private System.Windows.Forms.TextBox txtBuscarClienteEditar;
        private System.Windows.Forms.RadioButton rabBsucarClienteNome;
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
    }
}