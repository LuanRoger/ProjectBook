
namespace ProjectBook.GUI
{
    partial class CadastrarClientes
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnderecoCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCidadeCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEstadoCliente = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.btnSalvarCliente = new System.Windows.Forms.Button();
            this.btnLimparCliente = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTelefone1Cliente = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefone2Cliente = new System.Windows.Forms.MaskedTextBox();
            this.txtCepCliente = new System.Windows.Forms.MaskedTextBox();
            this.btnCancelarCadastrarClientes = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVerClientes = new System.Windows.Forms.ToolStripButton();
            this.btnPesquisarCliente = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Nome:";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(13, 43);
            this.txtNomeCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(364, 23);
            this.txtNomeCliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "*Endereço:";
            // 
            // txtEnderecoCliente
            // 
            this.txtEnderecoCliente.Location = new System.Drawing.Point(13, 93);
            this.txtEnderecoCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEnderecoCliente.Name = "txtEnderecoCliente";
            this.txtEnderecoCliente.Size = new System.Drawing.Size(297, 23);
            this.txtEnderecoCliente.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "*Cidade:";
            // 
            // txtCidadeCliente
            // 
            this.txtCidadeCliente.Location = new System.Drawing.Point(13, 142);
            this.txtCidadeCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCidadeCliente.Name = "txtCidadeCliente";
            this.txtCidadeCliente.Size = new System.Drawing.Size(297, 23);
            this.txtCidadeCliente.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "*UF:";
            // 
            // cmbEstadoCliente
            // 
            this.cmbEstadoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCliente.FormattingEnabled = true;
            this.cmbEstadoCliente.Items.AddRange(new object[] {
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
            this.cmbEstadoCliente.Location = new System.Drawing.Point(316, 93);
            this.cmbEstadoCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbEstadoCliente.Name = "cmbEstadoCliente";
            this.cmbEstadoCliente.Size = new System.Drawing.Size(61, 23);
            this.cmbEstadoCliente.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 172);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "*Telefone 1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 174);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "E-mail:";
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Location = new System.Drawing.Point(200, 191);
            this.txtEmailCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(178, 23);
            this.txtEmailCliente.TabIndex = 8;
            // 
            // btnSalvarCliente
            // 
            this.btnSalvarCliente.Image = global::ProjectBook.Properties.Resources.save;
            this.btnSalvarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarCliente.Location = new System.Drawing.Point(13, 235);
            this.btnSalvarCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSalvarCliente.Name = "btnSalvarCliente";
            this.btnSalvarCliente.Size = new System.Drawing.Size(64, 23);
            this.btnSalvarCliente.TabIndex = 9;
            this.btnSalvarCliente.Text = "Salvar";
            this.btnSalvarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarCliente.UseVisualStyleBackColor = true;
            this.btnSalvarCliente.Click += new System.EventHandler(this.btnSalvarCliente_Click);
            // 
            // btnLimparCliente
            // 
            this.btnLimparCliente.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCliente.Location = new System.Drawing.Point(219, 235);
            this.btnLimparCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimparCliente.Name = "btnLimparCliente";
            this.btnLimparCliente.Size = new System.Drawing.Size(68, 23);
            this.btnLimparCliente.TabIndex = 10;
            this.btnLimparCliente.Text = "Limpar";
            this.btnLimparCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparCliente.UseVisualStyleBackColor = true;
            this.btnLimparCliente.Click += new System.EventHandler(this.btnLimparCliente_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "CEP:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 174);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Telefone 2:";
            // 
            // txtTelefone1Cliente
            // 
            this.txtTelefone1Cliente.Location = new System.Drawing.Point(14, 191);
            this.txtTelefone1Cliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTelefone1Cliente.Mask = "(99) 00000-0000";
            this.txtTelefone1Cliente.Name = "txtTelefone1Cliente";
            this.txtTelefone1Cliente.Size = new System.Drawing.Size(87, 23);
            this.txtTelefone1Cliente.TabIndex = 6;
            // 
            // txtTelefone2Cliente
            // 
            this.txtTelefone2Cliente.Location = new System.Drawing.Point(105, 191);
            this.txtTelefone2Cliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTelefone2Cliente.Mask = "(99) 00000-0000";
            this.txtTelefone2Cliente.Name = "txtTelefone2Cliente";
            this.txtTelefone2Cliente.Size = new System.Drawing.Size(87, 23);
            this.txtTelefone2Cliente.TabIndex = 7;
            // 
            // txtCepCliente
            // 
            this.txtCepCliente.Location = new System.Drawing.Point(316, 142);
            this.txtCepCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCepCliente.Mask = "00000-000";
            this.txtCepCliente.Name = "txtCepCliente";
            this.txtCepCliente.Size = new System.Drawing.Size(61, 23);
            this.txtCepCliente.TabIndex = 5;
            // 
            // btnCancelarCadastrarClientes
            // 
            this.btnCancelarCadastrarClientes.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarCadastrarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarCadastrarClientes.Location = new System.Drawing.Point(294, 235);
            this.btnCancelarCadastrarClientes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelarCadastrarClientes.Name = "btnCancelarCadastrarClientes";
            this.btnCancelarCadastrarClientes.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCadastrarClientes.TabIndex = 11;
            this.btnCancelarCadastrarClientes.Text = "Cancelar";
            this.btnCancelarCadastrarClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarCadastrarClientes.UseVisualStyleBackColor = true;
            this.btnCancelarCadastrarClientes.Click += new System.EventHandler(this.btnCancelarCadastrarClientes_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerClientes,
            this.btnPesquisarCliente});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(383, 25);
            this.toolStrip1.TabIndex = 24;
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
            this.btnPesquisarCliente.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnPesquisarCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(23, 22);
            this.btnPesquisarCliente.Text = "Pesquisar cliente";
            // 
            // CadastrarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 267);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCancelarCadastrarClientes);
            this.Controls.Add(this.txtCepCliente);
            this.Controls.Add(this.txtTelefone2Cliente);
            this.Controls.Add(this.txtTelefone1Cliente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLimparCliente);
            this.Controls.Add(this.btnSalvarCliente);
            this.Controls.Add(this.txtEmailCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbEstadoCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCidadeCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEnderecoCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "CadastrarClientes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar clientes";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnCancelarCadastrarClientes;

        private System.Windows.Forms.MaskedTextBox txtCepCliente;

        private System.Windows.Forms.MaskedTextBox txtTelefone2Cliente;

        private System.Windows.Forms.MaskedTextBox txtTelefone1Cliente;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnderecoCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCidadeCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbEstadoCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Button btnSalvarCliente;
        private System.Windows.Forms.Button btnLimparCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnVerClientes;
        private System.Windows.Forms.ToolStripButton btnPesquisarCliente;
    }
}