
namespace ProjectBook.GUI
{
    partial class PersonalizarImpressao
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
            this.txtTituloPagina = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSubtituloPagina = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRodape = new System.Windows.Forms.TextBox();
            this.btnSalvarPersonalizacao = new System.Windows.Forms.Button();
            this.chbExibirCodigo = new System.Windows.Forms.CheckBox();
            this.chbNPagina = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Título:";
            // 
            // txtTituloPagina
            // 
            this.txtTituloPagina.Location = new System.Drawing.Point(13, 32);
            this.txtTituloPagina.Name = "txtTituloPagina";
            this.txtTituloPagina.Size = new System.Drawing.Size(157, 23);
            this.txtTituloPagina.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subtítulo:";
            // 
            // txtSubtituloPagina
            // 
            this.txtSubtituloPagina.Location = new System.Drawing.Point(13, 81);
            this.txtSubtituloPagina.Name = "txtSubtituloPagina";
            this.txtSubtituloPagina.Size = new System.Drawing.Size(157, 23);
            this.txtSubtituloPagina.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rodapé";
            // 
            // txtRodape
            // 
            this.txtRodape.Location = new System.Drawing.Point(13, 130);
            this.txtRodape.Name = "txtRodape";
            this.txtRodape.Size = new System.Drawing.Size(157, 23);
            this.txtRodape.TabIndex = 5;
            // 
            // btnSalvarPersonalizacao
            // 
            this.btnSalvarPersonalizacao.Location = new System.Drawing.Point(267, 139);
            this.btnSalvarPersonalizacao.Name = "btnSalvarPersonalizacao";
            this.btnSalvarPersonalizacao.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarPersonalizacao.TabIndex = 7;
            this.btnSalvarPersonalizacao.Text = "Salvar";
            this.btnSalvarPersonalizacao.UseVisualStyleBackColor = true;
            this.btnSalvarPersonalizacao.Click += new System.EventHandler(this.btnSalvarPersonalizacao_Click);
            // 
            // chbExibirCodigo
            // 
            this.chbExibirCodigo.AutoSize = true;
            this.chbExibirCodigo.Location = new System.Drawing.Point(179, 13);
            this.chbExibirCodigo.Name = "chbExibirCodigo";
            this.chbExibirCodigo.Size = new System.Drawing.Size(95, 19);
            this.chbExibirCodigo.TabIndex = 8;
            this.chbExibirCodigo.Text = "Exibir código";
            this.chbExibirCodigo.UseVisualStyleBackColor = true;
            // 
            // chbNPagina
            // 
            this.chbNPagina.AutoSize = true;
            this.chbNPagina.Location = new System.Drawing.Point(179, 39);
            this.chbNPagina.Name = "chbNPagina";
            this.chbNPagina.Size = new System.Drawing.Size(155, 19);
            this.chbNPagina.TabIndex = 9;
            this.chbNPagina.Text = "Exibir número da página";
            this.chbNPagina.UseVisualStyleBackColor = true;
            // 
            // PersonalizarImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 174);
            this.Controls.Add(this.chbNPagina);
            this.Controls.Add(this.chbExibirCodigo);
            this.Controls.Add(this.btnSalvarPersonalizacao);
            this.Controls.Add(this.txtRodape);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSubtituloPagina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTituloPagina);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PersonalizarImpressao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personalizar impressão";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTituloPagina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSubtituloPagina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRodape;
        private System.Windows.Forms.Button btnSalvarPersonalizacao;
        private System.Windows.Forms.CheckBox chbExibirCodigo;
        private System.Windows.Forms.CheckBox chbNPagina;
    }
}