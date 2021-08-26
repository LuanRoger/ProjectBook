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
using ProjectBook.Livros;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();

            AppManager.DownloadFonts();
            AppConfigurationManager.LoadConfig();

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRALIGHT);

            label1.Font = new(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new(privateFont.Families[1], 7, FontStyle.Regular);
        }
        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            bool createDatabase = false;
            if (!DatabaseManager.VerificarConexao())
            {
                DialogResult dialogResult = MessageBox.Show("Não foi possivel conectar ao banco," +
                                " deseja criar um novo?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                createDatabase = dialogResult == DialogResult.Yes;
            }
            await CreateDatabase(createDatabase);

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
            inicializeTasks.Add(Task.Run(SearchForUpdates));
            inicializeTasks.Add(AtualizarAtrasso());
            inicializeTasks.Add(Task.Delay(Consts.SPLASH_SCREEN_LOADTIME));

            await Task.WhenAll(inicializeTasks.ToArray());

            Close();
        }

        private async Task SyncOneDrive()
        {
            if (AppConfigurationManager.configuration.database.DbEngine == Tipos.TipoDatabase.OneDrive &&
                AppConfigurationManager.configuration.database.SqlConnectionString == "")
            {
                lblStatusCarregamento.Text = Resources.MigrandoOneDrive;
                await Task.Run(OneDrive.MigrarOneDrive);
            }
        }
        private void SearchForUpdates()
        {
            lblStatusCarregamento.Invoke(new MethodInvoker(delegate
                { lblStatusCarregamento.Text = Resources.ProcurandoAtualizacoes_SplashScreen; }));
            AppUpdateManager.SearchUpdates();
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

        private async Task CreateDatabase(bool createDb)
        {
            if(createDb) await DatabaseManager.CreateDb();
        }
        
        private async Task AtualizarAtrasso()
        {
            lblStatusCarregamento.Text = Resources.AtualizandoBancoDados_SpashScreen;
            
            foreach (AluguelModel data in await AluguelDb.PegarLivrosAlugados())
            {
                DateTime hoje = DateTime.Now.Date;
                DateTime devolucao = data.dataDevolucao;
                if (Convert.ToInt32((hoje - devolucao).Days) >= 0)
                    AluguelDb.AtualizarStatusAtrasado(data.alugadoPor);
            }
        }
    }
}
