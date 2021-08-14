using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.GUI;
using ProjectBook.Properties;
using System.Threading.Tasks;
using ProjectBook.DB.OneDrive;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook
{
    public partial class SplashScreen : Form
    {
        private LivrosDb livrosDb = new();

        public SplashScreen()
        {
            InitializeComponent();

            AppManager.DownloadFonts();
            AppConfigurationManager.CreateConfigurationFile();

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRALIGHT);

            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);
        }
        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            if (!livrosDb.VerificarConexaoDb()) return;

            lblStatusCarregamento.Text = Resources.VerificacoesSeguranca_SplashScreen;

            AppManager.LoadUser();
            if (!Verificadores.VerificarUsuarioLogado())
            {
                UsuarioLogado();
                return;
            }
            else AppManager.UpdateUserInfo();

            List<Task> inicializeTasks = new();

            inicializeTasks.Add(SyncOneDrive());
            inicializeTasks.Add( Task.Run(SearchForUpdates));
            inicializeTasks.Add(AtualizarAluguel());
            inicializeTasks.Add(Task.Delay(Consts.SPLASH_SCREEN_LOADTIME));

            await Task.WhenAll(inicializeTasks.ToArray());

            Close();
        }

        private async Task SyncOneDrive()
        {
            if (AppConfigurationManager.configuration.DbEngine == Tipos.TipoDatabase.OneDrive &&
                AppConfigurationManager.configuration.SqlConnectionString == "")
            {
                lblStatusCarregamento.Text = Resources.MigrandoOneDrive;
                await Task.Run(OneDrive.MigrarOneDrive);
            }
        }
        private void SearchForUpdates()
        {
            lblStatusCarregamento.Text = Resources.ProcurandoAtualizacoes_SplashScreen;
            AppUpdateManager.SearchUpdates();
        }
        private async Task AtualizarAluguel()
        {
            lblStatusCarregamento.Text = Resources.AtualizandoBancoDados_SpashScreen;
            if (AppConfigurationManager.configuration.UpdateRentStatus) await Task.Run(AtualizarAtrasso);
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
