
using ProjectBook.Model.Enums;

namespace ProjectBook.GUI
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
            this.rabBuscarNomeCliente = new System.Windows.Forms.RadioButton();
            this.rabBuscarTituloLivro = new System.Windows.Forms.RadioButton();
            this.txtBuscarAluguel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarEditarAluguel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNovoEdicaoLivro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNovoEditoraLivro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNovoAutorAluguel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNovoTituloLivroAluguel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBuscarNovoLivro = new System.Windows.Forms.Button();
            this.txtMudarLivroAluguel = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNovoEmailAluguel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNovoTelefoneAluguel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNovoEnderecoAluguel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNovoClienteAluguel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBuscarNovoCliente = new System.Windows.Forms.Button();
            this.txtMudarClienteAluguel = new System.Windows.Forms.TextBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rabBuscarNovoLivroAutor = new System.Windows.Forms.RadioButton();
            this.rabBuscarNovoLivroTitulo = new System.Windows.Forms.RadioButton();
            this.rabBuscarNovoLivroCodigo = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rabBuscarNovoClienteNome = new System.Windows.Forms.RadioButton();
            this.rabBuscarNovoClienteCodigo = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtAlugadoPorAluguel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTituloLivroAluguel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVerTodosAlugueis = new System.Windows.Forms.ToolStripButton();
            this.btnVerTodosLivros = new System.Windows.Forms.ToolStripButton();
            this.btnVerTodosClientes = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rabBuscarNomeCliente
            // 
            this.rabBuscarNomeCliente.AutoSize = true;
            this.rabBuscarNomeCliente.Location = new System.Drawing.Point(6, 21);
            this.rabBuscarNomeCliente.Name = "rabBuscarNomeCliente";
            this.rabBuscarNomeCliente.Size = new System.Drawing.Size(113, 19);
            this.rabBuscarNomeCliente.TabIndex = 0;
            this.rabBuscarNomeCliente.Text = "Nome do cliente";
            this.rabBuscarNomeCliente.UseVisualStyleBackColor = true;
            this.rabBuscarNomeCliente.CheckedChanged += new System.EventHandler(this.rabBuscarNomeCliente_CheckedChanged);
            // 
            // rabBuscarTituloLivro
            // 
            this.rabBuscarTituloLivro.AutoSize = true;
            this.rabBuscarTituloLivro.Location = new System.Drawing.Point(125, 21);
            this.rabBuscarTituloLivro.Name = "rabBuscarTituloLivro";
            this.rabBuscarTituloLivro.Size = new System.Drawing.Size(98, 19);
            this.rabBuscarTituloLivro.TabIndex = 1;
            this.rabBuscarTituloLivro.Text = "Titulo do livro";
            this.rabBuscarTituloLivro.UseVisualStyleBackColor = true;
            this.rabBuscarTituloLivro.CheckedChanged += new System.EventHandler(this.rabBuscarTituloLivro_CheckedChanged);
            // 
            // txtBuscarAluguel
            // 
            this.txtBuscarAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarAluguel.Location = new System.Drawing.Point(6, 46);
            this.txtBuscarAluguel.Name = "txtBuscarAluguel";
            this.txtBuscarAluguel.Size = new System.Drawing.Size(187, 23);
            this.txtBuscarAluguel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscarEditarAluguel);
            this.groupBox1.Controls.Add(this.rabBuscarNomeCliente);
            this.groupBox1.Controls.Add(this.txtBuscarAluguel);
            this.groupBox1.Controls.Add(this.rabBuscarTituloLivro);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // btnBuscarEditarAluguel
            // 
            this.btnBuscarEditarAluguel.FlatAppearance.BorderSize = 0;
            this.btnBuscarEditarAluguel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEditarAluguel.Image = global::ProjectBook.Properties.Resources.search;
            this.btnBuscarEditarAluguel.Location = new System.Drawing.Point(199, 46);
            this.btnBuscarEditarAluguel.Name = "btnBuscarEditarAluguel";
            this.btnBuscarEditarAluguel.Size = new System.Drawing.Size(24, 23);
            this.btnBuscarEditarAluguel.TabIndex = 3;
            this.btnBuscarEditarAluguel.UseVisualStyleBackColor = true;
            this.btnBuscarEditarAluguel.Click += new System.EventHandler(this.btnBuscarEditarAluguel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNovoEdicaoLivro);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtNovoEditoraLivro);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtNovoAutorAluguel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNovoTituloLivroAluguel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(250, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 173);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informações do livro";
            // 
            // txtNovoEdicaoLivro
            // 
            this.txtNovoEdicaoLivro.Location = new System.Drawing.Point(214, 135);
            this.txtNovoEdicaoLivro.Name = "txtNovoEdicaoLivro";
            this.txtNovoEdicaoLivro.Size = new System.Drawing.Size(182, 23);
            this.txtNovoEdicaoLivro.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Edição:";
            // 
            // txtNovoEditoraLivro
            // 
            this.txtNovoEditoraLivro.Location = new System.Drawing.Point(7, 135);
            this.txtNovoEditoraLivro.Name = "txtNovoEditoraLivro";
            this.txtNovoEditoraLivro.Size = new System.Drawing.Size(201, 23);
            this.txtNovoEditoraLivro.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Editora:";
            // 
            // txtNovoAutorAluguel
            // 
            this.txtNovoAutorAluguel.Enabled = false;
            this.txtNovoAutorAluguel.Location = new System.Drawing.Point(6, 87);
            this.txtNovoAutorAluguel.Name = "txtNovoAutorAluguel";
            this.txtNovoAutorAluguel.Size = new System.Drawing.Size(390, 23);
            this.txtNovoAutorAluguel.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Autor:";
            // 
            // txtNovoTituloLivroAluguel
            // 
            this.txtNovoTituloLivroAluguel.Enabled = false;
            this.txtNovoTituloLivroAluguel.Location = new System.Drawing.Point(6, 38);
            this.txtNovoTituloLivroAluguel.Name = "txtNovoTituloLivroAluguel";
            this.txtNovoTituloLivroAluguel.Size = new System.Drawing.Size(390, 23);
            this.txtNovoTituloLivroAluguel.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Titulo do livro:";
            // 
            // btnBuscarNovoLivro
            // 
            this.btnBuscarNovoLivro.FlatAppearance.BorderSize = 0;
            this.btnBuscarNovoLivro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNovoLivro.Image = global::ProjectBook.Properties.Resources.search;
            this.btnBuscarNovoLivro.Location = new System.Drawing.Point(200, 48);
            this.btnBuscarNovoLivro.Name = "btnBuscarNovoLivro";
            this.btnBuscarNovoLivro.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarNovoLivro.TabIndex = 6;
            this.btnBuscarNovoLivro.UseVisualStyleBackColor = true;
            this.btnBuscarNovoLivro.Click += new System.EventHandler(this.btnBuscarNovoLivro_Click);
            // 
            // txtMudarLivroAluguel
            // 
            this.txtMudarLivroAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtMudarLivroAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMudarLivroAluguel.Location = new System.Drawing.Point(7, 48);
            this.txtMudarLivroAluguel.Name = "txtMudarLivroAluguel";
            this.txtMudarLivroAluguel.Size = new System.Drawing.Size(187, 23);
            this.txtMudarLivroAluguel.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNovoEmailAluguel);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtNovoTelefoneAluguel);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtNovoEnderecoAluguel);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtNovoClienteAluguel);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(250, 298);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(402, 169);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Informações do cliente";
            // 
            // txtNovoEmailAluguel
            // 
            this.txtNovoEmailAluguel.Enabled = false;
            this.txtNovoEmailAluguel.Location = new System.Drawing.Point(214, 135);
            this.txtNovoEmailAluguel.Name = "txtNovoEmailAluguel";
            this.txtNovoEmailAluguel.Size = new System.Drawing.Size(182, 23);
            this.txtNovoEmailAluguel.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(214, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "E-mail:";
            // 
            // txtNovoTelefoneAluguel
            // 
            this.txtNovoTelefoneAluguel.Enabled = false;
            this.txtNovoTelefoneAluguel.Location = new System.Drawing.Point(6, 135);
            this.txtNovoTelefoneAluguel.Name = "txtNovoTelefoneAluguel";
            this.txtNovoTelefoneAluguel.Size = new System.Drawing.Size(201, 23);
            this.txtNovoTelefoneAluguel.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 15);
            this.label11.TabIndex = 9;
            this.label11.Text = "Telefone:";
            // 
            // txtNovoEnderecoAluguel
            // 
            this.txtNovoEnderecoAluguel.Enabled = false;
            this.txtNovoEnderecoAluguel.Location = new System.Drawing.Point(7, 86);
            this.txtNovoEnderecoAluguel.Name = "txtNovoEnderecoAluguel";
            this.txtNovoEnderecoAluguel.Size = new System.Drawing.Size(389, 23);
            this.txtNovoEnderecoAluguel.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Endereço:";
            // 
            // txtNovoClienteAluguel
            // 
            this.txtNovoClienteAluguel.Enabled = false;
            this.txtNovoClienteAluguel.Location = new System.Drawing.Point(7, 37);
            this.txtNovoClienteAluguel.Name = "txtNovoClienteAluguel";
            this.txtNovoClienteAluguel.Size = new System.Drawing.Size(389, 23);
            this.txtNovoClienteAluguel.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nome completo:";
            // 
            // btnBuscarNovoCliente
            // 
            this.btnBuscarNovoCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarNovoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarNovoCliente.Image = global::ProjectBook.Properties.Resources.search;
            this.btnBuscarNovoCliente.Location = new System.Drawing.Point(200, 48);
            this.btnBuscarNovoCliente.Name = "btnBuscarNovoCliente";
            this.btnBuscarNovoCliente.Size = new System.Drawing.Size(24, 23);
            this.btnBuscarNovoCliente.TabIndex = 7;
            this.btnBuscarNovoCliente.UseVisualStyleBackColor = true;
            this.btnBuscarNovoCliente.Click += new System.EventHandler(this.btnBuscarNovoCliente_Click);
            // 
            // txtMudarClienteAluguel
            // 
            this.txtMudarClienteAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtMudarClienteAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtMudarClienteAluguel.Location = new System.Drawing.Point(7, 48);
            this.txtMudarClienteAluguel.Name = "txtMudarClienteAluguel";
            this.txtMudarClienteAluguel.Size = new System.Drawing.Size(187, 23);
            this.txtMudarClienteAluguel.TabIndex = 3;
            // 
            // btnSalvarEditarAluguel
            // 
            this.btnSalvarEditarAluguel.Image = global::ProjectBook.Properties.Resources.save;
            this.btnSalvarEditarAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarEditarAluguel.Location = new System.Drawing.Point(13, 497);
            this.btnSalvarEditarAluguel.Name = "btnSalvarEditarAluguel";
            this.btnSalvarEditarAluguel.Size = new System.Drawing.Size(66, 23);
            this.btnSalvarEditarAluguel.TabIndex = 7;
            this.btnSalvarEditarAluguel.Text = "Salvar";
            this.btnSalvarEditarAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarEditarAluguel.UseVisualStyleBackColor = true;
            this.btnSalvarEditarAluguel.Click += new System.EventHandler(this.btnSalvarEditarAluguel_Click);
            // 
            // btnLimparTxtAluguel
            // 
            this.btnLimparTxtAluguel.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparTxtAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparTxtAluguel.Location = new System.Drawing.Point(501, 497);
            this.btnLimparTxtAluguel.Name = "btnLimparTxtAluguel";
            this.btnLimparTxtAluguel.Size = new System.Drawing.Size(67, 23);
            this.btnLimparTxtAluguel.TabIndex = 8;
            this.btnLimparTxtAluguel.Text = "Limpar";
            this.btnLimparTxtAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparTxtAluguel.UseVisualStyleBackColor = true;
            this.btnLimparTxtAluguel.Click += new System.EventHandler(this.btnLimparTxtAluguel_Click);
            // 
            // btnCancelarEditarAluguel
            // 
            this.btnCancelarEditarAluguel.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarEditarAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarEditarAluguel.Location = new System.Drawing.Point(574, 497);
            this.btnCancelarEditarAluguel.Name = "btnCancelarEditarAluguel";
            this.btnCancelarEditarAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarEditarAluguel.TabIndex = 9;
            this.btnCancelarEditarAluguel.Text = "Cancelar";
            this.btnCancelarEditarAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarEditarAluguel.UseVisualStyleBackColor = true;
            this.btnCancelarEditarAluguel.Click += new System.EventHandler(this.btnCancelarEditarAluguel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpEditarDataRecebimento);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.dtpEditarDataEntrega);
            this.groupBox5.Location = new System.Drawing.Point(12, 295);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(232, 126);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datas";
            // 
            // dtpEditarDataRecebimento
            // 
            this.dtpEditarDataRecebimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEditarDataRecebimento.Location = new System.Drawing.Point(7, 88);
            this.dtpEditarDataRecebimento.Name = "dtpEditarDataRecebimento";
            this.dtpEditarDataRecebimento.Size = new System.Drawing.Size(216, 23);
            this.dtpEditarDataRecebimento.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "Data de devolução:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "Data de saída:";
            // 
            // dtpEditarDataEntrega
            // 
            this.dtpEditarDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEditarDataEntrega.Location = new System.Drawing.Point(7, 39);
            this.dtpEditarDataEntrega.Name = "dtpEditarDataEntrega";
            this.dtpEditarDataEntrega.Size = new System.Drawing.Size(216, 23);
            this.dtpEditarDataEntrega.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 424);
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
            StatusAluguel.Alugado,
            StatusAluguel.Devolvido,
            StatusAluguel.Atrasado});
            this.cmbNovoStatus.Location = new System.Drawing.Point(12, 442);
            this.cmbNovoStatus.Name = "cmbNovoStatus";
            this.cmbNovoStatus.Size = new System.Drawing.Size(232, 23);
            this.cmbNovoStatus.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rabBuscarNovoLivroAutor);
            this.groupBox2.Controls.Add(this.rabBuscarNovoLivroTitulo);
            this.groupBox2.Controls.Add(this.rabBuscarNovoLivroCodigo);
            this.groupBox2.Controls.Add(this.btnBuscarNovoLivro);
            this.groupBox2.Controls.Add(this.txtMudarLivroAluguel);
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 82);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar livro";
            // 
            // rabBuscarNovoLivroAutor
            // 
            this.rabBuscarNovoLivroAutor.AutoSize = true;
            this.rabBuscarNovoLivroAutor.Location = new System.Drawing.Point(139, 23);
            this.rabBuscarNovoLivroAutor.Name = "rabBuscarNovoLivroAutor";
            this.rabBuscarNovoLivroAutor.Size = new System.Drawing.Size(55, 19);
            this.rabBuscarNovoLivroAutor.TabIndex = 9;
            this.rabBuscarNovoLivroAutor.Text = "Autor";
            this.rabBuscarNovoLivroAutor.UseVisualStyleBackColor = true;
            this.rabBuscarNovoLivroAutor.CheckedChanged += new System.EventHandler(this.rabBuscarNovoLivroAutor_CheckedChanged);
            // 
            // rabBuscarNovoLivroTitulo
            // 
            this.rabBuscarNovoLivroTitulo.AutoSize = true;
            this.rabBuscarNovoLivroTitulo.Location = new System.Drawing.Point(77, 23);
            this.rabBuscarNovoLivroTitulo.Name = "rabBuscarNovoLivroTitulo";
            this.rabBuscarNovoLivroTitulo.Size = new System.Drawing.Size(55, 19);
            this.rabBuscarNovoLivroTitulo.TabIndex = 8;
            this.rabBuscarNovoLivroTitulo.Text = "Titulo";
            this.rabBuscarNovoLivroTitulo.UseVisualStyleBackColor = true;
            this.rabBuscarNovoLivroTitulo.CheckedChanged += new System.EventHandler(this.rabBuscarNovoLivroTitulo_CheckedChanged);
            // 
            // rabBuscarNovoLivroCodigo
            // 
            this.rabBuscarNovoLivroCodigo.AutoSize = true;
            this.rabBuscarNovoLivroCodigo.Checked = true;
            this.rabBuscarNovoLivroCodigo.Location = new System.Drawing.Point(7, 23);
            this.rabBuscarNovoLivroCodigo.Name = "rabBuscarNovoLivroCodigo";
            this.rabBuscarNovoLivroCodigo.Size = new System.Drawing.Size(64, 19);
            this.rabBuscarNovoLivroCodigo.TabIndex = 7;
            this.rabBuscarNovoLivroCodigo.TabStop = true;
            this.rabBuscarNovoLivroCodigo.Text = "Código";
            this.rabBuscarNovoLivroCodigo.UseVisualStyleBackColor = true;
            this.rabBuscarNovoLivroCodigo.CheckedChanged += new System.EventHandler(this.rabBuscarNovoLivroCodigo_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rabBuscarNovoClienteNome);
            this.groupBox6.Controls.Add(this.rabBuscarNovoClienteCodigo);
            this.groupBox6.Controls.Add(this.txtMudarClienteAluguel);
            this.groupBox6.Controls.Add(this.btnBuscarNovoCliente);
            this.groupBox6.Location = new System.Drawing.Point(12, 191);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(232, 82);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Buscar cliente";
            // 
            // rabBuscarNovoClienteNome
            // 
            this.rabBuscarNovoClienteNome.AutoSize = true;
            this.rabBuscarNovoClienteNome.Location = new System.Drawing.Point(136, 23);
            this.rabBuscarNovoClienteNome.Name = "rabBuscarNovoClienteNome";
            this.rabBuscarNovoClienteNome.Size = new System.Drawing.Size(58, 19);
            this.rabBuscarNovoClienteNome.TabIndex = 9;
            this.rabBuscarNovoClienteNome.Text = "Nome";
            this.rabBuscarNovoClienteNome.UseVisualStyleBackColor = true;
            this.rabBuscarNovoClienteNome.CheckedChanged += new System.EventHandler(this.rabBuscarNovoClienteNome_CheckedChanged);
            // 
            // rabBuscarNovoClienteCodigo
            // 
            this.rabBuscarNovoClienteCodigo.AutoSize = true;
            this.rabBuscarNovoClienteCodigo.Checked = true;
            this.rabBuscarNovoClienteCodigo.Location = new System.Drawing.Point(7, 23);
            this.rabBuscarNovoClienteCodigo.Name = "rabBuscarNovoClienteCodigo";
            this.rabBuscarNovoClienteCodigo.Size = new System.Drawing.Size(64, 19);
            this.rabBuscarNovoClienteCodigo.TabIndex = 8;
            this.rabBuscarNovoClienteCodigo.TabStop = true;
            this.rabBuscarNovoClienteCodigo.Text = "Código";
            this.rabBuscarNovoClienteCodigo.UseVisualStyleBackColor = true;
            this.rabBuscarNovoClienteCodigo.CheckedChanged += new System.EventHandler(this.rabBuscarNovoClienteCodigo_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtAlugadoPorAluguel);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txtTituloLivroAluguel);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(250, 28);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(402, 85);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Informações do aluguel";
            // 
            // txtAlugadoPorAluguel
            // 
            this.txtAlugadoPorAluguel.Location = new System.Drawing.Point(218, 39);
            this.txtAlugadoPorAluguel.Name = "txtAlugadoPorAluguel";
            this.txtAlugadoPorAluguel.Size = new System.Drawing.Size(178, 23);
            this.txtAlugadoPorAluguel.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Alugado por:";
            // 
            // txtTituloLivroAluguel
            // 
            this.txtTituloLivroAluguel.Location = new System.Drawing.Point(7, 39);
            this.txtTituloLivroAluguel.Name = "txtTituloLivroAluguel";
            this.txtTituloLivroAluguel.Size = new System.Drawing.Size(200, 23);
            this.txtTituloLivroAluguel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Titulo do livro:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerTodosAlugueis,
            this.btnVerTodosLivros,
            this.btnVerTodosClientes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(660, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnVerTodosAlugueis
            // 
            this.btnVerTodosAlugueis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVerTodosAlugueis.Image = global::ProjectBook.Properties.Resources.page_go;
            this.btnVerTodosAlugueis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerTodosAlugueis.Name = "btnVerTodosAlugueis";
            this.btnVerTodosAlugueis.Size = new System.Drawing.Size(23, 22);
            this.btnVerTodosAlugueis.Text = "toolStripButton1";
            this.btnVerTodosAlugueis.ToolTipText = "Ver livros alugados";
            // 
            // btnVerTodosLivros
            // 
            this.btnVerTodosLivros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVerTodosLivros.Image = global::ProjectBook.Properties.Resources.book_go;
            this.btnVerTodosLivros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerTodosLivros.Name = "btnVerTodosLivros";
            this.btnVerTodosLivros.Size = new System.Drawing.Size(23, 22);
            this.btnVerTodosLivros.Text = "toolStripButton1";
            this.btnVerTodosLivros.ToolTipText = "Ver livros cadastrados";
            // 
            // btnVerTodosClientes
            // 
            this.btnVerTodosClientes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVerTodosClientes.Image = global::ProjectBook.Properties.Resources.client_go;
            this.btnVerTodosClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerTodosClientes.Name = "btnVerTodosClientes";
            this.btnVerTodosClientes.Size = new System.Drawing.Size(23, 22);
            this.btnVerTodosClientes.Text = "toolStripButton1";
            this.btnVerTodosClientes.ToolTipText = "Ver clientes cadastrados";
            // 
            // EditarAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 532);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNovoClienteAluguel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMudarClienteAluguel;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rabBuscarNovoLivroAutor;
        private System.Windows.Forms.RadioButton rabBuscarNovoLivroTitulo;
        private System.Windows.Forms.RadioButton rabBuscarNovoLivroCodigo;
        private System.Windows.Forms.TextBox txtNovoEdicaoLivro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNovoEditoraLivro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rabBuscarNovoClienteNome;
        private System.Windows.Forms.RadioButton rabBuscarNovoClienteCodigo;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtAlugadoPorAluguel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTituloLivroAluguel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnVerTodosAlugueis;
        private System.Windows.Forms.ToolStripButton btnVerTodosLivros;
        private System.Windows.Forms.ToolStripButton btnVerTodosClientes;
    }
}