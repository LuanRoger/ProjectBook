
namespace ProjectBook.GUI
{
    partial class PesquisaSeletiva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PesquisaSeletiva));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rabPesquisarAutor = new System.Windows.Forms.RadioButton();
            this.rabPesquisarTitulo = new System.Windows.Forms.RadioButton();
            this.rabPesquisarId = new System.Windows.Forms.RadioButton();
            this.txtTermoPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisarSeletiva = new System.Windows.Forms.Button();
            this.btnCancelarPesquisaLivro = new System.Windows.Forms.Button();
            this.rabPesquisarGenero = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rabPesquisarGenero);
            this.groupBox1.Controls.Add(this.rabPesquisarAutor);
            this.groupBox1.Controls.Add(this.rabPesquisarTitulo);
            this.groupBox1.Controls.Add(this.rabPesquisarId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar por:";
            // 
            // rabPesquisarAutor
            // 
            this.rabPesquisarAutor.AutoSize = true;
            this.rabPesquisarAutor.Location = new System.Drawing.Point(183, 23);
            this.rabPesquisarAutor.Name = "rabPesquisarAutor";
            this.rabPesquisarAutor.Size = new System.Drawing.Size(55, 19);
            this.rabPesquisarAutor.TabIndex = 2;
            this.rabPesquisarAutor.TabStop = true;
            this.rabPesquisarAutor.Text = "Autor";
            this.rabPesquisarAutor.UseVisualStyleBackColor = true;
            // 
            // rabPesquisarTitulo
            // 
            this.rabPesquisarTitulo.AutoSize = true;
            this.rabPesquisarTitulo.Location = new System.Drawing.Point(98, 23);
            this.rabPesquisarTitulo.Name = "rabPesquisarTitulo";
            this.rabPesquisarTitulo.Size = new System.Drawing.Size(55, 19);
            this.rabPesquisarTitulo.TabIndex = 1;
            this.rabPesquisarTitulo.TabStop = true;
            this.rabPesquisarTitulo.Text = "Titulo";
            this.rabPesquisarTitulo.UseVisualStyleBackColor = true;
            // 
            // rabPesquisarId
            // 
            this.rabPesquisarId.AutoSize = true;
            this.rabPesquisarId.Location = new System.Drawing.Point(7, 23);
            this.rabPesquisarId.Name = "rabPesquisarId";
            this.rabPesquisarId.Size = new System.Drawing.Size(64, 19);
            this.rabPesquisarId.TabIndex = 0;
            this.rabPesquisarId.TabStop = true;
            this.rabPesquisarId.Text = "Código";
            this.rabPesquisarId.UseVisualStyleBackColor = true;
            // 
            // txtTermoPesquisa
            // 
            this.txtTermoPesquisa.Location = new System.Drawing.Point(11, 80);
            this.txtTermoPesquisa.Name = "txtTermoPesquisa";
            this.txtTermoPesquisa.Size = new System.Drawing.Size(307, 23);
            this.txtTermoPesquisa.TabIndex = 1;
            // 
            // btnPesquisarSeletiva
            // 
            this.btnPesquisarSeletiva.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisarSeletiva.FlatAppearance.BorderSize = 0;
            this.btnPesquisarSeletiva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarSeletiva.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarSeletiva.Image")));
            this.btnPesquisarSeletiva.Location = new System.Drawing.Point(324, 80);
            this.btnPesquisarSeletiva.Name = "btnPesquisarSeletiva";
            this.btnPesquisarSeletiva.Size = new System.Drawing.Size(25, 23);
            this.btnPesquisarSeletiva.TabIndex = 2;
            this.btnPesquisarSeletiva.UseVisualStyleBackColor = false;
            this.btnPesquisarSeletiva.Click += new System.EventHandler(this.btnPesquisarSeletiva_Click);
            // 
            // btnCancelarPesquisaLivro
            // 
            this.btnCancelarPesquisaLivro.Location = new System.Drawing.Point(280, 109);
            this.btnCancelarPesquisaLivro.Name = "btnCancelarPesquisaLivro";
            this.btnCancelarPesquisaLivro.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarPesquisaLivro.TabIndex = 3;
            this.btnCancelarPesquisaLivro.Text = "Cancelar";
            this.btnCancelarPesquisaLivro.UseVisualStyleBackColor = true;
            this.btnCancelarPesquisaLivro.Click += new System.EventHandler(this.btnFecharPesquisaLivro_Click);
            // 
            // rabPesquisarGenero
            // 
            this.rabPesquisarGenero.AutoSize = true;
            this.rabPesquisarGenero.Location = new System.Drawing.Point(268, 23);
            this.rabPesquisarGenero.Name = "rabPesquisarGenero";
            this.rabPesquisarGenero.Size = new System.Drawing.Size(63, 19);
            this.rabPesquisarGenero.TabIndex = 3;
            this.rabPesquisarGenero.TabStop = true;
            this.rabPesquisarGenero.Text = "Gênero";
            this.rabPesquisarGenero.UseVisualStyleBackColor = true;
            // 
            // PesquisaSeletiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 142);
            this.Controls.Add(this.btnCancelarPesquisaLivro);
            this.Controls.Add(this.btnPesquisarSeletiva);
            this.Controls.Add(this.txtTermoPesquisa);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PesquisaSeletiva";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar livro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rabPesquisarAutor;
        private System.Windows.Forms.RadioButton rabPesquisarTitulo;
        private System.Windows.Forms.RadioButton rabPesquisarId;
        private System.Windows.Forms.TextBox txtTermoPesquisa;
        private System.Windows.Forms.Button btnPesquisarSeletiva;
        private System.Windows.Forms.Button btnCancelarPesquisaLivro;
        private System.Windows.Forms.RadioButton rabPesquisarGenero;
    }
}