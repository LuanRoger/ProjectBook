using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.GUI;
using ProjectBook.Properties;
using System.Threading.Tasks;
using ProjectBook.DB.OneDrive;

namespace ProjectBook
{
    public partial class SplashScreen : Form
    {
        private readonly string FONTMONTSERRATEXTRABOLD = Application.StartupPath + @"font\Montserrat-ExtraBold.ttf";
        private readonly string FONTMONTSERRATEXTRALIGHT = Application.StartupPath + @"font\Montserrat-ExtraLight.ttf";

        private LivrosDb livrosDb = new();

        public SplashScreen()
        {
            InitializeComponent();

            AppManager.DownloadFonts();
            AppManager.DownloadScripts();

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(FONTMONTSERRATEXTRABOLD);
            privateFont.AddFontFile(FONTMONTSERRATEXTRALIGHT);

            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);

            //Sincronização OneDrive
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString == "")
            {
                lblStatusCarregamento.Text = Resources.MigrandoOneDrive;
                OneDrive.MigrarOneDrive();
            }

            if (!livrosDb.VerificarConexaoDb()) return;

            //Verificar se existe usuário logado
            lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
            {
                UsuarioLogado();
                return;
            }
            else UpdateUserInfo();

            //Atualizar Status do aluguel
            lblStatusCarregamento.Text = Resources.AtualizandoBancoDadosSpashScreen;
            var d = ConfigurationManager.AppSettings["atualizarStatusAluguel"];
            if (ConfigurationManager.AppSettings["atualizarStatusAluguel"] == "1") AtualizarAtrasso();

            //Procurar atualizazções
            lblStatusCarregamento.Text = Resources.ProcurandoAtualizacoesSplashScreen;
            AppManager.ProcurarAtualizacoes();

            Task.Run(async () =>
            {
                await Task.Delay(Consts.SPLASH_SCREEN_LOADTIME);
                Invoke((MethodInvoker)Close);
            });
        }

        private void UsuarioLogado()
        {
            if (Application.OpenForms.Count < 2)
            {
                Login login = new();
                login.BringToFront();
                login.Show();
            }
            else AppManager.ReiniciarPrograma();
        }
        private void UpdateUserInfo()
        {
            var d = new UsuarioDb().ReceberTipoUsuario(ConfigurationManager.AppSettings["usuarioLogado"]).Rows[0][0].ToString();
            
            Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = 
                new UsuarioDb().ReceberTipoUsuario(ConfigurationManager.AppSettings["usuarioLogado"]).Rows[0][0].ToString();
            Configuracoes.config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void AtualizarAtrasso()
        {
            AluguelDb aluguelDb = new();

            var d = aluguelDb.PegarLivrosAlugados().Rows;

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
