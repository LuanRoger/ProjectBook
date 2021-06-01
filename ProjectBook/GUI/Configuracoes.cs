using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class Configuracoes : Form
    {
        public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        
        public Configuracoes()
        {
            InitializeComponent();
            CarregarConfiguracoes();

            if (ConfigurationManager.AppSettings["tipoUsuario"] ==
                Tipos.TipoUsuário.ADM.ToString()) gpbBancoDados.Enabled = true;

            rabOneDrive.Visible = Verificadores.IsWin10();
        }

        private void CarregarConfiguracoes()
        {
            var directoryInfo = string.IsNullOrEmpty(ConfigurationManager.AppSettings["pastaDb"]) ?
                "" : Directory.GetParent(ConfigurationManager.AppSettings["pastaDb"]).ToString();

            chbVisualizarImpressao.Checked = ConfigurationManager.AppSettings["visualizarImpressao"] == "1";
            chbAtualizarStatusAluguel.Checked = ConfigurationManager.AppSettings["atualizarStatusAluguel"] == "1";
            chbFormatarCliente.Checked =  ConfigurationManager.AppSettings["formatarCliente"] == "1";
            chbFormatarLivro.Checked = ConfigurationManager.AppSettings["formatarLivro"] == "1";
            chbExibirCodigo.Checked = ConfigurationManager.AppSettings["ExibirID"] == "1";
            chbTelemetria.Checked = ConfigurationManager.AppSettings["telemetry"] == "1";

            switch (ConfigurationManager.AppSettings["dbPadrao"])
            {
                case "sqlserverexpress":
                    rabSqlServerExpress.Checked = true;
                    break;
                case "sqlserverlocaldb":
                    rabSqlServerLocalDb.Checked = true;
                    break;
                case "onedrive" when directoryInfo.Contains("OneDrive"):
                    rabOneDrive.Checked = true;
                    break;
            }
            txtStringConexaoCaminhoDb.Text = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            //Nescessario para verificar se houve mudança
            string stringConexaoAtual = config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString;

            //Preferencias de impressão
            config.AppSettings.Settings["visualizarImpressao"].Value = chbVisualizarImpressao.Checked ? "1" : "0";
            config.AppSettings.Settings["ExibirID"].Value = chbExibirCodigo.Checked ? "1" : "0";
            
            //Formatação
            config.AppSettings.Settings["formatarCliente"].Value = chbFormatarCliente.Checked ? "1" : "0";
            config.AppSettings.Settings["formatarLivro"].Value = chbFormatarLivro.Checked ? "1" : "0";

            //Preferencias de aluguel
            config.AppSettings.Settings["atualizarStatusAluguel"].Value = chbAtualizarStatusAluguel.Checked ? "1" : "0";

            //Telemetria
            config.AppSettings.Settings["telemetry"].Value = chbTelemetria.Checked ? "1" : "0";

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                config.AppSettings.Settings["dbPadrao"].Value = "sqlserverexpress";
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = txtStringConexaoCaminhoDb.Text;
                config.AppSettings.Settings["pastaDb"].Value = "";
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                config.AppSettings.Settings["dbPadrao"].Value = ConfigurationManager.AppSettings["pastaDb"].Contains("OneDrive") ?
                    "onedrive" : "sqlserverlocaldb";

                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = txtStringConexaoCaminhoDb.Text;
            }
            else if (rabOneDrive.Checked && !ConfigurationManager.AppSettings["pastaDb"].Contains("OneDrive"))
            {
                DialogResult dialogResult = MessageBox
                    .Show(Resources.ConexaoLocalMigrarOneDrive,
                    Resources.MessageBoxInformacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;

                config.AppSettings.Settings["dbPadrao"].Value = "onedrive";
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = "";
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Se o usuário mudou a string de conexão o programa deve ser reinicado
            if (!stringConexaoAtual.Equals(config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString))
            {
                MessageBox.Show(Resources.mudancaConnectionString,
                    Resources.MessageBoxInformacao, MessageBoxButtons.OK, MessageBoxIcon.Information);

                AppManager.ReiniciarPrograma();
            }
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

            DirectoryInfo directoryInfo = string.IsNullOrEmpty(ConfigurationManager.AppSettings["pastaDb"]) ?
                null : Directory.GetParent(ConfigurationManager.AppSettings["pastaDb"]);

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

        private void btnSelecionarArquivoDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog caminho = new() { Filter = "Arquivo MDF (*.mdf)|*.mdf", Multiselect = false };
            DialogResult dialogResult = caminho.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            config.AppSettings.Settings["pastaDb"].Value = caminho.FileName;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            txtStringConexaoCaminhoDb.Text =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={caminho.FileName};Integrated Security=True";
        }
    }
}
