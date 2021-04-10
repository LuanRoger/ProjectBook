using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using ProjectBook.DB.Migration;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.GUI;
using ProjectBook.Properties;
using System.Threading.Tasks;
using AutoUpdaterDotNET;
using System.Reflection;
using System.Net;

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

            BaixarArquivosEscenciais();
            PrivateFontCollection privateFont = new PrivateFontCollection();
            privateFont.AddFontFile(Application.StartupPath + @"font\Montserrat-ExtraBold.ttf");
            privateFont.AddFontFile(Application.StartupPath + @"font\Montserrat-ExtraLight.ttf");
            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);

            //Sincronização OneDrive
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString == "")
            {
                lblStatusCarregamento.Text = Resources.migrando_banco_para_o_OneDrive;
                string pastaAplicacaoOneDrive = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                                @"\OneDrive\ProjectBook";
                OneDrive.MigrarOneDrive(pastaAplicacaoOneDrive);
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
        private void BaixarArquivosEscenciais() => AppManager.DownloadFonts();
        private void ProcurarAtualizacoes()
        {
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start(ConfigurationManager.AppSettings["updateFileServer"],
                Assembly.GetExecutingAssembly());
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
    }
}
