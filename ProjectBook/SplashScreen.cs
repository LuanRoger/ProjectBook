using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.GUI;
using ProjectBook.Properties;

namespace ProjectBook
{
    public partial class SplashScreen : Form
    {
        private LivrosDb livrosDb = new LivrosDb();
        private AluguelDb aluguelDb = new AluguelDb();
        private UsuarioDb usuarioDb = new UsuarioDb();

        public SplashScreen()
        {
            InitializeComponent();

            try
            {
                PrivateFontCollection privateFont = new PrivateFontCollection();
                privateFont.AddFontFile(Application.StartupPath + @"font\Montserrat-ExtraBold.ttf");
                privateFont.AddFontFile(Application.StartupPath + @"font\Montserrat-ExtraLight.ttf");
                label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
                label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show(Resources.está_faltando_arquivos_escenciais_para_abrir_o_programa__tente_reistalar_lo_novamente_,
                    Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }

            //Sincronização OneDrive
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString == "")
            {
                lblStatusCarregamento.Text = Resources.migrando_banco_para_o_OneDrive;
                string pastaAplicacaoOneDrive = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                                @"\OneDrive\ProjectBook";
                MigrarOneDrive(pastaAplicacaoOneDrive);
            }

            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() == "Open")
            {
                //Atualizar Status do aluguel
                lblStatusCarregamento.Text = Resources.atualizando_banco_de_dados_splashscreen;
                if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"])) AtualizarAtrasso();

                //Verificar se existe usuário logado
                lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
                UsuarioLogado();
            }
            livrosDb.FechaConecxaoDb();
        }
        private void UsuarioLogado()
        {
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
            {
                if (Application.OpenForms.Count < 2)
                {
                    Login login = new Login();
                    login.BringToFront();
                    login.Show();
                }
            }
            else
            {
                DataRow usuario = usuarioDb.BuscarUsuarioNome(ConfigurationManager.AppSettings["usuarioLogado"]);
                Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = usuario[3].ToString();
                Configuracoes.config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private void AtualizarAtrasso()
        {
            foreach (DataRow data in aluguelDb.PegarLivrosAlugados().Rows)
            {
                DateTime hoje = DateTime.Now.Date;
                DateTime devolucao = (DateTime)data[4];
                if (Convert.ToInt32((hoje - devolucao).Days) >= 0)
                   aluguelDb.AtualizarStatusAtrasado(data[2].ToString());
            }
        }

        private void MigrarOneDrive(string pastaAplicacaoOneDrive)
        {
            try
            {
                if (Directory.Exists(pastaAplicacaoOneDrive)) Directory.Delete(pastaAplicacaoOneDrive, true);
                //Mover pasta o OneDrive
                Directory.Move(Directory
                    .GetParent(ConfigurationManager.AppSettings["pastaDb"]).ToString(), pastaAplicacaoOneDrive);

                //Pegar o novo diretorio do banco de dados
                string diretorioDbOneDrive = Directory
                    .GetFiles(pastaAplicacaoOneDrive, "*.*", SearchOption.AllDirectories)
                    .First(mdf => mdf.Contains(".mdf"));

                //Criar novo string de conexão
                Configuracoes.config.ConnectionStrings.ConnectionStrings["SqlConnectionString"]
                        .ConnectionString =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True;MultipleActiveResultSets=True";

                Configuracoes.config.AppSettings.Settings["pastaDb"].Value = pastaAplicacaoOneDrive;
                Configuracoes.config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format(Resources.ocorreu_um_error___0___Volte_as_configurações_e_crie_uma_novo_string_de_conexão_, e.Message),
                    Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
