
namespace ProjectBook.GUI
{
    partial class CadastrarAluguel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastrarAluguel));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBuscarLivroAluguel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarLivroAluguel = new System.Windows.Forms.Button();
            this.txtAutorLivroAluguel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTituloLivroAluguel = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpDataRecebimento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalvarAluguel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmailClienteAluguel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTelefoneClienteAluguel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEnderecoClienteAluguel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNomeClienteAluguel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarClienteAluguel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnLimparCadastroAluguel = new System.Windows.Forms.Button();
            this.btnCancelarCadastroAluguel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBuscarLivroAluguel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBuscarLivroAluguel);
            this.groupBox1.Controls.Add(this.txtAutorLivroAluguel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTituloLivroAluguel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do livro";
            // 
            // txtBuscarLivroAluguel
            // 
            this.txtBuscarLivroAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarLivroAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarLivroAluguel.Location = new System.Drawing.Point(110, 19);
            this.txtBuscarLivroAluguel.Name = "txtBuscarLivroAluguel";
            this.txtBuscarLivroAluguel.Size = new System.Drawing.Size(258, 23);
            this.txtBuscarLivroAluguel.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Buscar por titulo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autor:";
            // 
            // btnBuscarLivroAluguel
            // 
            this.btnBuscarLivroAluguel.FlatAppearance.BorderSize = 0;
            this.btnBuscarLivroAluguel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarLivroAluguel.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarLivroAluguel.Image")));
            this.btnBuscarLivroAluguel.Location = new System.Drawing.Point(374, 19);
            this.btnBuscarLivroAluguel.Name = "btnBuscarLivroAluguel";
            this.btnBuscarLivroAluguel.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarLivroAluguel.TabIndex = 4;
            this.btnBuscarLivroAluguel.UseVisualStyleBackColor = true;
            this.btnBuscarLivroAluguel.Click += new System.EventHandler(this.btnBuscarLivroAluguel_Click);
            // 
            // txtAutorLivroAluguel
            // 
            this.txtAutorLivroAluguel.Enabled = false;
            this.txtAutorLivroAluguel.Location = new System.Drawing.Point(7, 125);
            this.txtAutorLivroAluguel.Name = "txtAutorLivroAluguel";
            this.txtAutorLivroAluguel.Size = new System.Drawing.Size(361, 23);
            this.txtAutorLivroAluguel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Titulo do livro:";
            // 
            // txtTituloLivroAluguel
            // 
            this.txtTituloLivroAluguel.Enabled = false;
            this.txtTituloLivroAluguel.Location = new System.Drawing.Point(7, 71);
            this.txtTituloLivroAluguel.Name = "txtTituloLivroAluguel";
            this.txtTituloLivroAluguel.Size = new System.Drawing.Size(361, 23);
            this.txtTituloLivroAluguel.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpDataRecebimento);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtpDataEntrega);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(421, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 119);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dados de aquisição";
            // 
            // dtpDataRecebimento
            // 
            this.dtpDataRecebimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRecebimento.Location = new System.Drawing.Point(7, 89);
            this.dtpDataRecebimento.Name = "dtpDataRecebimento";
            this.dtpDataRecebimento.Size = new System.Drawing.Size(137, 23);
            this.dtpDataRecebimento.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Data devolução:";
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrega.Location = new System.Drawing.Point(6, 41);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(138, 23);
            this.dtpDataEntrega.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Data saída:";
            // 
            // btnSalvarAluguel
            // 
            this.btnSalvarAluguel.Image = global::ProjectBook.Properties.Images.Images.save;
            this.btnSalvarAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarAluguel.Location = new System.Drawing.Point(12, 399);
            this.btnSalvarAluguel.Name = "btnSalvarAluguel";
            this.btnSalvarAluguel.Size = new System.Drawing.Size(66, 23);
            this.btnSalvarAluguel.TabIndex = 3;
            this.btnSalvarAluguel.Text = "Salvar";
            this.btnSalvarAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarAluguel.UseVisualStyleBackColor = true;
            this.btnSalvarAluguel.Click += new System.EventHandler(this.btnSalvarAluguel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmailClienteAluguel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTelefoneClienteAluguel);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtEnderecoClienteAluguel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNomeClienteAluguel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtBuscarClienteAluguel);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnBuscarCliente);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 209);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações do cliente";
            // 
            // txtEmailClienteAluguel
            // 
            this.txtEmailClienteAluguel.Enabled = false;
            this.txtEmailClienteAluguel.Location = new System.Drawing.Point(216, 170);
            this.txtEmailClienteAluguel.Name = "txtEmailClienteAluguel";
            this.txtEmailClienteAluguel.Size = new System.Drawing.Size(152, 23);
            this.txtEmailClienteAluguel.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Email:";
            // 
            // txtTelefoneClienteAluguel
            // 
            this.txtTelefoneClienteAluguel.Enabled = false;
            this.txtTelefoneClienteAluguel.Location = new System.Drawing.Point(7, 170);
            this.txtTelefoneClienteAluguel.Name = "txtTelefoneClienteAluguel";
            this.txtTelefoneClienteAluguel.Size = new System.Drawing.Size(202, 23);
            this.txtTelefoneClienteAluguel.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Telefone 1:";
            // 
            // txtEnderecoClienteAluguel
            // 
            this.txtEnderecoClienteAluguel.Enabled = false;
            this.txtEnderecoClienteAluguel.Location = new System.Drawing.Point(7, 121);
            this.txtEnderecoClienteAluguel.Name = "txtEnderecoClienteAluguel";
            this.txtEnderecoClienteAluguel.Size = new System.Drawing.Size(361, 23);
            this.txtEnderecoClienteAluguel.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Endereço:";
            // 
            // txtNomeClienteAluguel
            // 
            this.txtNomeClienteAluguel.Enabled = false;
            this.txtNomeClienteAluguel.Location = new System.Drawing.Point(7, 72);
            this.txtNomeClienteAluguel.Name = "txtNomeClienteAluguel";
            this.txtNomeClienteAluguel.Size = new System.Drawing.Size(361, 23);
            this.txtNomeClienteAluguel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nome completo:";
            // 
            // txtBuscarClienteAluguel
            // 
            this.txtBuscarClienteAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarClienteAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarClienteAluguel.Location = new System.Drawing.Point(114, 23);
            this.txtBuscarClienteAluguel.Name = "txtBuscarClienteAluguel";
            this.txtBuscarClienteAluguel.Size = new System.Drawing.Size(254, 23);
            this.txtBuscarClienteAluguel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar por nome:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.Image")));
            this.btnBuscarCliente.Location = new System.Drawing.Point(374, 23);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 4;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnLimparCadastroAluguel
            // 
            this.btnLimparCadastroAluguel.Image = global::ProjectBook.Properties.Images.Images.textfield;
            this.btnLimparCadastroAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCadastroAluguel.Location = new System.Drawing.Point(421, 399);
            this.btnLimparCadastroAluguel.Name = "btnLimparCadastroAluguel";
            this.btnLimparCadastroAluguel.Size = new System.Drawing.Size(69, 23);
            this.btnLimparCadastroAluguel.TabIndex = 5;
            this.btnLimparCadastroAluguel.Text = "Limpar";
            this.btnLimparCadastroAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparCadastroAluguel.UseVisualStyleBackColor = true;
            this.btnLimparCadastroAluguel.Click += new System.EventHandler(this.btnLimparCadastroAluguel_Click);
            // 
            // btnCancelarCadastroAluguel
            // 
            this.btnCancelarCadastroAluguel.Image = global::ProjectBook.Properties.Images.Images.cancel;
            this.btnCancelarCadastroAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarCadastroAluguel.Location = new System.Drawing.Point(496, 399);
            this.btnCancelarCadastroAluguel.Name = "btnCancelarCadastroAluguel";
            this.btnCancelarCadastroAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCadastroAluguel.TabIndex = 6;
            this.btnCancelarCadastroAluguel.Text = "Cancelar";
            this.btnCancelarCadastroAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarCadastroAluguel.UseVisualStyleBackColor = true;
            this.btnCancelarCadastroAluguel.Click += new System.EventHandler(this.btnCancelarCadastroAluguel_Click);
            // 
            // CadastrarAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 434);
            this.Controls.Add(this.btnCancelarCadastroAluguel);
            this.Controls.Add(this.btnLimparCadastroAluguel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalvarAluguel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CadastrarAluguel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar aluguel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarLivroAluguel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutorLivroAluguel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTituloLivroAluguel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpDataRecebimento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDataEntrega;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalvarAluguel;
        private System.Windows.Forms.TextBox txtBuscarLivroAluguel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmailClienteAluguel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTelefoneClienteAluguel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEnderecoClienteAluguel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNomeClienteAluguel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscarClienteAluguel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnLimparCadastroAluguel;
        private System.Windows.Forms.Button btnCancelarCadastroAluguel;
    }
}