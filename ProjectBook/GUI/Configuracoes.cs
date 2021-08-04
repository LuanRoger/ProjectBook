using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProjectBook.Properties;
using ProjectBook.Tipos;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.GUI
{
    public partial class Configuracoes : Form
    {
        public Configuracoes()
        {
            InitializeComponent();
            CarregarConfiguracoes();

            gpbBancoDados.Enabled = UserInfo.UserNowInstance.tipoUsuario == TipoUsuario.ADM;

            rabOneDrive.Visible = Verificadores.IsWin10();
        }

        #region CheckedChanged
        private void rabSqlServerExpress_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = Resources.StringConexaoConfiguracoes;

            lblInfoTxt.ForeColor = Color.Black;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(459, 23);
        }
        private void rabSqlServerLocalDb_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = Resources.CaminhoBanco;
            lblInfoTxt.ForeColor = Color.Black;
            btnSelecionarArquivoDb.Visible = true;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(426, 23);
        }
        private void rabOneDrive_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Visible = false;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Visible = false;

            DirectoryInfo directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.databaseConfiguration.DbFolder) ?
                null : Directory.GetParent(AppConfigurationManager.databaseConfiguration.DbFolder);

            if(directoryInfo == null && directoryInfo.Parent == null)
            {
                MessageBox.Show(Resources.ConexaoLocalMigrarOneDrive,
                    Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                rabSqlServerLocalDb.Checked = true;
                return;
            }
            if (Verificadores.HasSyncOneDrive(directoryInfo))
            {
                lblInfoTxt.Visible = true;
                lblInfoTxt.Text = Resources.BancoSincronizadoOneDrive;
                lblInfoTxt.ForeColor = Color.Green;
            }
        }
        #endregion

        private void CarregarConfiguracoes()
        {
            var directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.databaseConfiguration.DbFolder) ?
                "" : Directory.GetParent(AppConfigurationManager.databaseConfiguration.DbFolder).ToString();

            chbVisualizarImpressao.Checked = AppConfigurationManager.printerConfiguration.PreviewPrinter;
            chbAtualizarStatusAluguel.Checked = AppConfigurationManager.rentingConfiguration.UpdateRentStatus;
            chbFormatarCliente.Checked =  AppConfigurationManager.formattingConfiguration.FormatClient;
            chbFormatarLivro.Checked = AppConfigurationManager.formattingConfiguration.FormatBook;
            chbExibirCodigo.Checked = AppConfigurationManager.printerConfiguration.ShowId;
            chbTelemetria.Checked = AppConfigurationManager.TelemetryConfiguration.UseTelemetry;

            switch (AppConfigurationManager.databaseConfiguration.DbEngine)
            {
                case TipoDatabase.SqlServerExpress:
                    rabSqlServerExpress.Checked = true;
                    break;
                case TipoDatabase.SqlServerLocalDb:
                    rabSqlServerLocalDb.Checked = true;
                    break;
                case TipoDatabase.OneDrive when directoryInfo.Contains("OneDrive"):
                    rabOneDrive.Checked = true;
                    break;
            }
            txtStringConexaoCaminhoDb.Text = AppConfigurationManager.databaseConfiguration.SqlConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            //Nescessario para verificar se houve mudança
            string stringConexaoAtual = AppConfigurationManager.databaseConfiguration.SqlConnectionString;

            //Preferencias de impressão
            AppConfigurationManager.printerConfiguration.PreviewPrinter = chbVisualizarImpressao.Checked;
            AppConfigurationManager.printerConfiguration.ShowId = chbExibirCodigo.Checked;
            
            //Formatação
            AppConfigurationManager.formattingConfiguration.FormatClient = chbFormatarCliente.Checked;
            AppConfigurationManager.formattingConfiguration.FormatBook = chbFormatarLivro.Checked;

            //Preferencias de aluguel
            AppConfigurationManager.rentingConfiguration.UpdateRentStatus = chbAtualizarStatusAluguel.Checked;

            //Telemetria
            AppConfigurationManager.TelemetryConfiguration.UseTelemetry = chbTelemetria.Checked;

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                AppConfigurationManager.databaseConfiguration.DbEngine = TipoDatabase.SqlServerExpress;
                AppConfigurationManager.databaseConfiguration.SqlConnectionString = txtStringConexaoCaminhoDb.Text;
                AppConfigurationManager.databaseConfiguration.DbFolder = "";
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                AppConfigurationManager.databaseConfiguration.DbEngine = AppConfigurationManager.databaseConfiguration.DbFolder.Contains("OneDrive") ?
                    TipoDatabase.OneDrive : TipoDatabase.SqlServerLocalDb;

                AppConfigurationManager.databaseConfiguration.SqlConnectionString = txtStringConexaoCaminhoDb.Text;
            }
            else if (rabOneDrive.Checked && !AppConfigurationManager.databaseConfiguration.DbFolder.Contains("OneDrive"))
            {
                DialogResult dialogResult = MessageBox
                    .Show(Resources.ConexaoLocalMigrarOneDrive,
                    Resources.MessageBoxInformacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;

                AppConfigurationManager.databaseConfiguration.DbFolder = "onedrive";
                AppConfigurationManager.databaseConfiguration.SqlConnectionString = "";
            }

            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Se o usuário mudou a string de conexão o programa deve ser reinicado
            if (!stringConexaoAtual.Equals(AppConfigurationManager.databaseConfiguration.SqlConnectionString))
            {
                MessageBox.Show(Resources.mudancaConnectionString,
                    Resources.MessageBoxInformacao, MessageBoxButtons.OK, MessageBoxIcon.Information);

                AppManager.ReiniciarPrograma();
            }
        }

        private void btnSelecionarArquivoDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog caminho = new() { Filter = "Arquivo MDF (*.mdf)|*.mdf", Multiselect = false };
            DialogResult dialogResult = caminho.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            AppConfigurationManager.databaseConfiguration.DbFolder = caminho.FileName;
            txtStringConexaoCaminhoDb.Text =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={caminho.FileName};Integrated Security=True";
        }
    }
}
