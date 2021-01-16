using System;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
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
            if (ConfigurationManager.AppSettings["formatarCliente"] == "1") chbFormatarCliente.Checked = true;
            if (ConfigurationManager.AppSettings["formatarLivro"] == "1") chbFormatarLivro.Checked = true;
            txtStringConexao.Text = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
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
            config.AppSettings.Settings["dbPadrao"].Value = "sqlserverexpress";
            config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = txtStringConexao.Text;
            
            //Salvar
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show(Properties.Resources.configuracoesSalvas_MessageBox, Properties.Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Se o usuário mudou a string de conexão o programa deve ser reinicado
            if (stringConexaoAtual != config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString)
            {
                MessageBox.Show("Houve uma mudança na String de conexão, o programa será reiniciado.",
                    Properties.Resources.informacao_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
