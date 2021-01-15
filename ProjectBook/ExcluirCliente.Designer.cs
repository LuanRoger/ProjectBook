
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarExcluirCliente = new System.Windows.Forms.TextBox();
            this.btnExcluirCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID cliente:";
            // 
            // txtBuscarExcluirCliente
            // 
            this.txtBuscarExcluirCliente.Location = new System.Drawing.Point(13, 29);
            this.txtBuscarExcluirCliente.Name = "txtBuscarExcluirCliente";
            this.txtBuscarExcluirCliente.Size = new System.Drawing.Size(256, 23);
            this.txtBuscarExcluirCliente.TabIndex = 1;
            // 
            // btnExcluirCliente
            // 
            this.btnExcluirCliente.FlatAppearance.BorderSize = 0;
            this.btnExcluirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirCliente.Image")));
            this.btnExcluirCliente.Location = new System.Drawing.Point(275, 29);
            this.btnExcluirCliente.Name = "btnExcluirCliente";
            this.btnExcluirCliente.Size = new System.Drawing.Size(27, 23);
            this.btnExcluirCliente.TabIndex = 2;
            this.btnExcluirCliente.UseVisualStyleBackColor = true;
            this.btnExcluirCliente.Click += new System.EventHandler(this.btnExcluirCliente_Click);
            // 
            // ExcluirCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 64);
            this.Controls.Add(this.btnExcluirCliente);
            this.Controls.Add(this.txtBuscarExcluirCliente);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarExcluirCliente;
        private System.Windows.Forms.Button btnExcluirCliente;
    }
}