using System;
using System.Configuration;
using System.Data;
using System.Linq;
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
<<<<<<< HEAD
        private readonly string _fontMontserratExtraBold = Application.StartupPath + @"font\Montserrat-ExtraBold.ttf";
        private readonly string _fontMontserratExtraLight = Application.StartupPath + @"font\Montserrat-ExtraLight.ttf";

        private LivrosDb livrosDb = new();
        private AluguelDb aluguelDb = new();
=======
        private LivrosDb livrosDb = new LivrosDb();
        private AluguelDb aluguelDb = new AluguelDb();
        private UsuarioDb usuarioDb = new UsuarioDb();
>>>>>>> parent of e20e8c2 (v0.5.4-beta)

        public SplashScreen()
        {
            InitializeComponent();

<<<<<<< HEAD
            AppManager.DownloadFonts();

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(_fontMontserratExtraBold);
            privateFont.AddFontFile(_fontMontserratExtraLight);
=======
            BaixarArquivosEscenciais();
            PrivateFontCollection privateFont = new PrivateFontCollection();
            privateFont.AddFontFile(Application.StartupPath + @"font\Montserrat-ExtraBold.ttf");
            privateFont.AddFontFile(Application.StartupPath + @"font\Montserrat-ExtraLight.ttf");
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);

            //Sincronização OneDrive
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString == "")
            {
<<<<<<< HEAD
                lblStatusCarregamento.Text = Strings.MigrandoOneDrive;
                OneDrive.MigrarOneDrive();
=======
                lblStatusCarregamento.Text = Resources.migrando_banco_para_o_OneDrive;
                string pastaAplicacaoOneDrive = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                                @"\OneDrive\ProjectBook";
                OneDrive.MigrarOneDrive(pastaAplicacaoOneDrive);
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
            }

            //Verificar conexão com o DB
            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() != "Open") return;
            livrosDb.FechaConecxaoDb();

            //Verificar se existe usuário logado
<<<<<<< HEAD
            lblStatusCarregamento.Text = Strings.VerificacoesSegurancaSplashScreen;
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
            {
                UsuarioLogado();
                return;
            }

            //Atualizar Status do aluguel
            lblStatusCarregamento.Text = Strings.AtualizandoBancoDadosSpashScreen;
            if (ConfigurationManager.AppSettings["atualizarStatusAluguel"] == "1") AtualizarAtrasso();

            //Procurar atualizazções
            lblStatusCarregamento.Text = Strings.ProcurandoAtualizacoesSplashScreen;
            AppManager.ProcurarAtualizacoes();
=======
            lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
            UsuarioLogado();
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"])) return;

            //Atualizar Status do aluguel
            lblStatusCarregamento.Text = Resources.atualizando_banco_de_dados_splashscreen;
            AtualizarAtrasso();

            //Procurar atualizazções
            lblStatusCarregamento.Text = "Procurando por atualizações...";
            ProcurarAtualizacoes();
>>>>>>> parent of e20e8c2 (v0.5.4-beta)

            Task.Run(async () =>
            {
                await Task.Delay(Consts.SPLASH_SCREEN_LOADTIME);
                Invoke((MethodInvoker)delegate { Close(); });
            });
        }
<<<<<<< HEAD
=======
        private void BaixarArquivosEscenciais() => AppManager.DownloadFonts();
        private void ProcurarAtualizacoes()
        {
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start(ConfigurationManager.AppSettings["updateFileServer"],
                Assembly.GetExecutingAssembly());
        }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
        private void UsuarioLogado()
        {
            if (Application.OpenForms.Count < 2)
            {
                Login login = new();
                login.BringToFront();
                login.Show();
            }
            else { /*Configurações aberta*/ }
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
    }
}
