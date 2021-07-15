
namespace ProjectBook.GUI
{
    partial class ExcluirUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoDeletarUsuario = new System.Windows.Forms.TextBox();
            this.btnPesquisarExcluirUsuario = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // txtCodigoDeletarUsuario
            // 
            this.txtCodigoDeletarUsuario.Location = new System.Drawing.Point(12, 27);
            this.txtCodigoDeletarUsuario.Name = "txtCodigoDeletarUsuario";
            this.txtCodigoDeletarUsuario.Size = new System.Drawing.Size(201, 23);
            this.txtCodigoDeletarUsuario.TabIndex = 1;
            // 
            // btnPesquisarExcluirUsuario
            // 
            this.btnPesquisarExcluirUsuario.FlatAppearance.BorderSize = 0;
            this.btnPesquisarExcluirUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarExcluirUsuario.Image = global::ProjectBook.Properties.Resources.search;
            this.btnPesquisarExcluirUsuario.Location = new System.Drawing.Point(219, 27);
            this.btnPesquisarExcluirUsuario.Name = "btnPesquisarExcluirUsuario";
            this.btnPesquisarExcluirUsuario.Size = new System.Drawing.Size(27, 23);
            this.btnPesquisarExcluirUsuario.TabIndex = 2;
            this.btnPesquisarExcluirUsuario.UseVisualStyleBackColor = true;
            this.btnPesquisarExcluirUsuario.Click += new System.EventHandler(this.btnPesquisarExcluirUsuario_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::ProjectBook.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(167, 72);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ExcluirUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 107);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPesquisarExcluirUsuario);
            this.Controls.Add(this.txtCodigoDeletarUsuario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExcluirUsuario";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir usuário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoDeletarUsuario;
        private System.Windows.Forms.Button btnPesquisarExcluirUsuario;
        private System.Windows.Forms.Button btnCancelar;
    }
}