
namespace ProjectBook
{
    partial class PesquisaRapida
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblParaCaixaTexto = new System.Windows.Forms.Label();
            this.rabLivroId = new System.Windows.Forms.RadioButton();
            this.rabLivroNome = new System.Windows.Forms.RadioButton();
            this.rabClienteId = new System.Windows.Forms.RadioButton();
            this.rabClienteNome = new System.Windows.Forms.RadioButton();
            this.txtPesquisaRapida = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblParaCaixaTexto, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // lblParaCaixaTexto
            // 
            this.lblParaCaixaTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblParaCaixaTexto.AutoSize = true;
            this.lblParaCaixaTexto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblParaCaixaTexto.Location = new System.Drawing.Point(133, 0);
            this.lblParaCaixaTexto.Name = "lblParaCaixaTexto";
            this.lblParaCaixaTexto.Size = new System.Drawing.Size(130, 28);
            this.lblParaCaixaTexto.TabIndex = 0;
            this.lblParaCaixaTexto.Text = "Pesquisa rápida";
            // 
            // rabLivroId
            // 
            this.rabLivroId.AutoSize = true;
            this.rabLivroId.Location = new System.Drawing.Point(12, 34);
            this.rabLivroId.Name = "rabLivroId";
            this.rabLivroId.Size = new System.Drawing.Size(73, 19);
            this.rabLivroId.TabIndex = 1;
            this.rabLivroId.TabStop = true;
            this.rabLivroId.Text = "Livro (ID)";
            this.rabLivroId.UseVisualStyleBackColor = true;
            // 
            // rabLivroNome
            // 
            this.rabLivroNome.AutoSize = true;
            this.rabLivroNome.Location = new System.Drawing.Point(91, 34);
            this.rabLivroNome.Name = "rabLivroNome";
            this.rabLivroNome.Size = new System.Drawing.Size(95, 19);
            this.rabLivroNome.TabIndex = 2;
            this.rabLivroNome.TabStop = true;
            this.rabLivroNome.Text = "Livro (Nome)";
            this.rabLivroNome.UseVisualStyleBackColor = true;
            // 
            // rabClienteId
            // 
            this.rabClienteId.AutoSize = true;
            this.rabClienteId.Location = new System.Drawing.Point(195, 34);
            this.rabClienteId.Name = "rabClienteId";
            this.rabClienteId.Size = new System.Drawing.Size(84, 19);
            this.rabClienteId.TabIndex = 3;
            this.rabClienteId.TabStop = true;
            this.rabClienteId.Text = "Cliente (ID)";
            this.rabClienteId.UseVisualStyleBackColor = true;
            // 
            // rabClienteNome
            // 
            this.rabClienteNome.AutoSize = true;
            this.rabClienteNome.Location = new System.Drawing.Point(287, 34);
            this.rabClienteNome.Name = "rabClienteNome";
            this.rabClienteNome.Size = new System.Drawing.Size(106, 19);
            this.rabClienteNome.TabIndex = 4;
            this.rabClienteNome.TabStop = true;
            this.rabClienteNome.Text = "Cliente (Nome)";
            this.rabClienteNome.UseVisualStyleBackColor = true;
            // 
            // txtPesquisaRapida
            // 
            this.txtPesquisaRapida.Location = new System.Drawing.Point(12, 60);
            this.txtPesquisaRapida.Name = "txtPesquisaRapida";
            this.txtPesquisaRapida.Size = new System.Drawing.Size(381, 23);
            this.txtPesquisaRapida.TabIndex = 5;
            this.txtPesquisaRapida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisaRapida_KeyDown);
            // 
            // PesquisaRapida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(396, 85);
            this.ControlBox = false;
            this.Controls.Add(this.txtPesquisaRapida);
            this.Controls.Add(this.rabClienteNome);
            this.Controls.Add(this.rabClienteId);
            this.Controls.Add(this.rabLivroNome);
            this.Controls.Add(this.rabLivroId);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PesquisaRapida";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Deactivate += new System.EventHandler(this.PesquisaRapida_Deactivate);
            this.Load += new System.EventHandler(this.PesquisaRapida_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblParaCaixaTexto;
        private System.Windows.Forms.RadioButton rabLivroId;
        private System.Windows.Forms.RadioButton rabLivroNome;
        private System.Windows.Forms.RadioButton rabClienteId;
        private System.Windows.Forms.RadioButton rabClienteNome;
        private System.Windows.Forms.TextBox txtPesquisaRapida;
    }
}