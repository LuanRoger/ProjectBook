
namespace ProjectBook
{
    partial class Excluir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Excluir));
            this.txtExcluirLivro = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelarExcluirLivro = new System.Windows.Forms.Button();
            this.rabIdExcluirLivro = new System.Windows.Forms.RadioButton();
            this.rabExcluirTitulo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtExcluirLivro
            // 
            this.txtExcluirLivro.Location = new System.Drawing.Point(12, 38);
            this.txtExcluirLivro.Name = "txtExcluirLivro";
            this.txtExcluirLivro.Size = new System.Drawing.Size(255, 23);
            this.txtExcluirLivro.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(273, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelarExcluirLivro
            // 
            this.btnCancelarExcluirLivro.Location = new System.Drawing.Point(227, 72);
            this.btnCancelarExcluirLivro.Name = "btnCancelarExcluirLivro";
            this.btnCancelarExcluirLivro.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarExcluirLivro.TabIndex = 3;
            this.btnCancelarExcluirLivro.Text = "Cancelar";
            this.btnCancelarExcluirLivro.UseVisualStyleBackColor = true;
            this.btnCancelarExcluirLivro.Click += new System.EventHandler(this.btnCancelarExcluirLivro_Click);
            // 
            // rabIdExcluirLivro
            // 
            this.rabIdExcluirLivro.AutoSize = true;
            this.rabIdExcluirLivro.Location = new System.Drawing.Point(13, 13);
            this.rabIdExcluirLivro.Name = "rabIdExcluirLivro";
            this.rabIdExcluirLivro.Size = new System.Drawing.Size(36, 19);
            this.rabIdExcluirLivro.TabIndex = 4;
            this.rabIdExcluirLivro.TabStop = true;
            this.rabIdExcluirLivro.Text = "ID";
            this.rabIdExcluirLivro.UseVisualStyleBackColor = true;
            // 
            // rabExcluirTitulo
            // 
            this.rabExcluirTitulo.AutoSize = true;
            this.rabExcluirTitulo.Location = new System.Drawing.Point(212, 13);
            this.rabExcluirTitulo.Name = "rabExcluirTitulo";
            this.rabExcluirTitulo.Size = new System.Drawing.Size(55, 19);
            this.rabExcluirTitulo.TabIndex = 5;
            this.rabExcluirTitulo.TabStop = true;
            this.rabExcluirTitulo.Text = "Titulo";
            this.rabExcluirTitulo.UseVisualStyleBackColor = true;
            // 
            // Excluir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 107);
            this.Controls.Add(this.rabExcluirTitulo);
            this.Controls.Add(this.rabIdExcluirLivro);
            this.Controls.Add(this.btnCancelarExcluirLivro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtExcluirLivro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Excluir";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir livro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtExcluirLivro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelarExcluirLivro;
        private System.Windows.Forms.RadioButton rabIdExcluirLivro;
        private System.Windows.Forms.RadioButton rabExcluirTitulo;
    }
}