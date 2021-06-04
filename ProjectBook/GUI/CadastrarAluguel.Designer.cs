
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEdicaoLivro = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEditoraLivro = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutorLivroAluguel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTituloLivroAluguel = new System.Windows.Forms.TextBox();
            this.txtBuscarLivroAluguel = new System.Windows.Forms.TextBox();
            this.btnBuscarLivroAluguel = new System.Windows.Forms.Button();
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
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnLimparCadastroAluguel = new System.Windows.Forms.Button();
            this.btnCancelarCadastroAluguel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rabPesquisarLivroAutor = new System.Windows.Forms.RadioButton();
            this.rabPesquisarLivroTitulo = new System.Windows.Forms.RadioButton();
            this.rabPesquisarLivroCodigo = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rabPesquisarClienteNome = new System.Windows.Forms.RadioButton();
            this.rabPesquisarClienteCodigo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatusAluguel = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVerLivros = new System.Windows.Forms.ToolStripButton();
            this.btnVerClientes = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEdicaoLivro);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtEditoraLivro);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAutorLivroAluguel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTituloLivroAluguel);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(244, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do livro";
            // 
            // txtEdicaoLivro
            // 
            this.txtEdicaoLivro.Location = new System.Drawing.Point(215, 139);
            this.txtEdicaoLivro.Name = "txtEdicaoLivro";
            this.txtEdicaoLivro.Size = new System.Drawing.Size(158, 23);
            this.txtEdicaoLivro.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(209, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Edição:";
            // 
            // txtEditoraLivro
            // 
            this.txtEditoraLivro.Location = new System.Drawing.Point(7, 139);
            this.txtEditoraLivro.Name = "txtEditoraLivro";
            this.txtEditoraLivro.Size = new System.Drawing.Size(202, 23);
            this.txtEditoraLivro.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "Editora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Autor:";
            // 
            // txtAutorLivroAluguel
            // 
            this.txtAutorLivroAluguel.Enabled = false;
            this.txtAutorLivroAluguel.Location = new System.Drawing.Point(7, 91);
            this.txtAutorLivroAluguel.Name = "txtAutorLivroAluguel";
            this.txtAutorLivroAluguel.Size = new System.Drawing.Size(366, 23);
            this.txtAutorLivroAluguel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Titulo do livro:";
            // 
            // txtTituloLivroAluguel
            // 
            this.txtTituloLivroAluguel.Enabled = false;
            this.txtTituloLivroAluguel.Location = new System.Drawing.Point(7, 37);
            this.txtTituloLivroAluguel.Name = "txtTituloLivroAluguel";
            this.txtTituloLivroAluguel.Size = new System.Drawing.Size(366, 23);
            this.txtTituloLivroAluguel.TabIndex = 0;
            // 
            // txtBuscarLivroAluguel
            // 
            this.txtBuscarLivroAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarLivroAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarLivroAluguel.Location = new System.Drawing.Point(6, 48);
            this.txtBuscarLivroAluguel.Name = "txtBuscarLivroAluguel";
            this.txtBuscarLivroAluguel.Size = new System.Drawing.Size(187, 23);
            this.txtBuscarLivroAluguel.TabIndex = 1;
            // 
            // btnBuscarLivroAluguel
            // 
            this.btnBuscarLivroAluguel.FlatAppearance.BorderSize = 0;
            this.btnBuscarLivroAluguel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarLivroAluguel.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnBuscarLivroAluguel.Location = new System.Drawing.Point(199, 48);
            this.btnBuscarLivroAluguel.Name = "btnBuscarLivroAluguel";
            this.btnBuscarLivroAluguel.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarLivroAluguel.TabIndex = 4;
            this.btnBuscarLivroAluguel.UseVisualStyleBackColor = true;
            this.btnBuscarLivroAluguel.Click += new System.EventHandler(this.btnBuscarLivroAluguel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpDataRecebimento);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.dtpDataEntrega);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(226, 119);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datas";
            // 
            // dtpDataRecebimento
            // 
            this.dtpDataRecebimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRecebimento.Location = new System.Drawing.Point(7, 89);
            this.dtpDataRecebimento.Name = "dtpDataRecebimento";
            this.dtpDataRecebimento.Size = new System.Drawing.Size(213, 23);
            this.dtpDataRecebimento.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Data de devolução:";
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrega.Location = new System.Drawing.Point(6, 41);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(214, 23);
            this.dtpDataEntrega.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Data de saída:";
            // 
            // btnSalvarAluguel
            // 
            this.btnSalvarAluguel.Image = global::ProjectBook.Properties.Resources.save;
            this.btnSalvarAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarAluguel.Location = new System.Drawing.Point(12, 424);
            this.btnSalvarAluguel.Name = "btnSalvarAluguel";
            this.btnSalvarAluguel.Size = new System.Drawing.Size(66, 23);
            this.btnSalvarAluguel.TabIndex = 6;
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
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(244, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 172);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações do cliente";
            // 
            // txtEmailClienteAluguel
            // 
            this.txtEmailClienteAluguel.Enabled = false;
            this.txtEmailClienteAluguel.Location = new System.Drawing.Point(215, 135);
            this.txtEmailClienteAluguel.Name = "txtEmailClienteAluguel";
            this.txtEmailClienteAluguel.Size = new System.Drawing.Size(158, 23);
            this.txtEmailClienteAluguel.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(215, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "Email:";
            // 
            // txtTelefoneClienteAluguel
            // 
            this.txtTelefoneClienteAluguel.Enabled = false;
            this.txtTelefoneClienteAluguel.Location = new System.Drawing.Point(5, 135);
            this.txtTelefoneClienteAluguel.Name = "txtTelefoneClienteAluguel";
            this.txtTelefoneClienteAluguel.Size = new System.Drawing.Size(202, 23);
            this.txtTelefoneClienteAluguel.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Telefone 1:";
            // 
            // txtEnderecoClienteAluguel
            // 
            this.txtEnderecoClienteAluguel.Enabled = false;
            this.txtEnderecoClienteAluguel.Location = new System.Drawing.Point(6, 87);
            this.txtEnderecoClienteAluguel.Name = "txtEnderecoClienteAluguel";
            this.txtEnderecoClienteAluguel.Size = new System.Drawing.Size(367, 23);
            this.txtEnderecoClienteAluguel.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Endereço:";
            // 
            // txtNomeClienteAluguel
            // 
            this.txtNomeClienteAluguel.Enabled = false;
            this.txtNomeClienteAluguel.Location = new System.Drawing.Point(6, 38);
            this.txtNomeClienteAluguel.Name = "txtNomeClienteAluguel";
            this.txtNomeClienteAluguel.Size = new System.Drawing.Size(367, 23);
            this.txtNomeClienteAluguel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nome completo:";
            // 
            // txtBuscarClienteAluguel
            // 
            this.txtBuscarClienteAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarClienteAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarClienteAluguel.Location = new System.Drawing.Point(6, 46);
            this.txtBuscarClienteAluguel.Name = "txtBuscarClienteAluguel";
            this.txtBuscarClienteAluguel.Size = new System.Drawing.Size(187, 23);
            this.txtBuscarClienteAluguel.TabIndex = 2;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnBuscarCliente.Location = new System.Drawing.Point(199, 46);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCliente.TabIndex = 4;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnLimparCadastroAluguel
            // 
            this.btnLimparCadastroAluguel.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparCadastroAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparCadastroAluguel.Location = new System.Drawing.Point(467, 424);
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
            this.btnCancelarCadastroAluguel.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarCadastroAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarCadastroAluguel.Location = new System.Drawing.Point(542, 424);
            this.btnCancelarCadastroAluguel.Name = "btnCancelarCadastroAluguel";
            this.btnCancelarCadastroAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCadastroAluguel.TabIndex = 6;
            this.btnCancelarCadastroAluguel.Text = "Cancelar";
            this.btnCancelarCadastroAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarCadastroAluguel.UseVisualStyleBackColor = true;
            this.btnCancelarCadastroAluguel.Click += new System.EventHandler(this.btnCancelarCadastroAluguel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rabPesquisarLivroAutor);
            this.groupBox4.Controls.Add(this.rabPesquisarLivroTitulo);
            this.groupBox4.Controls.Add(this.rabPesquisarLivroCodigo);
            this.groupBox4.Controls.Add(this.txtBuscarLivroAluguel);
            this.groupBox4.Controls.Add(this.btnBuscarLivroAluguel);
            this.groupBox4.Location = new System.Drawing.Point(12, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 83);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buscar livro";
            // 
            // rabPesquisarLivroAutor
            // 
            this.rabPesquisarLivroAutor.AutoSize = true;
            this.rabPesquisarLivroAutor.Location = new System.Drawing.Point(138, 23);
            this.rabPesquisarLivroAutor.Name = "rabPesquisarLivroAutor";
            this.rabPesquisarLivroAutor.Size = new System.Drawing.Size(55, 19);
            this.rabPesquisarLivroAutor.TabIndex = 9;
            this.rabPesquisarLivroAutor.Text = "Autor";
            this.rabPesquisarLivroAutor.UseVisualStyleBackColor = true;
            this.rabPesquisarLivroAutor.CheckedChanged += new System.EventHandler(this.rabPesquisarLivroAutor_CheckedChanged);
            // 
            // rabPesquisarLivroTitulo
            // 
            this.rabPesquisarLivroTitulo.AutoSize = true;
            this.rabPesquisarLivroTitulo.Location = new System.Drawing.Point(77, 23);
            this.rabPesquisarLivroTitulo.Name = "rabPesquisarLivroTitulo";
            this.rabPesquisarLivroTitulo.Size = new System.Drawing.Size(55, 19);
            this.rabPesquisarLivroTitulo.TabIndex = 8;
            this.rabPesquisarLivroTitulo.Text = "Titulo";
            this.rabPesquisarLivroTitulo.UseVisualStyleBackColor = true;
            this.rabPesquisarLivroTitulo.CheckedChanged += new System.EventHandler(this.rabPesquisarLivroTitulo_CheckedChanged);
            // 
            // rabPesquisarLivroCodigo
            // 
            this.rabPesquisarLivroCodigo.AutoSize = true;
            this.rabPesquisarLivroCodigo.Checked = true;
            this.rabPesquisarLivroCodigo.Location = new System.Drawing.Point(7, 23);
            this.rabPesquisarLivroCodigo.Name = "rabPesquisarLivroCodigo";
            this.rabPesquisarLivroCodigo.Size = new System.Drawing.Size(64, 19);
            this.rabPesquisarLivroCodigo.TabIndex = 7;
            this.rabPesquisarLivroCodigo.TabStop = true;
            this.rabPesquisarLivroCodigo.Text = "Código";
            this.rabPesquisarLivroCodigo.UseVisualStyleBackColor = true;
            this.rabPesquisarLivroCodigo.CheckedChanged += new System.EventHandler(this.rabPesquisarLivroCodigo_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rabPesquisarClienteNome);
            this.groupBox5.Controls.Add(this.rabPesquisarClienteCodigo);
            this.groupBox5.Controls.Add(this.txtBuscarClienteAluguel);
            this.groupBox5.Controls.Add(this.btnBuscarCliente);
            this.groupBox5.Location = new System.Drawing.Point(12, 120);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(226, 83);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Buscar cliente";
            // 
            // rabPesquisarClienteNome
            // 
            this.rabPesquisarClienteNome.AutoSize = true;
            this.rabPesquisarClienteNome.Location = new System.Drawing.Point(135, 23);
            this.rabPesquisarClienteNome.Name = "rabPesquisarClienteNome";
            this.rabPesquisarClienteNome.Size = new System.Drawing.Size(58, 19);
            this.rabPesquisarClienteNome.TabIndex = 6;
            this.rabPesquisarClienteNome.Text = "Nome";
            this.rabPesquisarClienteNome.UseVisualStyleBackColor = true;
            this.rabPesquisarClienteNome.CheckedChanged += new System.EventHandler(this.rabPesquisarClienteNome_CheckedChanged);
            // 
            // rabPesquisarClienteCodigo
            // 
            this.rabPesquisarClienteCodigo.AutoSize = true;
            this.rabPesquisarClienteCodigo.Checked = true;
            this.rabPesquisarClienteCodigo.Location = new System.Drawing.Point(7, 23);
            this.rabPesquisarClienteCodigo.Name = "rabPesquisarClienteCodigo";
            this.rabPesquisarClienteCodigo.Size = new System.Drawing.Size(64, 19);
            this.rabPesquisarClienteCodigo.TabIndex = 5;
            this.rabPesquisarClienteCodigo.TabStop = true;
            this.rabPesquisarClienteCodigo.Text = "Código";
            this.rabPesquisarClienteCodigo.UseVisualStyleBackColor = true;
            this.rabPesquisarClienteCodigo.CheckedChanged += new System.EventHandler(this.rabPesquisarClienteCodigo_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Status:";
            // 
            // cmbStatusAluguel
            // 
            this.cmbStatusAluguel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusAluguel.FormattingEnabled = true;
            this.cmbStatusAluguel.Items.AddRange(new object[] {
            ProjectBook.Tipos.StatusAluguel.Alugado,
            ProjectBook.Tipos.StatusAluguel.Devolvido,
            ProjectBook.Tipos.StatusAluguel.Atrasado});
            this.cmbStatusAluguel.Location = new System.Drawing.Point(12, 349);
            this.cmbStatusAluguel.Name = "cmbStatusAluguel";
            this.cmbStatusAluguel.Size = new System.Drawing.Size(226, 23);
            this.cmbStatusAluguel.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerLivros,
            this.btnVerClientes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(629, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnVerLivros
            // 
            this.btnVerLivros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnVerLivros.Image = global::ProjectBook.Properties.Resources.book_go;
            this.btnVerLivros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerLivros.Name = "btnVerLivros";
            this.btnVerLivros.Size = new System.Drawing.Size(23, 22);
            this.btnVerLivros.Text = "Ver todos os livros";
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
            // CadastrarAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 459);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cmbStatusAluguel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnLimparCadastroAluguel;
        private System.Windows.Forms.Button btnCancelarCadastroAluguel;
        private System.Windows.Forms.TextBox txtEdicaoLivro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEditoraLivro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rabPesquisarLivroAutor;
        private System.Windows.Forms.RadioButton rabPesquisarLivroTitulo;
        private System.Windows.Forms.RadioButton rabPesquisarLivroCodigo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rabPesquisarClienteNome;
        private System.Windows.Forms.RadioButton rabPesquisarClienteCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatusAluguel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnVerLivros;
        private System.Windows.Forms.ToolStripButton btnVerClientes;
    }
}