﻿
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
            this.trbAlinhamentoTitulo = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trbAlinhamentoSubtitulo = new System.Windows.Forms.TrackBar();
            this.trbAlinhamentoRodape = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbAlinhamentoTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAlinhamentoSubtitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAlinhamentoRodape)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(189, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Subtítulo:";
            // 
            // txtSubtituloPagina
            // 
            this.txtSubtituloPagina.Location = new System.Drawing.Point(189, 32);
            this.txtSubtituloPagina.Name = "txtSubtituloPagina";
            this.txtSubtituloPagina.Size = new System.Drawing.Size(157, 23);
            this.txtSubtituloPagina.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rodapé";
            // 
            // txtRodape
            // 
            this.txtRodape.Location = new System.Drawing.Point(369, 32);
            this.txtRodape.Name = "txtRodape";
            this.txtRodape.Size = new System.Drawing.Size(157, 23);
            this.txtRodape.TabIndex = 5;
            // 
            // btnSalvarPersonalizacao
            // 
            this.btnSalvarPersonalizacao.Image = global::ProjectBook.Properties.Resources.save;
            this.btnSalvarPersonalizacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarPersonalizacao.Location = new System.Drawing.Point(500, 180);
            this.btnSalvarPersonalizacao.Name = "btnSalvarPersonalizacao";
            this.btnSalvarPersonalizacao.Size = new System.Drawing.Size(63, 23);
            this.btnSalvarPersonalizacao.TabIndex = 7;
            this.btnSalvarPersonalizacao.Text = "Salvar";
            this.btnSalvarPersonalizacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarPersonalizacao.UseVisualStyleBackColor = true;
            this.btnSalvarPersonalizacao.Click += new System.EventHandler(this.btnSalvarPersonalizacao_Click);
            // 
            // chbExibirCodigo
            // 
            this.chbExibirCodigo.AutoSize = true;
            this.chbExibirCodigo.Location = new System.Drawing.Point(12, 156);
            this.chbExibirCodigo.Name = "chbExibirCodigo";
            this.chbExibirCodigo.Size = new System.Drawing.Size(95, 19);
            this.chbExibirCodigo.TabIndex = 8;
            this.chbExibirCodigo.Text = "Exibir código";
            this.chbExibirCodigo.UseVisualStyleBackColor = true;
            // 
            // chbNPagina
            // 
            this.chbNPagina.AutoSize = true;
            this.chbNPagina.Location = new System.Drawing.Point(113, 156);
            this.chbNPagina.Name = "chbNPagina";
            this.chbNPagina.Size = new System.Drawing.Size(155, 19);
            this.chbNPagina.TabIndex = 9;
            this.chbNPagina.Text = "Exibir número da página";
            this.chbNPagina.UseVisualStyleBackColor = true;
            // 
            // trbAlinhamentoTitulo
            // 
            this.trbAlinhamentoTitulo.LargeChange = 4;
            this.trbAlinhamentoTitulo.Location = new System.Drawing.Point(13, 76);
            this.trbAlinhamentoTitulo.Maximum = 2;
            this.trbAlinhamentoTitulo.Name = "trbAlinhamentoTitulo";
            this.trbAlinhamentoTitulo.Size = new System.Drawing.Size(157, 45);
            this.trbAlinhamentoTitulo.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Alinhamento do título:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Esquerda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Direita";
            // 
            // trbAlinhamentoSubtitulo
            // 
            this.trbAlinhamentoSubtitulo.LargeChange = 4;
            this.trbAlinhamentoSubtitulo.Location = new System.Drawing.Point(189, 76);
            this.trbAlinhamentoSubtitulo.Maximum = 2;
            this.trbAlinhamentoSubtitulo.Name = "trbAlinhamentoSubtitulo";
            this.trbAlinhamentoSubtitulo.Size = new System.Drawing.Size(157, 45);
            this.trbAlinhamentoSubtitulo.TabIndex = 10;
            // 
            // trbAlinhamentoRodape
            // 
            this.trbAlinhamentoRodape.LargeChange = 4;
            this.trbAlinhamentoRodape.Location = new System.Drawing.Point(369, 76);
            this.trbAlinhamentoRodape.Maximum = 2;
            this.trbAlinhamentoRodape.Name = "trbAlinhamentoRodape";
            this.trbAlinhamentoRodape.Size = new System.Drawing.Size(157, 45);
            this.trbAlinhamentoRodape.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Esquerda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Direita";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(356, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Esquerda";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(493, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Direita";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(189, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Alinhamento do subtítulo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(369, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 15);
            this.label12.TabIndex = 11;
            this.label12.Text = "Alinhamento do rodapé:";
            // 
            // PersonalizarImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 215);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trbAlinhamentoRodape);
            this.Controls.Add(this.trbAlinhamentoSubtitulo);
            this.Controls.Add(this.trbAlinhamentoTitulo);
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
            ((System.ComponentModel.ISupportInitialize)(this.trbAlinhamentoTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAlinhamentoSubtitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbAlinhamentoRodape)).EndInit();
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
        private System.Windows.Forms.TrackBar trbAlinhamentoTitulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trbAlinhamentoSubtitulo;
        private System.Windows.Forms.TrackBar trbAlinhamentoRodape;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}