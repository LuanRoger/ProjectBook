using System;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using ProjectBook.Properties;

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
            config.AppSettings.Settings["visualizarImpressao"].Value = chbVisualizarImpressao.Checked ? "1" : "0";
            
            //Formatação
            config.AppSettings.Settings["formatarCliente"].Value = chbFormatarCliente.Checked ? "1" : "0";

            config.AppSettings.Settings["formatarLivro"].Value = chbFormatarLivro.Checked ? "1" : "0";

            //String de conexão
            if (rabSqlServerExpress.Checked)
            {
                config.AppSettings.Settings["dbPadrao"].Value = "sqlserverexpress";
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = txtStringConexaoCaminhoDb.Text;
            }
            else if (rabSqlServerLocalDb.Checked)
            {
                config.AppSettings.Settings["dbPadrao"].Value = "sqlserverlocaldb";
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = txtStringConexaoCaminhoDb.Text;
            }

            //Salvar
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            var d = stringConexaoAtual;
            var a = config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString;

            MessageBox.Show(Properties.Resources.configuracoesSalvas_MessageBox, Properties.Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Se o usuário mudou a string de conexão o programa deve ser reinicado
            if (!stringConexaoAtual.Equals(config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString))
            {
                MessageBox.Show(Properties.Resources.mudancaConnectionString,
                    Properties.Resources.informacao_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
                Process.GetCurrentProcess().Kill();
            }
        }
        private void rabSqlServerExpress_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = Resources.string_de_conexão;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Size = new Size(441, 23);
        }

        private void rabSqlServerLocalDb_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = Resources.caminho_do_banco_de_dados;
            btnSelecionarArquivoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(408, 23);
        }

        private void btnSelecionarArquivoDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog caminho = new OpenFileDialog 
                { Filter = "Arquivo MDF (*.mdf)|*.mdf", Multiselect = false };
            DialogResult dialogResult = caminho.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtStringConexaoCaminhoDb.Text =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={caminho.FileName};Integrated Security=True";
            }
        }
    }
}
