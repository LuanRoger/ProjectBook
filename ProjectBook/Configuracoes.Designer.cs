
namespace ProjectBook
{
    partial class Configuracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracoes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbVisualizarImpressao = new System.Windows.Forms.CheckBox();
            this.btnSalvarConfiguracoes = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCaminhoArquivo = new System.Windows.Forms.Label();
            this.txtStringConexao = new System.Windows.Forms.TextBox();
            this.rabSqlServerExpress = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbVisualizarImpressao);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impressão";
            // 
            // chbVisualizarImpressao
            // 
            this.chbVisualizarImpressao.AutoSize = true;
            this.chbVisualizarImpressao.Location = new System.Drawing.Point(6, 22);
            this.chbVisualizarImpressao.Name = "chbVisualizarImpressao";
            this.chbVisualizarImpressao.Size = new System.Drawing.Size(140, 19);
            this.chbVisualizarImpressao.TabIndex = 1;
            this.chbVisualizarImpressao.Text = "Visualizar ao imprimir";
            this.chbVisualizarImpressao.UseVisualStyleBackColor = true;
            // 
            // btnSalvarConfiguracoes
            // 
            this.btnSalvarConfiguracoes.Location = new System.Drawing.Point(390, 182);
            this.btnSalvarConfiguracoes.Name = "btnSalvarConfiguracoes";
            this.btnSalvarConfiguracoes.Size = new System.Drawing.Size(75, 23);
            this.btnSalvarConfiguracoes.TabIndex = 1;
            this.btnSalvarConfiguracoes.Text = "Salvar";
            this.btnSalvarConfiguracoes.UseVisualStyleBackColor = true;
            this.btnSalvarConfiguracoes.Click += new System.EventHandler(this.btnSalvarConfiguracoes_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCaminhoArquivo);
            this.groupBox2.Controls.Add(this.txtStringConexao);
            this.groupBox2.Controls.Add(this.rabSqlServerExpress);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 105);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Banco de dados";
            // 
            // lblCaminhoArquivo
            // 
            this.lblCaminhoArquivo.AutoSize = true;
            this.lblCaminhoArquivo.Location = new System.Drawing.Point(6, 48);
            this.lblCaminhoArquivo.Name = "lblCaminhoArquivo";
            this.lblCaminhoArquivo.Size = new System.Drawing.Size(105, 15);
            this.lblCaminhoArquivo.TabIndex = 2;
            this.lblCaminhoArquivo.Text = "String de conexão:";
            // 
            // txtStringConexao
            // 
            this.txtStringConexao.Location = new System.Drawing.Point(6, 66);
            this.txtStringConexao.Name = "txtStringConexao";
            this.txtStringConexao.Size = new System.Drawing.Size(341, 23);
            this.txtStringConexao.TabIndex = 1;
            // 
            // rabSqlServerExpress
            // 
            this.rabSqlServerExpress.AutoSize = true;
            this.rabSqlServerExpress.Location = new System.Drawing.Point(6, 22);
            this.rabSqlServerExpress.Name = "rabSqlServerExpress";
            this.rabSqlServerExpress.Size = new System.Drawing.Size(123, 19);
            this.rabSqlServerExpress.TabIndex = 0;
            this.rabSqlServerExpress.TabStop = true;
            this.rabSqlServerExpress.Text = "SQL Server Express";
            this.rabSqlServerExpress.UseVisualStyleBackColor = true;
            // 
            // Configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 217);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalvarConfiguracoes);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbVisualizarImpressao;
        private System.Windows.Forms.Button btnSalvarConfiguracoes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCaminhoArquivo;
        private System.Windows.Forms.TextBox txtStringConexao;
        private System.Windows.Forms.RadioButton rabSqlServerExpress;
    }
}