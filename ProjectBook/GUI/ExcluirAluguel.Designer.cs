
namespace ProjectBook.GUI
{
    partial class ExcluirAluguel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcluirAluguel));
            this.rabExcluirAluguelTitulo = new System.Windows.Forms.RadioButton();
            this.rabExcluirAluguelCliente = new System.Windows.Forms.RadioButton();
            this.txtBuscaAluguel = new System.Windows.Forms.TextBox();
            this.btnBuscarExcluirAluguel = new System.Windows.Forms.Button();
            this.btnCancelarExcluirAluguel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rabExcluirAluguelTitulo
            // 
            this.rabExcluirAluguelTitulo.AutoSize = true;
            this.rabExcluirAluguelTitulo.Location = new System.Drawing.Point(12, 12);
            this.rabExcluirAluguelTitulo.Name = "rabExcluirAluguelTitulo";
            this.rabExcluirAluguelTitulo.Size = new System.Drawing.Size(98, 19);
            this.rabExcluirAluguelTitulo.TabIndex = 0;
            this.rabExcluirAluguelTitulo.TabStop = true;
            this.rabExcluirAluguelTitulo.Text = "Titulo do livro";
            this.rabExcluirAluguelTitulo.UseVisualStyleBackColor = true;
            this.rabExcluirAluguelTitulo.CheckedChanged += new System.EventHandler(this.rabExcluirAluguelTitulo_CheckedChanged);
            // 
            // rabExcluirAluguelCliente
            // 
            this.rabExcluirAluguelCliente.AutoSize = true;
            this.rabExcluirAluguelCliente.Location = new System.Drawing.Point(116, 12);
            this.rabExcluirAluguelCliente.Name = "rabExcluirAluguelCliente";
            this.rabExcluirAluguelCliente.Size = new System.Drawing.Size(113, 19);
            this.rabExcluirAluguelCliente.TabIndex = 1;
            this.rabExcluirAluguelCliente.TabStop = true;
            this.rabExcluirAluguelCliente.Text = "Nome do cliente";
            this.rabExcluirAluguelCliente.UseVisualStyleBackColor = true;
            this.rabExcluirAluguelCliente.CheckedChanged += new System.EventHandler(this.rabExcluirAluguelCliente_CheckedChanged);
            // 
            // txtBuscaAluguel
            // 
            this.txtBuscaAluguel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuscaAluguel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscaAluguel.Location = new System.Drawing.Point(12, 37);
            this.txtBuscaAluguel.Name = "txtBuscaAluguel";
            this.txtBuscaAluguel.Size = new System.Drawing.Size(215, 23);
            this.txtBuscaAluguel.TabIndex = 2;
            // 
            // btnBuscarExcluirAluguel
            // 
            this.btnBuscarExcluirAluguel.FlatAppearance.BorderSize = 0;
            this.btnBuscarExcluirAluguel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarExcluirAluguel.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarExcluirAluguel.Image")));
            this.btnBuscarExcluirAluguel.Location = new System.Drawing.Point(233, 36);
            this.btnBuscarExcluirAluguel.Name = "btnBuscarExcluirAluguel";
            this.btnBuscarExcluirAluguel.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarExcluirAluguel.TabIndex = 3;
            this.btnBuscarExcluirAluguel.UseVisualStyleBackColor = true;
            this.btnBuscarExcluirAluguel.Click += new System.EventHandler(this.btnBuscarExcluirAluguel_Click);
            // 
            // btnCancelarExcluirAluguel
            // 
            this.btnCancelarExcluirAluguel.Location = new System.Drawing.Point(184, 72);
            this.btnCancelarExcluirAluguel.Name = "btnCancelarExcluirAluguel";
            this.btnCancelarExcluirAluguel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarExcluirAluguel.TabIndex = 4;
            this.btnCancelarExcluirAluguel.Text = "Cancelar";
            this.btnCancelarExcluirAluguel.UseVisualStyleBackColor = true;
            this.btnCancelarExcluirAluguel.Click += new System.EventHandler(this.btnCancelarExcluirAluguel_Click);
            // 
            // ExcluirAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 107);
            this.Controls.Add(this.btnCancelarExcluirAluguel);
            this.Controls.Add(this.btnBuscarExcluirAluguel);
            this.Controls.Add(this.txtBuscaAluguel);
            this.Controls.Add(this.rabExcluirAluguelCliente);
            this.Controls.Add(this.rabExcluirAluguelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExcluirAluguel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir aluguel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rabExcluirAluguelTitulo;
        private System.Windows.Forms.RadioButton rabExcluirAluguelCliente;
        private System.Windows.Forms.TextBox txtBuscaAluguel;
        private System.Windows.Forms.Button btnBuscarExcluirAluguel;
        private System.Windows.Forms.Button btnCancelarExcluirAluguel;
    }
}