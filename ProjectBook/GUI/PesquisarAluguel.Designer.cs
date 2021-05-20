
namespace ProjectBook.GUI
{
    partial class PesquisarAluguel
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarAluguel = new System.Windows.Forms.TextBox();
            this.btnBuscarClientePesquisaAluguel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAtraso = new System.Windows.Forms.TextBox();
            this.txtAVencer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResultadoStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtResultadoLivro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtResultadoCliete = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelarPesquisaAluguel = new System.Windows.Forms.Button();
            this.btnLimparPequisaAluguel = new System.Windows.Forms.Button();
            this.rabTituloLivro = new System.Windows.Forms.RadioButton();
            this.rabNomeCliente = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerLivroAlugado = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerLivrosDevolvidos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerLivrosAtasados = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVerEmRelatorio = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // txtBuscarAluguel
            // 
            this.txtBuscarAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBuscarAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscarAluguel.Location = new System.Drawing.Point(5, 72);
            this.txtBuscarAluguel.Name = "txtBuscarAluguel";
            this.txtBuscarAluguel.Size = new System.Drawing.Size(180, 23);
            this.txtBuscarAluguel.TabIndex = 1;
            // 
            // btnBuscarClientePesquisaAluguel
            // 
            this.btnBuscarClientePesquisaAluguel.FlatAppearance.BorderSize = 0;
            this.btnBuscarClientePesquisaAluguel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarClientePesquisaAluguel.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnBuscarClientePesquisaAluguel.Location = new System.Drawing.Point(191, 72);
            this.btnBuscarClientePesquisaAluguel.Name = "btnBuscarClientePesquisaAluguel";
            this.btnBuscarClientePesquisaAluguel.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarClientePesquisaAluguel.TabIndex = 2;
            this.btnBuscarClientePesquisaAluguel.UseVisualStyleBackColor = true;
            this.btnBuscarClientePesquisaAluguel.Click += new System.EventHandler(this.btnBuscarClientePesquisaAluguel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAtraso);
            this.groupBox1.Controls.Add(this.txtAVencer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(252, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 91);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tempo de aluguel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "dias.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Atraso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "dias.";
            // 
            // txtAtraso
            // 
            this.txtAtraso.BackColor = System.Drawing.Color.Red;
            this.txtAtraso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAtraso.ForeColor = System.Drawing.Color.White;
            this.txtAtraso.Location = new System.Drawing.Point(69, 56);
            this.txtAtraso.Name = "txtAtraso";
            this.txtAtraso.Size = new System.Drawing.Size(48, 23);
            this.txtAtraso.TabIndex = 1;
            this.txtAtraso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAVencer
            // 
            this.txtAVencer.BackColor = System.Drawing.Color.ForestGreen;
            this.txtAVencer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAVencer.ForeColor = System.Drawing.Color.White;
            this.txtAVencer.Location = new System.Drawing.Point(69, 22);
            this.txtAVencer.Name = "txtAVencer";
            this.txtAVencer.Size = new System.Drawing.Size(48, 23);
            this.txtAVencer.TabIndex = 1;
            this.txtAVencer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "A vencer:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResultadoStatus);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtResultadoLivro);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtResultadoCliete);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(5, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 159);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações";
            // 
            // txtResultadoStatus
            // 
            this.txtResultadoStatus.Enabled = false;
            this.txtResultadoStatus.Location = new System.Drawing.Point(55, 120);
            this.txtResultadoStatus.Name = "txtResultadoStatus";
            this.txtResultadoStatus.Size = new System.Drawing.Size(61, 23);
            this.txtResultadoStatus.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Status:";
            // 
            // txtResultadoLivro
            // 
            this.txtResultadoLivro.Enabled = false;
            this.txtResultadoLivro.Location = new System.Drawing.Point(7, 91);
            this.txtResultadoLivro.Name = "txtResultadoLivro";
            this.txtResultadoLivro.Size = new System.Drawing.Size(394, 23);
            this.txtResultadoLivro.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Titulo do livro:";
            // 
            // txtResultadoCliete
            // 
            this.txtResultadoCliete.Enabled = false;
            this.txtResultadoCliete.Location = new System.Drawing.Point(7, 42);
            this.txtResultadoCliete.Name = "txtResultadoCliete";
            this.txtResultadoCliete.Size = new System.Drawing.Size(394, 23);
            this.txtResultadoCliete.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Nome do Cliente:";
            // 
            // btnCancelarPesquisaAluguel
            // 
            this.btnCancelarPesquisaAluguel.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarPesquisaAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarPesquisaAluguel.Location = new System.Drawing.Point(337, 302);
            this.btnCancelarPesquisaAluguel.Name = "btnCancelarPesquisaAluguel";
            this.btnCancelarPesquisaAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarPesquisaAluguel.TabIndex = 7;
            this.btnCancelarPesquisaAluguel.Text = "Cancelar";
            this.btnCancelarPesquisaAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarPesquisaAluguel.UseVisualStyleBackColor = true;
            this.btnCancelarPesquisaAluguel.Click += new System.EventHandler(this.btnFecharPesquisaAluguel_Click);
            // 
            // btnLimparPequisaAluguel
            // 
            this.btnLimparPequisaAluguel.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparPequisaAluguel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparPequisaAluguel.Location = new System.Drawing.Point(263, 302);
            this.btnLimparPequisaAluguel.Name = "btnLimparPequisaAluguel";
            this.btnLimparPequisaAluguel.Size = new System.Drawing.Size(68, 23);
            this.btnLimparPequisaAluguel.TabIndex = 8;
            this.btnLimparPequisaAluguel.Text = "Limpar";
            this.btnLimparPequisaAluguel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparPequisaAluguel.UseVisualStyleBackColor = true;
            this.btnLimparPequisaAluguel.Click += new System.EventHandler(this.btnLimparPequisaAluguel_Click);
            // 
            // rabTituloLivro
            // 
            this.rabTituloLivro.AutoSize = true;
            this.rabTituloLivro.Checked = true;
            this.rabTituloLivro.Location = new System.Drawing.Point(5, 31);
            this.rabTituloLivro.Name = "rabTituloLivro";
            this.rabTituloLivro.Size = new System.Drawing.Size(98, 19);
            this.rabTituloLivro.TabIndex = 9;
            this.rabTituloLivro.TabStop = true;
            this.rabTituloLivro.Text = "Titulo do livro";
            this.rabTituloLivro.UseVisualStyleBackColor = true;
            this.rabTituloLivro.CheckedChanged += new System.EventHandler(this.rabTituloLivro_CheckedChanged);
            // 
            // rabNomeCliente
            // 
            this.rabNomeCliente.AutoSize = true;
            this.rabNomeCliente.Location = new System.Drawing.Point(133, 31);
            this.rabNomeCliente.Name = "rabNomeCliente";
            this.rabNomeCliente.Size = new System.Drawing.Size(113, 19);
            this.rabNomeCliente.TabIndex = 10;
            this.rabNomeCliente.Text = "Nome do cliente";
            this.rabNomeCliente.UseVisualStyleBackColor = true;
            this.rabNomeCliente.CheckedChanged += new System.EventHandler(this.rabNomeCliente_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRelatorio});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuRelatorio
            // 
            this.mnuRelatorio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVerLivroAlugado,
            this.mnuVerLivrosDevolvidos,
            this.mnuVerLivrosAtasados});
            this.mnuRelatorio.Name = "mnuRelatorio";
            this.mnuRelatorio.Size = new System.Drawing.Size(66, 20);
            this.mnuRelatorio.Text = "Relatório";
            // 
            // mnuVerLivroAlugado
            // 
            this.mnuVerLivroAlugado.Name = "mnuVerLivroAlugado";
            this.mnuVerLivroAlugado.Size = new System.Drawing.Size(181, 22);
            this.mnuVerLivroAlugado.Text = "Ver livros alugados";
            // 
            // mnuVerLivrosDevolvidos
            // 
            this.mnuVerLivrosDevolvidos.Name = "mnuVerLivrosDevolvidos";
            this.mnuVerLivrosDevolvidos.Size = new System.Drawing.Size(181, 22);
            this.mnuVerLivrosDevolvidos.Text = "Ver livros devolvidos";
            // 
            // mnuVerLivrosAtasados
            // 
            this.mnuVerLivrosAtasados.Name = "mnuVerLivrosAtasados";
            this.mnuVerLivrosAtasados.Size = new System.Drawing.Size(181, 22);
            this.mnuVerLivrosAtasados.Text = "Ver livros atrasados";
            // 
            // btnVerEmRelatorio
            // 
            this.btnVerEmRelatorio.FlatAppearance.BorderSize = 0;
            this.btnVerEmRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEmRelatorio.Image = global::ProjectBook.Properties.Resources.table;
            this.btnVerEmRelatorio.Location = new System.Drawing.Point(223, 70);
            this.btnVerEmRelatorio.Name = "btnVerEmRelatorio";
            this.btnVerEmRelatorio.Size = new System.Drawing.Size(23, 26);
            this.btnVerEmRelatorio.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnVerEmRelatorio, "Mostra uma tabela com mais informações sobre a pesquisa.");
            this.btnVerEmRelatorio.UseVisualStyleBackColor = true;
            this.btnVerEmRelatorio.Click += new System.EventHandler(this.btnVerEmRelatorio_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Ver detalhes";
            // 
            // PesquisarAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 334);
            this.Controls.Add(this.btnVerEmRelatorio);
            this.Controls.Add(this.rabNomeCliente);
            this.Controls.Add(this.rabTituloLivro);
            this.Controls.Add(this.btnLimparPequisaAluguel);
            this.Controls.Add(this.btnCancelarPesquisaAluguel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBuscarClientePesquisaAluguel);
            this.Controls.Add(this.txtBuscarAluguel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PesquisarAluguel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar aluguel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarAluguel;
        private System.Windows.Forms.Button btnBuscarClientePesquisaAluguel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAtraso;
        private System.Windows.Forms.TextBox txtAVencer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtResultadoLivro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtResultadoCliete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtResultadoStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelarPesquisaAluguel;
        private System.Windows.Forms.Button btnLimparPequisaAluguel;
        private System.Windows.Forms.RadioButton rabTituloLivro;
        private System.Windows.Forms.RadioButton rabNomeCliente;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRelatorio;
        private System.Windows.Forms.ToolStripMenuItem mnuVerLivroAlugado;
        private System.Windows.Forms.ToolStripMenuItem mnuVerLivrosDevolvidos;
        private System.Windows.Forms.ToolStripMenuItem mnuVerLivrosAtasados;
        private System.Windows.Forms.Button btnVerEmRelatorio;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}