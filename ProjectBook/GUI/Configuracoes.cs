using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProjectBook.Properties;
using ProjectBook.Tipos;
using ProjectBook.Managers;

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

            DirectoryInfo directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.pastaDb) ?
                null : Directory.GetParent(AppConfigurationManager.pastaDb);

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
            var directoryInfo = string.IsNullOrEmpty(AppConfigurationManager.pastaDb) ?
                "" : Directory.GetParent(AppConfigurationManager.pastaDb).ToString();

            chbVisualizarImpressao.Checked = AppConfigurationManager.visualizarImpressao;
            chbAtualizarStatusAluguel.Checked = AppConfigurationManager.atualizarStatusAluguel;
            chbFormatarCliente.Checked =  AppConfigurationManager.formatarCliente;
            chbFormatarLivro.Checked = AppConfigurationManager.formatarLivro;
            chbExibirCodigo.Checked = AppConfigurationManager.exibirId;
            chbTelemetria.Checked = AppConfigurationManager.telemetry;

            switch (AppConfigurationManager.dbPadrao)
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
            txtStringConexaoCaminhoDb.Text = AppConfigurationManager.SqlConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            //Nescessario para verificar se houve mudança
            string stringConexaoAtual = AppConfigurationManager.SqlConnectionString;

            //Preferencias de impressão
            AppConfigurationManager.visualizarImpressao = chbVisualizarImpressao.Checked;
            AppConfigurationManager.exibirId = chbExibirCodigo.Checked;
            
            //Formatação
            AppConfigurationManager.formatarCliente = chbFormatarCliente.Checked;
            AppConfigurationManager.formatarLivro = chbFormatarLivro.Checked;

            //Preferencias de aluguel
            AppConfigurationManager.atualizarStatusAluguel = chbAtualizarStatusAluguel.Checked;

            //Telemetria
            AppConfigurationManager.telemetry = chbTelemetria.Checked;

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                AppConfigurationManager.dbPadrao = TipoDatabase.SqlServerExpress;
                AppConfigurationManager.SqlConnectionString = txtStringConexaoCaminhoDb.Text;
                AppConfigurationManager.pastaDb = "";
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                AppConfigurationManager.dbPadrao = AppConfigurationManager.pastaDb.Contains("OneDrive") ?
                    TipoDatabase.OneDrive : TipoDatabase.SqlServerLocalDb;

                AppConfigurationManager.SqlConnectionString = txtStringConexaoCaminhoDb.Text;
            }
            else if (rabOneDrive.Checked && !AppConfigurationManager.pastaDb.Contains("OneDrive"))
            {
                DialogResult dialogResult = MessageBox
                    .Show(Resources.ConexaoLocalMigrarOneDrive,
                    Resources.MessageBoxInformacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;

                AppConfigurationManager.pastaDb = "onedrive";
                AppConfigurationManager.SqlConnectionString = "";
            }

            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Se o usuário mudou a string de conexão o programa deve ser reinicado
            if (!stringConexaoAtual.Equals(AppConfigurationManager.SqlConnectionString))
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

            AppConfigurationManager.pastaDb = caminho.FileName;
            txtStringConexaoCaminhoDb.Text =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={caminho.FileName};Integrated Security=True";
        }
    }
}
