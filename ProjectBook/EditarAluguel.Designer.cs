
namespace ProjectBook
{
    partial class EditarAluguel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarAluguel));
            this.rabBuscarNomeCliente = new System.Windows.Forms.RadioButton();
            this.rabBuscarTituloLivro = new System.Windows.Forms.RadioButton();
            this.txtBuscarAluguel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarEditarAluguel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscarNovoLivro = new System.Windows.Forms.Button();
            this.txtNovoAutorAluguel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNovoTituloLivroAluguel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMudarLivroAluguel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNovoEmailAluguel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNovoTelefoneAluguel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNovoEnderecoAluguel = new System.Windows.Forms.TextBox();
            this.btnBuscarNovoCliente = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNovoClienteAluguel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMudarClienteAluguel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSalvarEditarAluguel = new System.Windows.Forms.Button();
            this.btnLimparTxtAluguel = new System.Windows.Forms.Button();
            this.btnCancelarEditarAluguel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpEditarDataRecebimento = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpEditarDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNovoStatus = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // rabBuscarNomeCliente
            // 
            this.rabBuscarNomeCliente.AutoSize = true;
            this.rabBuscarNomeCliente.Location = new System.Drawing.Point(6, 21);
            this.rabBuscarNomeCliente.Name = "rabBuscarNomeCliente";
            this.rabBuscarNomeCliente.Size = new System.Drawing.Size(113, 19);
            this.rabBuscarNomeCliente.TabIndex = 0;
            this.rabBuscarNomeCliente.TabStop = true;
            this.rabBuscarNomeCliente.Text = "Nome do cliente";
            this.rabBuscarNomeCliente.UseVisualStyleBackColor = true;
            // 
            // rabBuscarTituloLivro
            // 
            this.rabBuscarTituloLivro.AutoSize = true;
            this.rabBuscarTituloLivro.Location = new System.Drawing.Point(267, 21);
            this.rabBuscarTituloLivro.Name = "rabBuscarTituloLivro";
            this.rabBuscarTituloLivro.Size = new System.Drawing.Size(98, 19);
            this.rabBuscarTituloLivro.TabIndex = 1;
            this.rabBuscarTituloLivro.TabStop = true;
            this.rabBuscarTituloLivro.Text = "Titulo do livro";
            this.rabBuscarTituloLivro.UseVisualStyleBackColor = true;
            // 
            // txtBuscarAluguel
            // 
            this.txtBuscarAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuscarAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarAluguel.Location = new System.Drawing.Point(6, 46);
            this.txtBuscarAluguel.Name = "txtBuscarAluguel";
            this.txtBuscarAluguel.Size = new System.Drawing.Size(359, 23);
            this.txtBuscarAluguel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarEditarAluguel);
            this.groupBox1.Controls.Add(this.rabBuscarNomeCliente);
            this.groupBox1.Controls.Add(this.txtBuscarAluguel);
            this.groupBox1.Controls.Add(this.rabBuscarTituloLivro);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // btnBuscarEditarAluguel
            // 
            this.btnBuscarEditarAluguel.FlatAppearance.BorderSize = 0;
            this.btnBuscarEditarAluguel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEditarAluguel.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarEditarAluguel.Image")));
            this.btnBuscarEditarAluguel.Location = new System.Drawing.Point(371, 46);
            this.btnBuscarEditarAluguel.Name = "btnBuscarEditarAluguel";
            this.btnBuscarEditarAluguel.Size = new System.Drawing.Size(24, 23);
            this.btnBuscarEditarAluguel.TabIndex = 3;
            this.btnBuscarEditarAluguel.UseVisualStyleBackColor = true;
            this.btnBuscarEditarAluguel.Click += new System.EventHandler(this.btnBuscarEditarAluguel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBuscarNovoLivro);
            this.groupBox3.Controls.Add(this.txtNovoAutorAluguel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNovoTituloLivroAluguel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtMudarLivroAluguel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 154);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Livro";
            // 
            // btnBuscarNovoLivro
            // 
            this.btnBuscarNovoLivro.FlatAppearance.BorderSize = 0;
            this.btnBuscarNovoLivro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNovoLivro.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarNovoLivro.Image")));
            this.btnBuscarNovoLivro.Location = new System.Drawing.Point(368, 17);
            this.btnBuscarNovoLivro.Name = "btnBuscarNovoLivro";
            this.btnBuscarNovoLivro.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarNovoLivro.TabIndex = 6;
            this.btnBuscarNovoLivro.UseVisualStyleBackColor = true;
            this.btnBuscarNovoLivro.Click += new System.EventHandler(this.btnBuscarNovoLivro_Click);
            // 
            // txtNovoAutorAluguel
            // 
            this.txtNovoAutorAluguel.Enabled = false;
            this.txtNovoAutorAluguel.Location = new System.Drawing.Point(6, 117);
            this.txtNovoAutorAluguel.Name = "txtNovoAutorAluguel";
            this.txtNovoAutorAluguel.Size = new System.Drawing.Size(390, 23);
            this.txtNovoAutorAluguel.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Autor:";
            // 
            // txtNovoTituloLivroAluguel
            // 
            this.txtNovoTituloLivroAluguel.Enabled = false;
            this.txtNovoTituloLivroAluguel.Location = new System.Drawing.Point(6, 68);
            this.txtNovoTituloLivroAluguel.Name = "txtNovoTituloLivroAluguel";
            this.txtNovoTituloLivroAluguel.Size = new System.Drawing.Size(390, 23);
            this.txtNovoTituloLivroAluguel.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Titulo do livro:";
            // 
            // txtMudarLivroAluguel
            // 
            this.txtMudarLivroAluguel.Location = new System.Drawing.Point(75, 17);
            this.txtMudarLivroAluguel.Name = "txtMudarLivroAluguel";
            this.txtMudarLivroAluguel.Size = new System.Drawing.Size(287, 23);
            this.txtMudarLivroAluguel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Trocar por:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNovoEmailAluguel);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtNovoTelefoneAluguel);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtNovoEnderecoAluguel);
            this.groupBox4.Controls.Add(this.btnBuscarNovoCliente);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtNovoClienteAluguel);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtMudarClienteAluguel);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(12, 265);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 211);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cliente";
            // 
            // txtNovoEmailAluguel
            // 
            this.txtNovoEmailAluguel.Enabled = false;
            this.txtNovoEmailAluguel.Location = new System.Drawing.Point(214, 171);
            this.txtNovoEmailAluguel.Name = "txtNovoEmailAluguel";
            this.txtNovoEmailAluguel.Size = new System.Drawing.Size(182, 23);
            this.txtNovoEmailAluguel.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(214, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "E-mail:";
            // 
            // txtNovoTelefoneAluguel
            // 
            this.txtNovoTelefoneAluguel.Enabled = false;
            this.txtNovoTelefoneAluguel.Location = new System.Drawing.Point(6, 171);
            this.txtNovoTelefoneAluguel.Name = "txtNovoTelefoneAluguel";
            this.txtNovoTelefoneAluguel.Size = new System.Drawing.Size(201, 23);
            this.txtNovoTelefoneAluguel.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Telefone:";
            // 
            // txtNovoEnderecoAluguel
            // 
            this.txtNovoEnderecoAluguel.Enabled = false;
            this.txtNovoEnderecoAluguel.Location = new System.Drawing.Point(7, 122);
            this.txtNovoEnderecoAluguel.Name = "txtNovoEnderecoAluguel";
            this.txtNovoEnderecoAluguel.Size = new System.Drawing.Size(389, 23);
            this.txtNovoEnderecoAluguel.TabIndex = 8;
            // 
            // btnBuscarNovoCliente
            // 
            this.btnBuscarNovoCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarNovoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNovoCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarNovoCliente.Image")));
            this.btnBuscarNovoCliente.Location = new System.Drawing.Point(368, 21);
            this.btnBuscarNovoCliente.Name = "btnBuscarNovoCliente";
            this.btnBuscarNovoCliente.Size = new System.Drawing.Size(24, 23);
            this.btnBuscarNovoCliente.TabIndex = 7;
            this.btnBuscarNovoCliente.UseVisualStyleBackColor = true;
            this.btnBuscarNovoCliente.Click += new System.EventHandler(this.btnBuscarNovoCliente_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Endereço:";
            // 
            // txtNovoClienteAluguel
            // 
            this.txtNovoClienteAluguel.Enabled = false;
            this.txtNovoClienteAluguel.Location = new System.Drawing.Point(7, 73);
            this.txtNovoClienteAluguel.Name = "txtNovoClienteAluguel";
            this.txtNovoClienteAluguel.Size = new System.Drawing.Size(389, 23);
            this.txtNovoClienteAluguel.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nome completo:";
            // 
            // txtMudarClienteAluguel
            // 
            this.txtMudarClienteAluguel.Location = new System.Drawing.Point(76, 20);
            this.txtMudarClienteAluguel.Name = "txtMudarClienteAluguel";
            this.txtMudarClienteAluguel.Size = new System.Drawing.Size(286, 23);
            this.txtMudarClienteAluguel.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Trocar por:";
            // 
            // btnSalvarEditarAluguel
            // 
            this.btnSalvarEditarAluguel.Location = new System.Drawing.Point(12, 493);
            this.btnSalvarEditarAluguel.Name = "btnSalvarEditarAluguel";
            this.btnSalvarEditarAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarEditarAluguel.TabIndex = 7;
            this.btnSalvarEditarAluguel.Text = "Salvar";
            this.btnSalvarEditarAluguel.UseVisualStyleBackColor = true;
            this.btnSalvarEditarAluguel.Click += new System.EventHandler(this.btnSalvarEditarAluguel_Click);
            // 
            // btnLimparTxtAluguel
            // 
            this.btnLimparTxtAluguel.Location = new System.Drawing.Point(460, 493);
            this.btnLimparTxtAluguel.Name = "btnLimparTxtAluguel";
            this.btnLimparTxtAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnLimparTxtAluguel.TabIndex = 8;
            this.btnLimparTxtAluguel.Text = "Limpar";
            this.btnLimparTxtAluguel.UseVisualStyleBackColor = true;
            this.btnLimparTxtAluguel.Click += new System.EventHandler(this.btnLimparTxtAluguel_Click);
            // 
            // btnCancelarEditarAluguel
            // 
            this.btnCancelarEditarAluguel.Location = new System.Drawing.Point(541, 493);
            this.btnCancelarEditarAluguel.Name = "btnCancelarEditarAluguel";
            this.btnCancelarEditarAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarEditarAluguel.TabIndex = 9;
            this.btnCancelarEditarAluguel.Text = "Cancelar";
            this.btnCancelarEditarAluguel.UseVisualStyleBackColor = true;
            this.btnCancelarEditarAluguel.Click += new System.EventHandler(this.btnCancelarEditarAluguel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpEditarDataRecebimento);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.dtpEditarDataEntrega);
            this.groupBox5.Location = new System.Drawing.Point(420, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 126);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datas";
            // 
            // dtpEditarDataRecebimento
            // 
            this.dtpEditarDataRecebimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEditarDataRecebimento.Location = new System.Drawing.Point(7, 88);
            this.dtpEditarDataRecebimento.Name = "dtpEditarDataRecebimento";
            this.dtpEditarDataRecebimento.Size = new System.Drawing.Size(187, 23);
            this.dtpEditarDataRecebimento.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "Data de recebimento:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "Data de entrega:";
            // 
            // dtpEditarDataEntrega
            // 
            this.dtpEditarDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEditarDataEntrega.Location = new System.Drawing.Point(7, 39);
            this.dtpEditarDataEntrega.Name = "dtpEditarDataEntrega";
            this.dtpEditarDataEntrega.Size = new System.Drawing.Size(187, 23);
            this.dtpEditarDataEntrega.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Status:";
            // 
            // cmbNovoStatus
            // 
            this.cmbNovoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovoStatus.FormattingEnabled = true;
            this.cmbNovoStatus.Items.AddRange(new object[] {
            "Pendente",
            "Devolvido"});
            this.cmbNovoStatus.Location = new System.Drawing.Point(468, 142);
            this.cmbNovoStatus.Name = "cmbNovoStatus";
            this.cmbNovoStatus.Size = new System.Drawing.Size(146, 23);
            this.cmbNovoStatus.TabIndex = 12;
            // 
            // EditarAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 528);
            this.Controls.Add(this.cmbNovoStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnCancelarEditarAluguel);
            this.Controls.Add(this.btnLimparTxtAluguel);
            this.Controls.Add(this.btnSalvarEditarAluguel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "EditarAluguel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar aluguel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rabBuscarNomeCliente;
        private System.Windows.Forms.RadioButton rabBuscarTituloLivro;
        private System.Windows.Forms.TextBox txtBuscarAluguel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarEditarAluguel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscarNovoLivro;
        private System.Windows.Forms.TextBox txtNovoAutorAluguel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNovoTituloLivroAluguel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMudarLivroAluguel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNovoClienteAluguel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMudarClienteAluguel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNovoEnderecoAluguel;
        private System.Windows.Forms.Button btnBuscarNovoCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNovoTelefoneAluguel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNovoEmailAluguel;
        private System.Windows.Forms.Button btnSalvarEditarAluguel;
        private System.Windows.Forms.Button btnLimparTxtAluguel;
        private System.Windows.Forms.Button btnCancelarEditarAluguel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtpEditarDataRecebimento;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpEditarDataEntrega;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNovoStatus;
    }
}