
namespace ProjectBook.GUI
{
    partial class EditarLivro
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEditarAno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEditarEdicao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEditarEditora = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEditarAutor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEditarTitulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFecharEdicao = new System.Windows.Forms.Button();
            this.btnLimparTxtEditar = new System.Windows.Forms.Button();
            this.btnSalvarEditar = new System.Windows.Forms.Button();
            this.gpbBuscar = new System.Windows.Forms.GroupBox();
            this.btnBuscarEditar = new System.Windows.Forms.Button();
            this.txtEditarBuscar = new System.Windows.Forms.TextBox();
            this.rabEditarAutor = new System.Windows.Forms.RadioButton();
            this.rabEditarTitulo = new System.Windows.Forms.RadioButton();
            this.rabEditarId = new System.Windows.Forms.RadioButton();
            this.cmbEditarGenero = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEditarCodigo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEditarObservacoes = new System.Windows.Forms.RichTextBox();
            this.txtEditarIsbn = new System.Windows.Forms.MaskedTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnVerLivros = new System.Windows.Forms.ToolStripButton();
            this.btnPesquisarLivros = new System.Windows.Forms.ToolStripButton();
            this.gpbBuscar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "ISBN:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Gênero:";
            // 
            // txtEditarAno
            // 
            this.txtEditarAno.Location = new System.Drawing.Point(87, 215);
            this.txtEditarAno.Name = "txtEditarAno";
            this.txtEditarAno.Size = new System.Drawing.Size(52, 23);
            this.txtEditarAno.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "*Ano:";
            // 
            // txtEditarEdicao
            // 
            this.txtEditarEdicao.Location = new System.Drawing.Point(12, 215);
            this.txtEditarEdicao.Name = "txtEditarEdicao";
            this.txtEditarEdicao.Size = new System.Drawing.Size(69, 23);
            this.txtEditarEdicao.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Edição:";
            // 
            // txtEditarEditora
            // 
            this.txtEditarEditora.Location = new System.Drawing.Point(169, 171);
            this.txtEditarEditora.Name = "txtEditarEditora";
            this.txtEditarEditora.Size = new System.Drawing.Size(141, 23);
            this.txtEditarEditora.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "*Editora:";
            // 
            // txtEditarAutor
            // 
            this.txtEditarAutor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtEditarAutor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEditarAutor.Location = new System.Drawing.Point(12, 171);
            this.txtEditarAutor.Name = "txtEditarAutor";
            this.txtEditarAutor.Size = new System.Drawing.Size(151, 23);
            this.txtEditarAutor.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "*Autor:";
            // 
            // txtEditarTitulo
            // 
            this.txtEditarTitulo.Location = new System.Drawing.Point(120, 127);
            this.txtEditarTitulo.Name = "txtEditarTitulo";
            this.txtEditarTitulo.Size = new System.Drawing.Size(190, 23);
            this.txtEditarTitulo.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "*Titulo:";
            // 
            // btnFecharEdicao
            // 
            this.btnFecharEdicao.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnFecharEdicao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFecharEdicao.Location = new System.Drawing.Point(237, 389);
            this.btnFecharEdicao.Name = "btnFecharEdicao";
            this.btnFecharEdicao.Size = new System.Drawing.Size(75, 23);
            this.btnFecharEdicao.TabIndex = 15;
            this.btnFecharEdicao.Text = "Cancelar";
            this.btnFecharEdicao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFecharEdicao.UseVisualStyleBackColor = true;
            this.btnFecharEdicao.Click += new System.EventHandler(this.btnFecharEdicao_Click);
            // 
            // btnLimparTxtEditar
            // 
            this.btnLimparTxtEditar.Image = global::ProjectBook.Properties.Resources.textfield;
            this.btnLimparTxtEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparTxtEditar.Location = new System.Drawing.Point(161, 389);
            this.btnLimparTxtEditar.Name = "btnLimparTxtEditar";
            this.btnLimparTxtEditar.Size = new System.Drawing.Size(70, 23);
            this.btnLimparTxtEditar.TabIndex = 14;
            this.btnLimparTxtEditar.Text = "Limpar";
            this.btnLimparTxtEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimparTxtEditar.UseVisualStyleBackColor = true;
            this.btnLimparTxtEditar.Click += new System.EventHandler(this.btnLimparTxtEditar_Click);
            // 
            // btnSalvarEditar
            // 
            this.btnSalvarEditar.Image = global::ProjectBook.Properties.Resources.save;
            this.btnSalvarEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarEditar.Location = new System.Drawing.Point(12, 389);
            this.btnSalvarEditar.Name = "btnSalvarEditar";
            this.btnSalvarEditar.Size = new System.Drawing.Size(63, 23);
            this.btnSalvarEditar.TabIndex = 13;
            this.btnSalvarEditar.Text = "Salvar";
            this.btnSalvarEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarEditar.UseVisualStyleBackColor = true;
            this.btnSalvarEditar.Click += new System.EventHandler(this.btnSalvarEditar_Click);
            // 
            // gpbBuscar
            // 
            this.gpbBuscar.Controls.Add(this.btnBuscarEditar);
            this.gpbBuscar.Controls.Add(this.txtEditarBuscar);
            this.gpbBuscar.Controls.Add(this.rabEditarAutor);
            this.gpbBuscar.Controls.Add(this.rabEditarTitulo);
            this.gpbBuscar.Controls.Add(this.rabEditarId);
            this.gpbBuscar.Location = new System.Drawing.Point(12, 28);
            this.gpbBuscar.Name = "gpbBuscar";
            this.gpbBuscar.Size = new System.Drawing.Size(298, 78);
            this.gpbBuscar.TabIndex = 31;
            this.gpbBuscar.TabStop = false;
            this.gpbBuscar.Text = "Bucar";
            // 
            // btnBuscarEditar
            // 
            this.btnBuscarEditar.FlatAppearance.BorderSize = 0;
            this.btnBuscarEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEditar.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnBuscarEditar.Location = new System.Drawing.Point(263, 44);
            this.btnBuscarEditar.Name = "btnBuscarEditar";
            this.btnBuscarEditar.Size = new System.Drawing.Size(29, 23);
            this.btnBuscarEditar.TabIndex = 5;
            this.btnBuscarEditar.UseVisualStyleBackColor = true;
            this.btnBuscarEditar.Click += new System.EventHandler(this.btnBuscarEditar_Click);
            // 
            // txtEditarBuscar
            // 
            this.txtEditarBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtEditarBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEditarBuscar.Location = new System.Drawing.Point(5, 44);
            this.txtEditarBuscar.Name = "txtEditarBuscar";
            this.txtEditarBuscar.Size = new System.Drawing.Size(252, 23);
            this.txtEditarBuscar.TabIndex = 1;
            // 
            // rabEditarAutor
            // 
            this.rabEditarAutor.AutoSize = true;
            this.rabEditarAutor.Location = new System.Drawing.Point(202, 22);
            this.rabEditarAutor.Name = "rabEditarAutor";
            this.rabEditarAutor.Size = new System.Drawing.Size(55, 19);
            this.rabEditarAutor.TabIndex = 4;
            this.rabEditarAutor.Text = "Autor";
            this.rabEditarAutor.UseVisualStyleBackColor = true;
            this.rabEditarAutor.CheckedChanged += new System.EventHandler(this.rabEditarAutor_CheckedChanged);
            // 
            // rabEditarTitulo
            // 
            this.rabEditarTitulo.AutoSize = true;
            this.rabEditarTitulo.Location = new System.Drawing.Point(105, 22);
            this.rabEditarTitulo.Name = "rabEditarTitulo";
            this.rabEditarTitulo.Size = new System.Drawing.Size(55, 19);
            this.rabEditarTitulo.TabIndex = 3;
            this.rabEditarTitulo.Text = "Titulo";
            this.rabEditarTitulo.UseVisualStyleBackColor = true;
            this.rabEditarTitulo.CheckedChanged += new System.EventHandler(this.rabEditarTitulo_CheckedChanged);
            // 
            // rabEditarId
            // 
            this.rabEditarId.AutoSize = true;
            this.rabEditarId.Checked = true;
            this.rabEditarId.Location = new System.Drawing.Point(5, 21);
            this.rabEditarId.Name = "rabEditarId";
            this.rabEditarId.Size = new System.Drawing.Size(64, 19);
            this.rabEditarId.TabIndex = 2;
            this.rabEditarId.TabStop = true;
            this.rabEditarId.Text = "Código";
            this.rabEditarId.UseVisualStyleBackColor = true;
            this.rabEditarId.CheckedChanged += new System.EventHandler(this.rabEditarId_CheckedChanged);
            // 
            // cmbEditarGenero
            // 
            this.cmbEditarGenero.FormattingEnabled = true;
            this.cmbEditarGenero.Location = new System.Drawing.Point(12, 259);
            this.cmbEditarGenero.Name = "cmbEditarGenero";
            this.cmbEditarGenero.Size = new System.Drawing.Size(298, 23);
            this.cmbEditarGenero.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 32;
            this.label8.Text = "Código";
            // 
            // txtEditarCodigo
            // 
            this.txtEditarCodigo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtEditarCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtEditarCodigo.ForeColor = System.Drawing.Color.White;
            this.txtEditarCodigo.Location = new System.Drawing.Point(12, 127);
            this.txtEditarCodigo.Name = "txtEditarCodigo";
            this.txtEditarCodigo.Size = new System.Drawing.Size(100, 23);
            this.txtEditarCodigo.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "Observações:";
            // 
            // txtEditarObservacoes
            // 
            this.txtEditarObservacoes.Location = new System.Drawing.Point(12, 303);
            this.txtEditarObservacoes.Name = "txtEditarObservacoes";
            this.txtEditarObservacoes.Size = new System.Drawing.Size(298, 71);
            this.txtEditarObservacoes.TabIndex = 14;
            this.txtEditarObservacoes.Text = "";
            // 
            // txtEditarIsbn
            // 
            this.txtEditarIsbn.Location = new System.Drawing.Point(145, 215);
            this.txtEditarIsbn.Mask = "999-9-99-999999-9";
            this.txtEditarIsbn.Name = "txtEditarIsbn";
            this.txtEditarIsbn.Size = new System.Drawing.Size(113, 23);
            this.txtEditarIsbn.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVerLivros,
            this.btnPesquisarLivros});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(324, 25);
            this.toolStrip1.TabIndex = 34;
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
            // btnPesquisarLivros
            // 
            this.btnPesquisarLivros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPesquisarLivros.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnPesquisarLivros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPesquisarLivros.Name = "btnPesquisarLivros";
            this.btnPesquisarLivros.Size = new System.Drawing.Size(23, 22);
            this.btnPesquisarLivros.Text = "Pesquisar livro";
            // 
            // EditarLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 421);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtEditarIsbn);
            this.Controls.Add(this.txtEditarObservacoes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEditarCodigo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbEditarGenero);
            this.Controls.Add(this.gpbBuscar);
            this.Controls.Add(this.btnFecharEdicao);
            this.Controls.Add(this.btnLimparTxtEditar);
            this.Controls.Add(this.btnSalvarEditar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEditarAno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEditarEdicao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEditarEditora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEditarAutor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEditarTitulo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditarLivro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar livro";
            this.gpbBuscar.ResumeLayout(false);
            this.gpbBuscar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEditarAno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEditarEdicao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEditarEditora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEditarAutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEditarTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFecharEdicao;
        private System.Windows.Forms.Button btnLimparTxtEditar;
        private System.Windows.Forms.Button btnSalvarEditar;
        private System.Windows.Forms.GroupBox gpbBuscar;
        private System.Windows.Forms.TextBox txtEditarBuscar;
        private System.Windows.Forms.RadioButton rabEditarAutor;
        private System.Windows.Forms.RadioButton rabEditarTitulo;
        private System.Windows.Forms.RadioButton rabEditarId;
        private System.Windows.Forms.ComboBox cmbEditarGenero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEditarCodigo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtEditarObservacoes;
        private System.Windows.Forms.MaskedTextBox txtEditarIsbn;
        private System.Windows.Forms.Button btnBuscarEditar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnVerLivros;
        private System.Windows.Forms.ToolStripButton btnPesquisarLivros;
    }
}