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
using System.Threading.Tasks;
using AutoUpdaterDotNET;
using System.Reflection;

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

            //Aplicar fontes
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

            //Verificar conexão com o DB
            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() != "Open") return;
            livrosDb.FechaConecxaoDb();

            //Verificar se existe usuário logado
            lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
            UsuarioLogado();

            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"])) return;

            //Atualizar Status do aluguel
            lblStatusCarregamento.Text = Resources.atualizando_banco_de_dados_splashscreen;
            AtualizarAtrasso();

            //Procurar atualizazções
            lblStatusCarregamento.Text = "Procurando por atualizações...";
            ProcurarAtualizacoes();

            Task.Run(async () => 
            {
                await Task.Delay(2500);
                this.Invoke((MethodInvoker)delegate { this.Close(); });
            });
        }
        private void UsuarioLogado()
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
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
                DataRow usuario = usuarioDb.BuscarUsuarioNome(ConfigurationManager.AppSettings["usuarioLogado"]).Rows[0];
                Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = usuario[3].ToString();
                Configuracoes.config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private void AtualizarAtrasso()
        {
            if (ConfigurationManager.AppSettings["atualizarStatusAluguel"] == "0") return;

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
                if (Directory.Exists(pastaAplicacaoOneDrive))
                {
                    DialogResult dialogResult = MessageBox.Show("Já existe um banco de dados sincronizado, deseja sobrescrever?",
                        Resources.informacao_MessageBox ,MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(dialogResult == DialogResult.No)
                    {
                        Configuracoes.config.AppSettings.Settings["dbPadrao"].Value = "sqlserverlocaldb";
                        Configuracoes.config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString =
                            $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ={ConfigurationManager.AppSettings["pastaDb"]}; Integrated Security = True";
                        Configuracoes.config.Save();
                        ConfigurationManager.RefreshSection("appSettings");

                        AppManager.ReiniciarPrograma();
                        return;
                    }
                }

                //Mover pasta o OneDrive
                Directory.Move(Directory
                    .GetParent(ConfigurationManager.AppSettings["pastaDb"]).ToString(), pastaAplicacaoOneDrive);

                //Pegar o novo diretorio do banco de dados
                string diretorioDbOneDrive = Directory
                    .GetFiles(pastaAplicacaoOneDrive, "*.*", SearchOption.AllDirectories)
                    .First(mdf => mdf.Contains(".mdf"));

                //Criar novo string de conexão
                Configuracoes.config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True";

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
        private void ProcurarAtualizacoes()
        {
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start(ConfigurationManager.AppSettings["updateFileServer"],
                Assembly.GetExecutingAssembly());
        }
    }
}
