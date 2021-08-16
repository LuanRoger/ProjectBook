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
        // TODO - Refatorar esta classe
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

            DirectoryInfo directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.configuration.database.DbFolder) ?
                null : Directory.GetParent(AppConfigurationManager.configuration.database.DbFolder);

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
            var directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.configuration.database.DbFolder) ?
                "" : Directory.GetParent(AppConfigurationManager.configuration.database.DbFolder).ToString();

            chbVisualizarImpressao.Checked = AppConfigurationManager.configuration.printer.PreviewPrinter;
            chbAtualizarStatusAluguel.Checked = AppConfigurationManager.configuration.renting.UpdateRentStatus;
            chbFormatarCliente.Checked =  AppConfigurationManager.configuration.formating.FormatClient;
            chbFormatarLivro.Checked = AppConfigurationManager.configuration.formating.FormatBook;
            chbExibirCodigo.Checked = AppConfigurationManager.configuration.printer.ShowId;
            chbTelemetria.Checked = AppConfigurationManager.configuration.telemetry.UseTelemetry;

            switch (AppConfigurationManager.configuration.database.DbEngine)
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
            txtStringConexaoCaminhoDb.Text = AppConfigurationManager.configuration.database.SqlConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            //Nescessario para verificar se houve mudança
            string stringConexaoAtual = AppConfigurationManager.configuration.database.SqlConnectionString;

            AppConfigurationManager.configuration = AppConfigurationManager.configuration with
            {
                printer = new()
                {
                    PreviewPrinter = chbVisualizarImpressao.Checked,
                    ShowId = chbExibirCodigo.Checked
                },
                formating = new() 
                {
                    FormatClient = chbFormatarCliente.Checked,
                    FormatBook = chbFormatarLivro.Checked,
                },
                renting = new() 
                {
                    UpdateRentStatus = chbAtualizarStatusAluguel.Checked,
                },
                telemetry = new() 
                {
                    UseTelemetry = chbTelemetria.Checked,   
                } 
            };

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                AppConfigurationManager.configuration.database = AppConfigurationManager.configuration.database with
                {
                    DbEngine = TipoDatabase.SqlServerExpress,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text,
                };
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                AppConfigurationManager.configuration.database = AppConfigurationManager.configuration.database with
                {
                    DbEngine = AppConfigurationManager.configuration.database.DbFolder.Contains("OneDrive") ?
                    TipoDatabase.OneDrive : TipoDatabase.SqlServerLocalDb,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text,
                };
            }
            else if (rabOneDrive.Checked && !AppConfigurationManager.configuration.database.DbFolder.Contains("OneDrive"))
            {
                DialogResult dialogResult = MessageBox
                    .Show(Resources.ConexaoLocalMigrarOneDrive,
                    Resources.Informacao_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;

                AppConfigurationManager.configuration.database = AppConfigurationManager.configuration.database with
                {
                    DbFolder = "onedrive",
                    SqlConnectionString = string.Empty
                };
            }

            AppConfigurationManager.SaveConfig();

            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.Concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Se o usuário mudou a string de conexão o programa deve reiniciar
            if (!stringConexaoAtual.Equals(AppConfigurationManager.configuration.database.SqlConnectionString))
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

            AppConfigurationManager.configuration.database = AppConfigurationManager.configuration.database with
            {
                DbFolder = caminho.FileName
            };
            txtStringConexaoCaminhoDb.Text =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={caminho.FileName};Integrated Security=True";
        }

        private void btnRedefinirConfig_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            /*DialogResult dialogResult = MessageBox.Show(Resources.RedefinirConfig, Resources.Aviso_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialogResult != DialogResult.Yes) return;

            AppConfigurationManager.Reset();
            AppManager.ReiniciarPrograma();*/
        }
    }
}
