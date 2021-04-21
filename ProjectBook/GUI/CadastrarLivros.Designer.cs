
namespace ProjectBook.GUI
{
    partial class CadastroLivro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroLivro));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTituloLivro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutorLivro = new System.Windows.Forms.TextBox();
            this.txtEditoraLivro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEdicaoLivro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSalvarLivro = new System.Windows.Forms.Button();
            this.btnLimparTxtLivros = new System.Windows.Forms.Button();
            this.btnFecharCadastro = new System.Windows.Forms.Button();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoLivro = new System.Windows.Forms.TextBox();
            this.txtIsbn = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObservacoesCadastro = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtTituloLivro
            // 
            resources.ApplyResources(this.txtTituloLivro, "txtTituloLivro");
            this.txtTituloLivro.Name = "txtTituloLivro";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtAutorLivro
            // 
            this.txtAutorLivro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAutorLivro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtAutorLivro, "txtAutorLivro");
            this.txtAutorLivro.Name = "txtAutorLivro";
            // 
            // txtEditoraLivro
            // 
            this.txtEditoraLivro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtEditoraLivro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            resources.ApplyResources(this.txtEditoraLivro, "txtEditoraLivro");
            this.txtEditoraLivro.Name = "txtEditoraLivro";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtEdicaoLivro
            // 
            resources.ApplyResources(this.txtEdicaoLivro, "txtEdicaoLivro");
            this.txtEdicaoLivro.Name = "txtEdicaoLivro";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtAno
            // 
            resources.ApplyResources(this.txtAno, "txtAno");
            this.txtAno.Name = "txtAno";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // btnSalvarLivro
            // 
            this.btnSalvarLivro.Image = global::ProjectBook.Properties.Images.Images.save;
            resources.ApplyResources(this.btnSalvarLivro, "btnSalvarLivro");
            this.btnSalvarLivro.Name = "btnSalvarLivro";
            this.btnSalvarLivro.UseVisualStyleBackColor = true;
            this.btnSalvarLivro.Click += new System.EventHandler(this.btnSalvarLivro_Click);
            // 
            // btnLimparTxtLivros
            // 
            this.btnLimparTxtLivros.Image = global::ProjectBook.Properties.Images.Images.textfield;
            resources.ApplyResources(this.btnLimparTxtLivros, "btnLimparTxtLivros");
            this.btnLimparTxtLivros.Name = "btnLimparTxtLivros";
            this.btnLimparTxtLivros.UseVisualStyleBackColor = true;
            this.btnLimparTxtLivros.Click += new System.EventHandler(this.btnLimparTxtLivros_Click);
            // 
            // btnFecharCadastro
            // 
            this.btnFecharCadastro.Image = global::ProjectBook.Properties.Images.Images.cancel;
            resources.ApplyResources(this.btnFecharCadastro, "btnFecharCadastro");
            this.btnFecharCadastro.Name = "btnFecharCadastro";
            this.btnFecharCadastro.UseVisualStyleBackColor = true;
            this.btnFecharCadastro.Click += new System.EventHandler(this.btnFecharCadastro_Click);
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            resources.ApplyResources(this.cmbGenero, "cmbGenero");
            this.cmbGenero.Name = "cmbGenero";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtCodigoLivro
            // 
            this.txtCodigoLivro.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.txtCodigoLivro, "txtCodigoLivro");
            this.txtCodigoLivro.ForeColor = System.Drawing.Color.White;
            this.txtCodigoLivro.Name = "txtCodigoLivro";
            // 
            // txtIsbn
            // 
            resources.ApplyResources(this.txtIsbn, "txtIsbn");
            this.txtIsbn.Name = "txtIsbn";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtObservacoesCadastro
            // 
            resources.ApplyResources(this.txtObservacoesCadastro, "txtObservacoesCadastro");
            this.txtObservacoesCadastro.Name = "txtObservacoesCadastro";
            // 
            // CadastroLivro
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtObservacoesCadastro);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.txtCodigoLivro);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.btnFecharCadastro);
            this.Controls.Add(this.btnLimparTxtLivros);
            this.Controls.Add(this.btnSalvarLivro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEdicaoLivro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEditoraLivro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAutorLivro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTituloLivro);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CadastroLivro";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTituloLivro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutorLivro;
        private System.Windows.Forms.TextBox txtEditoraLivro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEdicaoLivro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSalvarLivro;
        private System.Windows.Forms.Button btnLimparTxtLivros;
        private System.Windows.Forms.Button btnFecharCadastro;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoLivro;
        private System.Windows.Forms.MaskedTextBox txtIsbn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox txtObservacoesCadastro;
    }
}