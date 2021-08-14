
namespace ProjectBook.GUI
{
    partial class UpdateApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateApp));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemindLater = new System.Windows.Forms.Button();
            this.lblUpdateInfo = new System.Windows.Forms.Label();
            this.wbvUpdate = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.pgbDownload = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.wbvUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 415);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Atualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemindLater
            // 
            this.btnRemindLater.Location = new System.Drawing.Point(238, 415);
            this.btnRemindLater.Name = "btnRemindLater";
            this.btnRemindLater.Size = new System.Drawing.Size(122, 23);
            this.btnRemindLater.TabIndex = 1;
            this.btnRemindLater.Text = "Lembrar mais tarde";
            this.btnRemindLater.UseVisualStyleBackColor = true;
            this.btnRemindLater.Click += new System.EventHandler(this.btnRemindLater_Click);
            // 
            // lblUpdateInfo
            // 
            this.lblUpdateInfo.AutoSize = true;
            this.lblUpdateInfo.Location = new System.Drawing.Point(12, 9);
            this.lblUpdateInfo.Name = "lblUpdateInfo";
            this.lblUpdateInfo.Size = new System.Drawing.Size(151, 45);
            this.lblUpdateInfo.TabIndex = 2;
            this.lblUpdateInfo.Text = "Há uma nova versão de {0}.\r\nAtual: {1}\r\nNova: {2}";
            // 
            // wbvUpdate
            // 
            this.wbvUpdate.CreationProperties = null;
            this.wbvUpdate.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wbvUpdate.Location = new System.Drawing.Point(12, 69);
            this.wbvUpdate.Name = "wbvUpdate";
            this.wbvUpdate.Size = new System.Drawing.Size(348, 340);
            this.wbvUpdate.TabIndex = 3;
            this.wbvUpdate.ZoomFactor = 1D;
            // 
            // pgbDownload
            // 
            this.pgbDownload.Location = new System.Drawing.Point(12, 452);
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Size = new System.Drawing.Size(348, 23);
            this.pgbDownload.TabIndex = 4;
            // 
            // UpdateApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 446);
            this.Controls.Add(this.pgbDownload);
            this.Controls.Add(this.wbvUpdate);
            this.Controls.Add(this.lblUpdateInfo);
            this.Controls.Add(this.btnRemindLater);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UpdateApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualização disponivel";
            this.Load += new System.EventHandler(this.Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wbvUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemindLater;
        private System.Windows.Forms.Label lblUpdateInfo;
        private Microsoft.Web.WebView2.WinForms.WebView2 wbvUpdate;
        private System.Windows.Forms.ProgressBar pgbDownload;
    }
}