
namespace ProjectBook.GUI
{
    partial class Configuracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracoes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPersonalizarImpressao = new System.Windows.Forms.Button();
            this.chbVisualizarImpressao = new System.Windows.Forms.CheckBox();
            this.btnSalvarConfiguracoes = new System.Windows.Forms.Button();
            this.gpbBancoDados = new System.Windows.Forms.GroupBox();
            this.rabOneDrive = new System.Windows.Forms.RadioButton();
            this.btnSelecionarArquivoDb = new System.Windows.Forms.Button();
            this.rabSqlServerLocalDb = new System.Windows.Forms.RadioButton();
            this.lblInfoTxt = new System.Windows.Forms.Label();
            this.txtStringConexaoCaminhoDb = new System.Windows.Forms.TextBox();
            this.rabSqlServerExpress = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chbFormatarLivro = new System.Windows.Forms.CheckBox();
            this.chbFormatarCliente = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbAtualizarStatusAluguel = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gpbBancoDados.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPersonalizarImpressao);
            this.groupBox1.Controls.Add(this.chbVisualizarImpressao);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impressão";
            // 
            // btnPersonalizarImpressao
            // 
            this.btnPersonalizarImpressao.Location = new System.Drawing.Point(152, 19);
            this.btnPersonalizarImpressao.Name = "btnPersonalizarImpressao";
            this.btnPersonalizarImpressao.Size = new System.Drawing.Size(140, 23);
            this.btnPersonalizarImpressao.TabIndex = 2;
            this.btnPersonalizarImpressao.Text = "Personalizar impressão";
            this.btnPersonalizarImpressao.UseVisualStyleBackColor = true;
            this.btnPersonalizarImpressao.Click += new System.EventHandler(this.btnPersonalizarImpressao_Click);
            // 
            // chbVisualizarImpressao
            // 
            this.chbVisualizarImpressao.AutoSize = true;
            this.chbVisualizarImpressao.Location = new System.Drawing.Point(6, 22);
            this.chbVisualizarImpressao.Name = "chbVisualizarImpressao";
            this.chbVisualizarImpressao.Size = new System.Drawing.Size(140, 19);
            this.chbVisualizarImpressao.TabIndex = 1;
            this.chbVisualizarImpressao.Text = "Visualizar ao imprimir";
            this.chbVisualizarImpressao.UseVisualStyleBackColor = true;
            // 
            // btnSalvarConfiguracoes
            // 
            this.btnSalvarConfiguracoes.Location = new System.Drawing.Point(457, 246);
            this.btnSalvarConfiguracoes.Name = "btnSalvarConfiguracoes";
            this.btnSalvarConfiguracoes.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarConfiguracoes.TabIndex = 1;
            this.btnSalvarConfiguracoes.Text = "Salvar";
            this.btnSalvarConfiguracoes.UseVisualStyleBackColor = true;
            this.btnSalvarConfiguracoes.Click += new System.EventHandler(this.btnSalvarConfiguracoes_Click);
            // 
            // gpbBancoDados
            // 
            this.gpbBancoDados.Controls.Add(this.rabOneDrive);
            this.gpbBancoDados.Controls.Add(this.btnSelecionarArquivoDb);
            this.gpbBancoDados.Controls.Add(this.rabSqlServerLocalDb);
            this.gpbBancoDados.Controls.Add(this.lblInfoTxt);
            this.gpbBancoDados.Controls.Add(this.txtStringConexaoCaminhoDb);
            this.gpbBancoDados.Controls.Add(this.rabSqlServerExpress);
            this.gpbBancoDados.Enabled = false;
            this.gpbBancoDados.Location = new System.Drawing.Point(12, 127);
            this.gpbBancoDados.Name = "gpbBancoDados";
            this.gpbBancoDados.Size = new System.Drawing.Size(453, 105);
            this.gpbBancoDados.TabIndex = 2;
            this.gpbBancoDados.TabStop = false;
            this.gpbBancoDados.Text = "Banco de dados";
            // 
            // rabOneDrive
            // 
            this.rabOneDrive.AutoSize = true;
            this.rabOneDrive.Location = new System.Drawing.Point(317, 22);
            this.rabOneDrive.Name = "rabOneDrive";
            this.rabOneDrive.Size = new System.Drawing.Size(74, 19);
            this.rabOneDrive.TabIndex = 5;
            this.rabOneDrive.TabStop = true;
            this.rabOneDrive.Text = "OneDrive";
            this.rabOneDrive.UseVisualStyleBackColor = true;
            this.rabOneDrive.CheckedChanged += new System.EventHandler(this.rabOneDrive_CheckedChanged);
            // 
            // btnSelecionarArquivoDb
            // 
            this.btnSelecionarArquivoDb.Location = new System.Drawing.Point(420, 66);
            this.btnSelecionarArquivoDb.Name = "btnSelecionarArquivoDb";
            this.btnSelecionarArquivoDb.Size = new System.Drawing.Size(27, 23);
            this.btnSelecionarArquivoDb.TabIndex = 4;
            this.btnSelecionarArquivoDb.Text = "...";
            this.btnSelecionarArquivoDb.UseVisualStyleBackColor = true;
            this.btnSelecionarArquivoDb.Click += new System.EventHandler(this.btnSelecionarArquivoDb_Click);
            // 
            // rabSqlServerLocalDb
            // 
            this.rabSqlServerLocalDb.AutoSize = true;
            this.rabSqlServerLocalDb.Location = new System.Drawing.Point(135, 22);
            this.rabSqlServerLocalDb.Name = "rabSqlServerLocalDb";
            this.rabSqlServerLocalDb.Size = new System.Drawing.Size(176, 19);
            this.rabSqlServerLocalDb.TabIndex = 3;
            this.rabSqlServerLocalDb.TabStop = true;
            this.rabSqlServerLocalDb.Text = "SQL Server LocalDB (MSSQL)";
            this.rabSqlServerLocalDb.UseVisualStyleBackColor = true;
            this.rabSqlServerLocalDb.CheckedChanged += new System.EventHandler(this.rabSqlServerLocalDb_CheckedChanged);
            // 
            // lblInfoTxt
            // 
            this.lblInfoTxt.AutoSize = true;
            this.lblInfoTxt.Location = new System.Drawing.Point(6, 48);
            this.lblInfoTxt.Name = "lblInfoTxt";
            this.lblInfoTxt.Size = new System.Drawing.Size(105, 15);
            this.lblInfoTxt.TabIndex = 2;
            this.lblInfoTxt.Text = "String de conexão:";
            // 
            // txtStringConexaoCaminhoDb
            // 
            this.txtStringConexaoCaminhoDb.Location = new System.Drawing.Point(6, 66);
            this.txtStringConexaoCaminhoDb.Name = "txtStringConexaoCaminhoDb";
            this.txtStringConexaoCaminhoDb.Size = new System.Drawing.Size(408, 23);
            this.txtStringConexaoCaminhoDb.TabIndex = 1;
            // 
            // rabSqlServerExpress
            // 
            this.rabSqlServerExpress.AutoSize = true;
            this.rabSqlServerExpress.Location = new System.Drawing.Point(6, 22);
            this.rabSqlServerExpress.Name = "rabSqlServerExpress";
            this.rabSqlServerExpress.Size = new System.Drawing.Size(123, 19);
            this.rabSqlServerExpress.TabIndex = 0;
            this.rabSqlServerExpress.TabStop = true;
            this.rabSqlServerExpress.Text = "SQL Server Express";
            this.rabSqlServerExpress.UseVisualStyleBackColor = true;
            this.rabSqlServerExpress.CheckedChanged += new System.EventHandler(this.rabSqlServerExpress_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbFormatarLivro);
            this.groupBox3.Controls.Add(this.chbFormatarCliente);
            this.groupBox3.Location = new System.Drawing.Point(12, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Formatar em maiúsculo";
            // 
            // chbFormatarLivro
            // 
            this.chbFormatarLivro.AutoSize = true;
            this.chbFormatarLivro.Location = new System.Drawing.Point(189, 22);
            this.chbFormatarLivro.Name = "chbFormatarLivro";
            this.chbFormatarLivro.Size = new System.Drawing.Size(57, 19);
            this.chbFormatarLivro.TabIndex = 1;
            this.chbFormatarLivro.Text = "Livros";
            this.chbFormatarLivro.UseVisualStyleBackColor = true;
            // 
            // chbFormatarCliente
            // 
            this.chbFormatarCliente.AutoSize = true;
            this.chbFormatarCliente.Location = new System.Drawing.Point(6, 22);
            this.chbFormatarCliente.Name = "chbFormatarCliente";
            this.chbFormatarCliente.Size = new System.Drawing.Size(177, 19);
            this.chbFormatarCliente.TabIndex = 0;
            this.chbFormatarCliente.Text = "Clientes (E-mail não incluso)";
            this.chbFormatarCliente.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbAtualizarStatusAluguel);
            this.groupBox2.Location = new System.Drawing.Point(318, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 51);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferências de aluguel";
            // 
            // chbAtualizarStatusAluguel
            // 
            this.chbAtualizarStatusAluguel.AutoSize = true;
            this.chbAtualizarStatusAluguel.Location = new System.Drawing.Point(7, 23);
            this.chbAtualizarStatusAluguel.Name = "chbAtualizarStatusAluguel";
            this.chbAtualizarStatusAluguel.Size = new System.Drawing.Size(203, 19);
            this.chbAtualizarStatusAluguel.TabIndex = 0;
            this.chbAtualizarStatusAluguel.Text = "Atualizar status automaticamente";
            this.chbAtualizarStatusAluguel.UseVisualStyleBackColor = true;
            // 
            // Configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 281);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gpbBancoDados);
            this.Controls.Add(this.btnSalvarConfiguracoes);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Configuracoes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbBancoDados.ResumeLayout(false);
            this.gpbBancoDados.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbVisualizarImpressao;
        private System.Windows.Forms.Button btnSalvarConfiguracoes;
        private System.Windows.Forms.GroupBox gpbBancoDados;
        private System.Windows.Forms.Label lblInfoTxt;
        private System.Windows.Forms.TextBox txtStringConexaoCaminhoDb;
        private System.Windows.Forms.RadioButton rabSqlServerExpress;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbFormatarLivro;
        private System.Windows.Forms.CheckBox chbFormatarCliente;
        private System.Windows.Forms.RadioButton rabSqlServerLocalDb;
        private System.Windows.Forms.Button btnSelecionarArquivoDb;
        private System.Windows.Forms.RadioButton rabOneDrive;
        private System.Windows.Forms.Button btnPersonalizarImpressao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbAtualizarStatusAluguel;
    }
}