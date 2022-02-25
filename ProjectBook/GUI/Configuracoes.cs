using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.Tipos;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.GUI
{
    public partial class Configuracoes : Form
    {
        private bool safeMode { get; }
        public Configuracoes(bool safeMode = false)
        {
            InitializeComponent();
            this.safeMode = safeMode;
        }
        
        private void Configuracoes_Load(object sender, EventArgs e)
        {
            CarregarConfiguracoes();
            
            if (safeMode)
            {
                btnCriarBanco.Visible = true;
                AppManager.GiveAdm();
                FormClosed += (_, _) =>
                {
                    AppManager.RemoveAdm();
                    Environment.Exit(1);  
                };
            }
            
            gpbBancoDados.Enabled = UserInfo.UserNowInstance.tipoUsuario == TipoUsuario.ADM;
        }

        #region CheckedChanged
        private void rabSqlServerExpress_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoText.Text = Resources.StringConexao;
            lblInfoText.Visible = true;

            lblInfoText.ForeColor = Color.Black;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new(459, 23);
        }
        private void rabSqlServerLocalDb_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoText.Visible = true;
            lblInfoText.Text = Resources.CaminhoBanco;
            lblInfoText.ForeColor = Color.Black;

            btnSelecionarArquivoDb.Visible = true;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new(426, 23);
        }
        #endregion

        private void CarregarConfiguracoes()
        {
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
            }
            txtStringConexaoCaminhoDb.Text = AppConfigurationManager.configuration.database.SqlConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            string stringConexaoAtual = AppConfigurationManager.configuration.database.SqlConnectionString;

            AppConfigurationManager.configuration.printer = new()
            {
                PreviewPrinter = chbVisualizarImpressao.Checked,
                ShowId = chbExibirCodigo.Checked
            };
            AppConfigurationManager.configuration.formating = new() 
            {
                FormatClient = chbFormatarCliente.Checked,
                FormatBook = chbFormatarLivro.Checked,
            };
            AppConfigurationManager.configuration.renting = new() 
            {
                UpdateRentStatus = chbAtualizarStatusAluguel.Checked,
            };
            AppConfigurationManager.configuration.telemetry = new() 
            {
                UseTelemetry = chbTelemetria.Checked,   
            };

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                AppConfigurationManager.configuration.database = new()
                {
                    DbEngine = TipoDatabase.SqlServerExpress,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text
                };
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                AppConfigurationManager.configuration.database = new()
                {
                    DbEngine = TipoDatabase.SqlServerLocalDb,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text
                };
            }

            AppConfigurationManager.SaveConfig();

            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.Concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Se o usuário mudou a string de conexão o programa deve reiniciar
            if (stringConexaoAtual.Equals(AppConfigurationManager.configuration.database.SqlConnectionString)) return;
            MessageBox.Show(Resources.MudancaConnectionString,
                Resources.Informacao_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);

            AppManager.ReiniciarPrograma();
        }

        private void btnSelecionarArquivoDb_Click(object sender, EventArgs e)
        {
            GetInput getInput = new("Nome do banco");
            getInput.ShowDialog();
            
            if(getInput.hasCanceled) return;
            
            txtStringConexaoCaminhoDb.Text = string.Format(Consts.CONN_STRING_LOCAL_MODEL, getInput.input);
        }

        private void btnRedefinirConfig_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Resources.RedefinirConfig, Resources.Aviso_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialogResult != DialogResult.Yes) return;

            AppConfigurationManager.ResetConfig();
            UserInfo.DeleteUserFile();
            AppManager.ReiniciarPrograma();
        }
        private async void btnCriarBanco_Click(object sender, EventArgs e)
        {
            AppConfigurationManager.configuration.database.SqlConnectionString = txtStringConexaoCaminhoDb.Text;
            AppConfigurationManager.SaveConfig();

            pgbCreateDatabase.Visible = true;
            btnCriarBanco.Enabled = false;
            btnRedefinirConfig.Enabled = false;
            btnSalvarConfiguracoes.Enabled = false;

            try { await DatabaseManager.CreateDb(); }
            catch 
            { 
                MessageBox.Show(Resources.ErrorExecutarAcao,
                Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                
                Environment.Exit(1); 
            }

            MessageBox.Show(Resources.BancoCriado, Resources.Informacao_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            AppManager.ReiniciarPrograma();
        }
    }
}
