
namespace ProjectBook.GUI
{
    partial class PesquisarCliente
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
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            this.txtPesquisarCliente = new System.Windows.Forms.TextBox();
            this.rabPesquisarNome = new System.Windows.Forms.RadioButton();
            this.rabPesquisarId = new System.Windows.Forms.RadioButton();
            this.btnCancelarPesquisarCliente = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.FlatAppearance.BorderSize = 0;
            this.btnPesquisarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarCliente.Image = global::ProjectBook.Properties.Resources.zoom;
            this.btnPesquisarCliente.Location = new System.Drawing.Point(206, 69);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(23, 23);
            this.btnPesquisarCliente.TabIndex = 2;
            this.btnPesquisarCliente.UseVisualStyleBackColor = true;
            this.btnPesquisarCliente.Click += new System.EventHandler(this.btnPesquisarCliente_Click);
            // 
            // txtPesquisarCliente
            // 
            this.txtPesquisarCliente.Location = new System.Drawing.Point(11, 69);
            this.txtPesquisarCliente.Name = "txtPesquisarCliente";
            this.txtPesquisarCliente.Size = new System.Drawing.Size(189, 23);
            this.txtPesquisarCliente.TabIndex = 3;
            // 
            // rabPesquisarNome
            // 
            this.rabPesquisarNome.AutoSize = true;
            this.rabPesquisarNome.Location = new System.Drawing.Point(153, 22);
            this.rabPesquisarNome.Name = "rabPesquisarNome";
            this.rabPesquisarNome.Size = new System.Drawing.Size(58, 19);
            this.rabPesquisarNome.TabIndex = 1;
            this.rabPesquisarNome.TabStop = true;
            this.rabPesquisarNome.Text = "Nome";
            this.rabPesquisarNome.UseVisualStyleBackColor = true;
            // 
            // rabPesquisarId
            // 
            this.rabPesquisarId.AutoSize = true;
            this.rabPesquisarId.Location = new System.Drawing.Point(6, 22);
            this.rabPesquisarId.Name = "rabPesquisarId";
            this.rabPesquisarId.Size = new System.Drawing.Size(64, 19);
            this.rabPesquisarId.TabIndex = 0;
            this.rabPesquisarId.TabStop = true;
            this.rabPesquisarId.Text = "Código";
            this.rabPesquisarId.UseVisualStyleBackColor = true;
            // 
            // btnCancelarPesquisarCliente
            // 
            this.btnCancelarPesquisarCliente.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelarPesquisarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarPesquisarCliente.Location = new System.Drawing.Point(161, 106);
            this.btnCancelarPesquisarCliente.Name = "btnCancelarPesquisarCliente";
            this.btnCancelarPesquisarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarPesquisarCliente.TabIndex = 5;
            this.btnCancelarPesquisarCliente.Text = "Cancelar";
            this.btnCancelarPesquisarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarPesquisarCliente.UseVisualStyleBackColor = true;
            this.btnCancelarPesquisarCliente.Click += new System.EventHandler(this.btnCancelarPesquisarCliente_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rabPesquisarNome);
            this.groupBox1.Controls.Add(this.rabPesquisarId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 51);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pesquisar por:";
            // 
            // PesquisarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 141);
            this.Controls.Add(this.btnCancelarPesquisarCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPesquisarCliente);
            this.Controls.Add(this.btnPesquisarCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PesquisarCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPesquisarCliente;
        private System.Windows.Forms.TextBox txtPesquisarCliente;
        private System.Windows.Forms.RadioButton rabPesquisarNome;
        private System.Windows.Forms.RadioButton rabPesquisarId;
        private System.Windows.Forms.Button btnCancelarPesquisarCliente;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}