using System;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace ProjectBook
{
    public partial class Configuracoes : Form
    {
        public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        
        public Configuracoes()
        {
            InitializeComponent();
            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            if (ConfigurationManager.AppSettings["visualizarImpressao"] == "1") chbVisualizarImpressao.Checked = true;
            if (ConfigurationManager.AppSettings["dbPadrao"] == "sqlserverexpress") rabSqlServerExpress.Checked = true;
            else if (ConfigurationManager.AppSettings["dbPadrao"] == "sqlserverlocaldb") rabSqlServerLocalDb.Checked = true;
            if (ConfigurationManager.AppSettings["formatarCliente"] == "1") chbFormatarCliente.Checked = true;
            if (ConfigurationManager.AppSettings["formatarLivro"] == "1") chbFormatarLivro.Checked = true;
            txtStringConexaoCaminhoDb.Text = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        }

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            //Nescessario para verificar se houve mudança
            string stringConexaoAtual = config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString;

            //Preferencias de impressão
            if (chbVisualizarImpressao.Checked) config.AppSettings.Settings["visualizarImpressao"].Value = "1";
            else config.AppSettings.Settings["visualizarImpressao"].Value = "0";
            
            //Formatação
            if (chbFormatarCliente.Checked) config.AppSettings.Settings["formatarCliente"].Value = "1";
            else config.AppSettings.Settings["formatarCliente"].Value = "0";

            if (chbFormatarLivro.Checked) config.AppSettings.Settings["formatarLivro"].Value = "1";
            else config.AppSettings.Settings["formatarLivro"].Value = "0";

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                config.AppSettings.Settings["dbPadrao"].Value = "sqlserverexpress";
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = txtStringConexaoCaminhoDb.Text;
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                config.AppSettings.Settings["dbPadrao"].Value = "sqlserverlocaldb";
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={txtStringConexaoCaminhoDb.Text};Integrated Security=True";
            }
            //Salvar
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show(Properties.Resources.configuracoesSalvas_MessageBox, Properties.Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Se o usuário mudou a string de conexão o programa deve ser reinicado
            if (stringConexaoAtual != config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString)
            {
                MessageBox.Show(Properties.Resources.mudancaConnectionString,
                    Properties.Resources.informacao_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
                Process.GetCurrentProcess().Kill();
            }
        }
        private void rabSqlServerExpress_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = "String de conexão:";
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Size = new Size(441, 23);
        }

        private void rabSqlServerLocalDb_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = "Caminho do banco de dados:";
            btnSelecionarArquivoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(408, 23);
        }

        private void btnSelecionarArquivoDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog caminho = new OpenFileDialog();
            caminho.Filter = "Arquivo MDF (*.mdf)|*.mdf";
            caminho.Multiselect = false;
            DialogResult dialogResult = caminho.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var d = caminho.FileName;
                txtStringConexaoCaminhoDb.Text = caminho.FileName;
            }
        }
    }
}
