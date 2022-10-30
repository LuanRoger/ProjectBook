using System.Drawing;
using System.Windows.Forms;
using ProjectBook.Controllers;
using ProjectBook.Properties;
using ProjectBook.Model.Enums;
using ProjectBook.Services;

//String.Copy is used to create a non mutable string
#pragma warning disable CS0618

namespace ProjectBook.GUI
{
    public partial class Configuracoes : Form
    {
        private bool safeMode { get; }
        private UserSessionController userSessionController { get; } = new();
        
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
                userSessionController.GiveAdm();
                FormClosed += (_, _) =>
                {
                    userSessionController.RemoveAdm();
                    Environment.Exit(1);  
                };
            }
            
            gpbBancoDados.Enabled = UserSessionController.userCurrentSession.tipo == TipoUsuario.ADM;
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
            chbVisualizarImpressao.Checked = Globals.configurationController.configuration.printer.PreviewPrinter;
            chbAtualizarStatusAluguel.Checked = Globals.configurationController.configuration.renting.UpdateRentStatus;
            chbFormatarCliente.Checked =  Globals.configurationController.configuration.formating.FormatClient;
            chbFormatarLivro.Checked = Globals.configurationController.configuration.formating.FormatBook;
            chbExibirCodigo.Checked = Globals.configurationController.configuration.printer.ShowId;
            chbTelemetria.Checked = Globals.configurationController.configuration.telemetry.UseTelemetry;

            switch (Globals.configurationController.configuration.database.DbEngine)
            {
                case TipoDatabase.SqlServerExpress:
                    rabSqlServerExpress.Checked = true;
                    break;
                case TipoDatabase.SqlServerLocalDb:
                    rabSqlServerLocalDb.Checked = true;
                    break;
            }
            txtStringConexaoCaminhoDb.Text = Globals.configurationController.configuration.database.SqlConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            string stringConexaoAtual = 
                string.Copy(Globals.configurationController.configuration.database.SqlConnectionString);

            SaveConfigurations();
            
            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.Concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // If the user change the connection string, the program must to be restarted.
            if (stringConexaoAtual.Equals(Globals.configurationController.configuration.database.SqlConnectionString)) return;
            MessageBox.Show(Resources.MudancaConnectionString,
                Resources.Informacao_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);

            AppController.RestartApplication();
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
            
            IOAppService ioAppService = new();
            
            Globals.configurationController.ResetConfig();
            ioAppService.DeleteUserInfoFile();
            AppController.RestartApplication();
        }
        private async void btnCriarBanco_Click(object sender, EventArgs e)
        {
            Globals.configurationController.configuration.database.SqlConnectionString = txtStringConexaoCaminhoDb.Text;
            Globals.configurationController.SaveConfig();
            
            HideAllButtons();
            
            try { await Globals.databaseController.CreateDatabase(); }
            catch 
            { 
                MessageBox.Show(Resources.ErrorExecutarAcao,
                Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                
                Environment.Exit(1); 
            }

            MessageBox.Show(Resources.BancoCriado, Resources.Informacao_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            AppController.RestartApplication();
        }
        
        private void HideAllButtons()
        {
            pgbCreateDatabase.Visible = true;
            btnCriarBanco.Enabled = false;
            btnRedefinirConfig.Enabled = false;
            btnSalvarConfiguracoes.Enabled = false;
        }
        
        private void SaveConfigurations()
        {
            Globals.configurationController.configuration.printer = new()
            {
                PreviewPrinter = chbVisualizarImpressao.Checked,
                ShowId = chbExibirCodigo.Checked
            };
            Globals.configurationController.configuration.formating = new() 
            {
                FormatClient = chbFormatarCliente.Checked,
                FormatBook = chbFormatarLivro.Checked,
            };
            Globals.configurationController.configuration.renting = new() 
            {
                UpdateRentStatus = chbAtualizarStatusAluguel.Checked,
            };
            Globals.configurationController.configuration.telemetry = new() 
            {
                UseTelemetry = chbTelemetria.Checked,   
            };

            //Connection String
            if (rabSqlServerExpress.Checked)
            {
                Globals.configurationController.configuration.database = new()
                {
                    DbEngine = TipoDatabase.SqlServerExpress,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text
                };
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                Globals.configurationController.configuration.database = new()
                {
                    DbEngine = TipoDatabase.SqlServerLocalDb,
                    SqlConnectionString = txtStringConexaoCaminhoDb.Text
                };
            }

            Globals.configurationController.SaveConfig();
        }
    }
}
