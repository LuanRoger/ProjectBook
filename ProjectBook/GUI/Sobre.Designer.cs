
namespace ProjectBook.GUI
{
    partial class Sobre
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProgramName = new System.Windows.Forms.Label();
            this.lblProgramVersion = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblLicense = new System.Windows.Forms.Label();
            this.lblCreditsIcons = new System.Windows.Forms.Label();
            this.lblProjectUrl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ProjectBook.Properties.Resources.ProjectBookIcon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblProgramName
            // 
            this.lblProgramName.AutoSize = true;
            this.lblProgramName.Location = new System.Drawing.Point(119, 13);
            this.lblProgramName.Name = "lblProgramName";
            this.lblProgramName.Size = new System.Drawing.Size(66, 15);
            this.lblProgramName.TabIndex = 1;
            this.lblProgramName.Text = "placehoder";
            // 
            // lblProgramVersion
            // 
            this.lblProgramVersion.AutoSize = true;
            this.lblProgramVersion.Location = new System.Drawing.Point(121, 48);
            this.lblProgramVersion.Name = "lblProgramVersion";
            this.lblProgramVersion.Size = new System.Drawing.Size(45, 15);
            this.lblProgramVersion.TabIndex = 2;
            this.lblProgramVersion.Text = "version";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Location = new System.Drawing.Point(12, 173);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(108, 15);
            this.lblCreator.TabIndex = 4;
            this.lblCreator.Text = "placeholderCreator";
            // 
            // lblLicense
            // 
            this.lblLicense.AutoSize = true;
            this.lblLicense.Location = new System.Drawing.Point(165, 173);
            this.lblLicense.Name = "lblLicense";
            this.lblLicense.Size = new System.Drawing.Size(108, 15);
            this.lblLicense.TabIndex = 5;
            this.lblLicense.Text = "placeholderLicense";
            // 
            // lblCreditsIcons
            // 
            this.lblCreditsIcons.AutoSize = true;
            this.lblCreditsIcons.Location = new System.Drawing.Point(12, 115);
            this.lblCreditsIcons.Name = "lblCreditsIcons";
            this.lblCreditsIcons.Size = new System.Drawing.Size(97, 15);
            this.lblCreditsIcons.TabIndex = 6;
            this.lblCreditsIcons.Text = "placeholderIcons";
            // 
            // lblProjectUrl
            // 
            this.lblProjectUrl.AutoSize = true;
            this.lblProjectUrl.Location = new System.Drawing.Point(12, 134);
            this.lblProjectUrl.Name = "lblProjectUrl";
            this.lblProjectUrl.Size = new System.Drawing.Size(121, 15);
            this.lblProjectUrl.TabIndex = 7;
            this.lblProjectUrl.Text = "placeholderProjectUrl";
            // 
            // Sobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 197);
            this.Controls.Add(this.lblProjectUrl);
            this.Controls.Add(this.lblCreditsIcons);
            this.Controls.Add(this.lblLicense);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.lblProgramVersion);
            this.Controls.Add(this.lblProgramName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sobre";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobre";
            this.Load += new System.EventHandler(this.Sobre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.Label lblProgramVersion;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblLicense;
        private System.Windows.Forms.Label lblCreditsIcons;
        private System.Windows.Forms.Label lblProjectUrl;
    }
}