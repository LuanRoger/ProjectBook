using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Reflection;
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

            //Verificar sistema operacional
            string so = null;
            using ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (var infos in searcher.Get())
            {
                so = infos["Caption"].ToString();
            }
            if (String.IsNullOrEmpty(so) || !so.Contains("Windows 10")) rabOneDrive.Visible = false;
        }

        private void CarregarConfiguracoes()
        {
            var directoryInfo = String.IsNullOrEmpty(ConfigurationManager.AppSettings["pastaDb"]) ?
                "" : Directory.GetParent(ConfigurationManager.AppSettings["pastaDb"]).ToString();
            if (ConfigurationManager.AppSettings["visualizarImpressao"] == "1") chbVisualizarImpressao.Checked = true;
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
                    .Show(Resources.você_deseja_migrar_o_banco_de_dados_para_seu_OneDrive__Para_que_a_sincronização_funcione_você_deve_estar_com_o_aplicativo_do_OneDrive_sempre_atualizado_,
                    Resources.informacao_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult != DialogResult.Yes) return;

                config.AppSettings.Settings["dbPadrao"].Value = "onedrive";
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = "";
            }

            //Salvar
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show(Resources.configuracoesSalvas_MessageBox, Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Se o usuário mudou a string de conexão o programa deve ser reinicado
            if (!stringConexaoAtual.Equals(config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString))
            {
                MessageBox.Show(Resources.mudancaConnectionString,
                    Resources.informacao_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
                Process.GetCurrentProcess().Kill();
            }
        }

        private void rabSqlServerExpress_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = Resources.string_de_conexão;
            lblInfoTxt.ForeColor = Color.Black;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(441, 23);
        }
        private void txtStringConexaoCaminhoDb_Leave(object sender, EventArgs e)
        {
            if (txtStringConexaoCaminhoDb.Text.Contains("MultipleActiveResultSets=True") &&
                rabSqlServerExpress.Checked) lblMars.Visible = false;
            else lblMars.Visible = true;
        }
        private void rabSqlServerLocalDb_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Text = Resources.caminho_do_banco_de_dados;
            lblInfoTxt.ForeColor = Color.Black;
            btnSelecionarArquivoDb.Visible = true;
            txtStringConexaoCaminhoDb.Visible = true;
            txtStringConexaoCaminhoDb.Size = new Size(408, 23);
        }
        private void rabOneDrive_CheckedChanged(object sender, EventArgs e)
        {
            lblInfoTxt.Visible = false;
            btnSelecionarArquivoDb.Visible = false;
            txtStringConexaoCaminhoDb.Visible = false;

            DirectoryInfo directoryInfo;
            try { directoryInfo = Directory.GetParent(ConfigurationManager.AppSettings["pastaDb"]); }
            catch
            {
                MessageBox.Show(
                    Resources.é_necessário_fazer_uma_conexão_local_com_o_banco_de_dados_para_fazer_a_migração_para_o_OneDrive_,
                    Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                rabSqlServerLocalDb.Checked = true;
                return;
            }
            if (directoryInfo?.Parent != null && directoryInfo.ToString().Contains("OneDrive"))
            {
                lblInfoTxt.Visible = true;
                lblInfoTxt.Text = Resources.banco_de_dados_sincronizado_com_o_OneDrive;
                lblInfoTxt.ForeColor = Color.Green;
            }
        }

        private void btnSelecionarArquivoDb_Click(object sender, EventArgs e)
        {
            OpenFileDialog caminho = new OpenFileDialog 
                { Filter = "Arquivo MDF (*.mdf)|*.mdf", Multiselect = false };
            DialogResult dialogResult = caminho.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            config.AppSettings.Settings["pastaDb"].Value = caminho.FileName;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
            txtStringConexaoCaminhoDb.Text =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={caminho.FileName};Integrated Security=True;MultipleActiveResultSets=True";
        }

        private void btnPersonalizarImpressao_Click(object sender, EventArgs e)
        {
            PersonalizarImpressao personalizarImpressao = new PersonalizarImpressao();
            personalizarImpressao.Show();
        }
    }
}
