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
            lblInfoText.Text = Resources.StringConexao;
            lblInfoText.Visible = true;

            lblInfoText.ForeColor = Color.Black;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(459, 23);
        }
        private void rabSqlServerLocalDb_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoText.Visible = true;
            lblInfoText.Text = Resources.CaminhoBanco;
            lblInfoText.ForeColor = Color.Black;

            btnSelecionarArquivoDb.Visible = true;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(426, 23);
        }
        private void rabOneDrive_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoText.Visible = false;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Visible = false;

            DirectoryInfo directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.configuration.DbFolder) ?
                null : Directory.GetParent(AppConfigurationManager.configuration.DbFolder);

            if(directoryInfo == null && directoryInfo.Parent == null)
            {
                MessageBox.Show(Resources.ConexaoLocalMigrarOneDrive,
                    Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                rabSqlServerLocalDb.Checked = true;
                return;
            }
            if (Verificadores.HasSyncOneDrive(directoryInfo))
            {
                lblInfoText.Visible = true;
                lblInfoText.Text = Resources.BancoSincronizadoOneDrive;
                lblInfoText.ForeColor = Color.Green;
            }
        }
        #endregion

        private void CarregarConfiguracoes()
        {
            var directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.configuration.DbFolder) ?
                "" : Directory.GetParent(AppConfigurationManager.configuration.DbFolder).ToString();

            chbVisualizarImpressao.Checked = AppConfigurationManager.configuration.PreviewPrinter;
            chbAtualizarStatusAluguel.Checked = AppConfigurationManager.configuration.UpdateRentStatus;
            chbFormatarCliente.Checked =  AppConfigurationManager.configuration.FormatClient;
            chbFormatarLivro.Checked = AppConfigurationManager.configuration.FormatBook;
            chbExibirCodigo.Checked = AppConfigurationManager.configuration.ShowId;
            chbTelemetria.Checked = AppConfigurationManager.configuration.UseTelemetry;

            switch (AppConfigurationManager.configuration.DbEngine)
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
            txtStringConexaoCaminhoDb.Text = AppConfigurationManager.configuration.SqlConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            //Nescessario para verificar se houve mudança
            string stringConexaoAtual = AppConfigurationManager.configuration.SqlConnectionString;

            AppConfigurationManager.configuration = AppConfigurationManager.configuration with
            {
                PreviewPrinter = chbVisualizarImpressao.Checked,
                ShowId = chbExibirCodigo.Checked,
                FormatClient = chbFormatarCliente.Checked,
                FormatBook = chbFormatarLivro.Checked,
                UpdateRentStatus = chbAtualizarStatusAluguel.Checked,
                UseTelemetry = chbTelemetria.Checked,
            };

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                AppConfigurationManager.configuration = AppConfigurationManager.configuration with
                {
                    DbEngine = TipoDatabase.SqlServerExpress,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text,
                };
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                AppConfigurationManager.configuration = AppConfigurationManager.configuration with
                {
                    DbEngine = AppConfigurationManager.configuration.DbFolder.Contains("OneDrive") ?
                    TipoDatabase.OneDrive : TipoDatabase.SqlServerLocalDb,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text,
                };
            }
            else if (rabOneDrive.Checked && !AppConfigurationManager.configuration.DbFolder.Contains("OneDrive"))
            {
                DialogResult dialogResult = MessageBox
                    .Show(Resources.ConexaoLocalMigrarOneDrive,
                    Resources.Informacao_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;

                AppConfigurationManager.configuration = AppConfigurationManager.configuration with
                {
                    DbFolder = "onedrive",
                    SqlConnectionString = string.Empty
                };
            }

            AppConfigurationManager.SaveConfiguration();

            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.Concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Se o usuário mudou a string de conexão o programa deve reiniciar
            if (!stringConexaoAtual.Equals(AppConfigurationManager.configuration.SqlConnectionString))
            {
                MessageBox.Show(Resources.MudancaConnectionString,
                    Resources.Informacao_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);

                AppManager.ReiniciarPrograma();
            }
        }

        private void btnSelecionarArquivoDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog caminho = new() { Filter = Consts.MDF_FILE_FILTER, Multiselect = false };
            DialogResult dialogResult = caminho.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            AppConfigurationManager.configuration = AppConfigurationManager.configuration with
            {
                DbFolder = caminho.FileName
            };
            txtStringConexaoCaminhoDb.Text =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={caminho.FileName};Integrated Security=True";
        }

        private void btnRedefinirConfig_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Resources.RedefinirConfig, Resources.Aviso_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialogResult != DialogResult.Yes) return;

            AppConfigurationManager.ResetConfig();
            AppManager.ReiniciarPrograma();
        }
    }
}
