
namespace ProjectBook
{
    partial class ListaPesquisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPesquisa));
            this.dgvListaLivros = new System.Windows.Forms.DataGridView();
            this.mnuListaLivros = new System.Windows.Forms.MenuStrip();
            this.mnuImprimirLista = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLivros)).BeginInit();
            this.mnuListaLivros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListaLivros
            // 
            this.dgvListaLivros.AllowUserToAddRows = false;
            this.dgvListaLivros.AllowUserToDeleteRows = false;
            this.dgvListaLivros.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaLivros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaLivros.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvListaLivros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListaLivros.Location = new System.Drawing.Point(0, 24);
            this.dgvListaLivros.Name = "dgvListaLivros";
            this.dgvListaLivros.ReadOnly = true;
            this.dgvListaLivros.RowTemplate.Height = 25;
            this.dgvListaLivros.Size = new System.Drawing.Size(822, 472);
            this.dgvListaLivros.TabIndex = 0;
            // 
            // mnuListaLivros
            // 
            this.mnuListaLivros.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mnuListaLivros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImprimirLista});
            this.mnuListaLivros.Location = new System.Drawing.Point(0, 0);
            this.mnuListaLivros.Name = "mnuListaLivros";
            this.mnuListaLivros.Size = new System.Drawing.Size(822, 24);
            this.mnuListaLivros.TabIndex = 1;
            this.mnuListaLivros.Text = "menuStrip1";
            // 
            // mnuImprimirLista
            // 
            this.mnuImprimirLista.Image = ((System.Drawing.Image)(resources.GetObject("mnuImprimirLista.Image")));
            this.mnuImprimirLista.Name = "mnuImprimirLista";
            this.mnuImprimirLista.Size = new System.Drawing.Size(28, 20);
            this.mnuImprimirLista.ToolTipText = "Imprimir";
            // 
            // ListaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 496);
            this.Controls.Add(this.dgvListaLivros);
            this.Controls.Add(this.mnuListaLivros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuListaLivros;
            this.Name = "ListaPesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaLivros)).EndInit();
            this.mnuListaLivros.ResumeLayout(false);
            this.mnuListaLivros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaLivros;
        private System.Windows.Forms.MenuStrip mnuListaLivros;
        private System.Windows.Forms.ToolStripMenuItem mnuImprimirLista;
    }
}