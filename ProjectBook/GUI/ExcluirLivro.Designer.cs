
namespace ProjectBook.GUI
{
    partial class ExcluirLivro
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
            this.txtExcluirLivro = new System.Windows.Forms.TextBox();
            this.btnBuscarExcluirLivro = new System.Windows.Forms.Button();
            this.btnCancelarExcluirLivro = new System.Windows.Forms.Button();
            this.rabIdExcluirLivro = new System.Windows.Forms.RadioButton();
            this.rabExcluirTitulo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtExcluirLivro
            // 
            this.txtExcluirLivro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtExcluirLivro.Location = new System.Drawing.Point(12, 38);
            this.txtExcluirLivro.Name = "txtExcluirLivro";
            this.txtExcluirLivro.Size = new System.Drawing.Size(209, 23);
            this.txtExcluirLivro.TabIndex = 1;
            // 
            // btnBuscarExcluirLivro
            // 
            this.btnBuscarExcluirLivro.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarExcluirLivro.FlatAppearance.BorderSize = 0;
            this.btnBuscarExcluirLivro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarExcluirLivro.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnBuscarExcluirLivro.Location = new System.Drawing.Point(227, 38);
            this.btnBuscarExcluirLivro.Name = "btnBuscarExcluirLivro";
            this.btnBuscarExcluirLivro.Size = new System.Drawing.Size(28, 23);
            this.btnBuscarExcluirLivro.TabIndex = 2;
            this.btnBuscarExcluirLivro.UseVisualStyleBackColor = false;
            this.btnBuscarExcluirLivro.Click += new System.EventHandler(this.btnBuscarExcluirLivro_Click);
            // 
            // btnCancelarExcluirLivro
            // 
            this.btnCancelarExcluirLivro.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarExcluirLivro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarExcluirLivro.Location = new System.Drawing.Point(171, 72);
            this.btnCancelarExcluirLivro.Name = "btnCancelarExcluirLivro";
            this.btnCancelarExcluirLivro.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarExcluirLivro.TabIndex = 3;
            this.btnCancelarExcluirLivro.Text = "Cancelar";
            this.btnCancelarExcluirLivro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarExcluirLivro.UseVisualStyleBackColor = true;
            this.btnCancelarExcluirLivro.Click += new System.EventHandler(this.btnCancelarExcluirLivro_Click);
            // 
            // rabIdExcluirLivro
            // 
            this.rabIdExcluirLivro.AutoSize = true;
            this.rabIdExcluirLivro.Location = new System.Drawing.Point(12, 12);
            this.rabIdExcluirLivro.Name = "rabIdExcluirLivro";
            this.rabIdExcluirLivro.Size = new System.Drawing.Size(64, 19);
            this.rabIdExcluirLivro.TabIndex = 4;
            this.rabIdExcluirLivro.Text = "Código";
            this.rabIdExcluirLivro.UseVisualStyleBackColor = true;
            this.rabIdExcluirLivro.CheckedChanged += new System.EventHandler(this.rabIdExcluirLivro_CheckedChanged);
            // 
            // rabExcluirTitulo
            // 
            this.rabExcluirTitulo.AutoSize = true;
            this.rabExcluirTitulo.Location = new System.Drawing.Point(166, 12);
            this.rabExcluirTitulo.Name = "rabExcluirTitulo";
            this.rabExcluirTitulo.Size = new System.Drawing.Size(55, 19);
            this.rabExcluirTitulo.TabIndex = 5;
            this.rabExcluirTitulo.Text = "Titulo";
            this.rabExcluirTitulo.UseVisualStyleBackColor = true;
            this.rabExcluirTitulo.CheckedChanged += new System.EventHandler(this.rabExcluirTitulo_CheckedChanged);
            // 
            // ExcluirLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 107);
            this.Controls.Add(this.rabExcluirTitulo);
            this.Controls.Add(this.rabIdExcluirLivro);
            this.Controls.Add(this.btnCancelarExcluirLivro);
            this.Controls.Add(this.btnBuscarExcluirLivro);
            this.Controls.Add(this.txtExcluirLivro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExcluirLivro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir livro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtExcluirLivro;
        private System.Windows.Forms.Button btnBuscarExcluirLivro;
        private System.Windows.Forms.Button btnCancelarExcluirLivro;
        private System.Windows.Forms.RadioButton rabIdExcluirLivro;
        private System.Windows.Forms.RadioButton rabExcluirTitulo;
    }
}