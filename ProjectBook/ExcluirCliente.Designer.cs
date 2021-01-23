
namespace ProjectBook
{
    partial class ExcluirCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcluirCliente));
            this.txtBuscarExcluirCliente = new System.Windows.Forms.TextBox();
            this.btnExcluirCliente = new System.Windows.Forms.Button();
            this.btnCancelarExcluirCliente = new System.Windows.Forms.Button();
            this.rabBsucarIdCliente = new System.Windows.Forms.RadioButton();
            this.rabBuscarNome = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtBuscarExcluirCliente
            // 
            this.txtBuscarExcluirCliente.Location = new System.Drawing.Point(12, 37);
            this.txtBuscarExcluirCliente.Name = "txtBuscarExcluirCliente";
            this.txtBuscarExcluirCliente.Size = new System.Drawing.Size(256, 23);
            this.txtBuscarExcluirCliente.TabIndex = 1;
            // 
            // btnExcluirCliente
            // 
            this.btnExcluirCliente.FlatAppearance.BorderSize = 0;
            this.btnExcluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirCliente.Image")));
            this.btnExcluirCliente.Location = new System.Drawing.Point(274, 37);
            this.btnExcluirCliente.Name = "btnExcluirCliente";
            this.btnExcluirCliente.Size = new System.Drawing.Size(27, 23);
            this.btnExcluirCliente.TabIndex = 2;
            this.btnExcluirCliente.UseVisualStyleBackColor = true;
            this.btnExcluirCliente.Click += new System.EventHandler(this.btnExcluirCliente_Click);
            // 
            // btnCancelarExcluirCliente
            // 
            this.btnCancelarExcluirCliente.Location = new System.Drawing.Point(227, 70);
            this.btnCancelarExcluirCliente.Name = "btnCancelarExcluirCliente";
            this.btnCancelarExcluirCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarExcluirCliente.TabIndex = 3;
            this.btnCancelarExcluirCliente.Text = "Cancelar";
            this.btnCancelarExcluirCliente.UseVisualStyleBackColor = true;
            this.btnCancelarExcluirCliente.Click += new System.EventHandler(this.btnCancelarExcluirCliente_Click);
            // 
            // rabBsucarIdCliente
            // 
            this.rabBsucarIdCliente.AutoSize = true;
            this.rabBsucarIdCliente.Location = new System.Drawing.Point(12, 12);
            this.rabBsucarIdCliente.Name = "rabBsucarIdCliente";
            this.rabBsucarIdCliente.Size = new System.Drawing.Size(36, 19);
            this.rabBsucarIdCliente.TabIndex = 4;
            this.rabBsucarIdCliente.TabStop = true;
            this.rabBsucarIdCliente.Text = "ID";
            this.rabBsucarIdCliente.UseVisualStyleBackColor = true;
            // 
            // rabBuscarNome
            // 
            this.rabBuscarNome.AutoSize = true;
            this.rabBuscarNome.Location = new System.Drawing.Point(210, 12);
            this.rabBuscarNome.Name = "rabBuscarNome";
            this.rabBuscarNome.Size = new System.Drawing.Size(58, 19);
            this.rabBuscarNome.TabIndex = 5;
            this.rabBuscarNome.TabStop = true;
            this.rabBuscarNome.Text = "Nome";
            this.rabBuscarNome.UseVisualStyleBackColor = true;
            // 
            // ExcluirCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 105);
            this.Controls.Add(this.rabBuscarNome);
            this.Controls.Add(this.rabBsucarIdCliente);
            this.Controls.Add(this.btnCancelarExcluirCliente);
            this.Controls.Add(this.btnExcluirCliente);
            this.Controls.Add(this.txtBuscarExcluirCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExcluirCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBuscarExcluirCliente;
        private System.Windows.Forms.Button btnExcluirCliente;
        private System.Windows.Forms.Button btnCancelarExcluirCliente;
        private System.Windows.Forms.RadioButton rabBsucarIdCliente;
        private System.Windows.Forms.RadioButton rabBuscarNome;
    }
}