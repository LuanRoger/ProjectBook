using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;
using ProjectBook.DB.Migration;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.GUI;
using ProjectBook.Properties.Languages;
using System.Threading.Tasks;

namespace ProjectBook
{
    public partial class SplashScreen : Form
    {
        private readonly string _fontMontserratExtraBold = Application.StartupPath + @"font\Montserrat-ExtraBold.ttf";
        private readonly string _fontMontserratExtraLight = Application.StartupPath + @"font\Montserrat-ExtraLight.ttf";

        private LivrosDb livrosDb = new LivrosDb();
        private AluguelDb aluguelDb = new AluguelDb();

        public SplashScreen()
        {
            InitializeComponent();

            BaixarArquivosEscenciais();

            PrivateFontCollection privateFont = new PrivateFontCollection();
            privateFont.AddFontFile(_fontMontserratExtraBold);
            privateFont.AddFontFile(_fontMontserratExtraLight);
            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);

            //Sincronização OneDrive
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString))
            {
                lblStatusCarregamento.Text = Strings.migrando_banco_para_o_OneDrive;
                OneDrive.MigrarOneDrive();
            }

            //Verificar conexão com o DB
            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() != ConnectionState.Open) return;
            livrosDb.FechaConecxaoDb();

            //Verificar se existe usuário logado
            lblStatusCarregamento.Text = Strings.realizando_verificações_de_segurança_splashscreen;
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
            {
                UsuarioLogado();
                return;
            }

            //Atualizar Status do aluguel
            lblStatusCarregamento.Text = Strings.atualizando_banco_de_dados_splashscreen;
            AtualizarAtrasso();

            //Procurar atualizazções
            lblStatusCarregamento.Text = "Procurando por atualizações...";
            AppManager.ProcurarAtualizacoes();

            Task.Run(async () =>
            {
                await Task.Delay(Consts.SPLASH_SCREEN_LOADTIME);
                Invoke((MethodInvoker)delegate { Close(); });
            });
        }
        private void BaixarArquivosEscenciais() => AppManager.DownloadFonts();
        private void UsuarioLogado()
        {
            if (Application.OpenForms.Count < 2)
            {
                Login login = new Login();
                login.BringToFront();
                login.Show();
            }
            else { /*Configurações aberta*/ }
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
