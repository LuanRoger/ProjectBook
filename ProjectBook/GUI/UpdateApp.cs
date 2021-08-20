using System;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using NetMsixUpdater;
using NetMsixUpdater.Updater.Extensions;

namespace ProjectBook.GUI
{
    public partial class UpdateApp : Form
    {
        public MsixUpdater updateInfo { get; }

        public UpdateApp(MsixUpdater updateInfo)
        {
            InitializeComponent();
            
            UpdateExtension.OnUpdateDownloadProgresssChange += UpdateExtensionOnOnUpdateDownloadProgresssChange;
            this.updateInfo = updateInfo;
        }

        private void UpdateExtensionOnOnUpdateDownloadProgresssChange(object sender, DownloadProgressChangedEventArgs e) =>
            pgbDownload.Value = e.ProgressPercentage;

        private void Update_Load(object sender, EventArgs e)
        {
            lblTitle.Text = string.Format(lblTitle.Text, 
                Assembly.GetExecutingAssembly().GetName().Name); //Program name
            
            lblUpdateInfo.Text = string.Format(lblUpdateInfo.Text,
                Assembly.GetExecutingAssembly().GetName().Version, //Atual version
                updateInfo.yamlUpdateInfo.version); //New version
            
            wbvUpdate.Source = new Uri(updateInfo.yamlUpdateInfo.changelog);
        }

        private async void btnUpdate_Click(object sender, System.EventArgs e)
        {
            Size = new Size(388, 526);
            await updateInfo.DownloadAndInstallAsync();
        }

        private void btnRemindLater_Click(object sender, System.EventArgs e) =>
            Close();
    }
}
