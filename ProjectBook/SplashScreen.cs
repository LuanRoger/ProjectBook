using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(FONTMONTSERRATEXTRABOLD);
            privateFont.AddFontFile(FONTMONTSERRATEXTRALIGHT);

            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);
        }
        private async void SplashScreen_Activated(object sender, EventArgs e)
        {
            if (!livrosDb.VerificarConexaoDb()) return;

            lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
            {
                UsuarioLogado();
                return;
            }
            else AppManager.UpdateUserInfo();

            List<Task> inicializeTasks = new();
            inicializeTasks.Add(SyncOneDrive());
            inicializeTasks.Add(SearchForUpdates());
            inicializeTasks.Add(AtualizarAluguel());
            inicializeTasks.Add(Task.Delay(Consts.SPLASH_SCREEN_LOADTIME));
            await Task.WhenAll(inicializeTasks.ToArray());

            Close();
        }

        private async Task SyncOneDrive()
        {
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString == "")
            {
                lblStatusCarregamento.Text = Resources.MigrandoOneDrive;
                await Task.Run(OneDrive.MigrarOneDrive);
            }
        }
        private async Task SearchForUpdates()
        {
            lblStatusCarregamento.Text = Resources.ProcurandoAtualizacoesSplashScreen;
            await Task.Run(AppManager.ProcurarAtualizacoes);
        }
        private async Task AtualizarAluguel()
        {
            lblStatusCarregamento.Text = Resources.AtualizandoBancoDadosSpashScreen;
            if (ConfigurationManager.AppSettings["atualizarStatusAluguel"] == "1") await Task.Run(AtualizarAtrasso);
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
        private void AtualizarAtrasso()
        {
            AluguelDb aluguelDb = new();

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
